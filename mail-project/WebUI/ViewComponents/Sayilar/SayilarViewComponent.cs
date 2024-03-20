using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using Data.Concrete.EfCore;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Sayilar
{
    public class SayilarViewComponent : ViewComponent
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        MailManager _mailService = new MailManager(new MailDal());
        private UserManager<ProjeUser> _userManager;
        public SayilarViewComponent(UserManager<ProjeUser> userManager)
        {
            _userManager = userManager;
        }
        
        // METOTLAR ------------------------------------------------------------
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loginUser = User.Identity.Name;
            if (loginUser != null)
            {
                var user = await _userManager.FindByNameAsync(loginUser);
                if (user != null)
                {
                    ViewBag.gelenOkunmamisMailSayisi = _mailService.GetAll().Where(i => i.MailKimeMailName.ToLower() == user.Email.ToLower() && !i.MailRead && !i.MailDraft && !i.MailTrash).ToList().Count();

                    ViewBag.taslakMailSayisi = _mailService.GetAll().Where(i => i.MailKimdenMailId == user.Id && i.MailDraft && !i.MailTrash).ToList().Count();

                    return View();
                }
            }
            return View();
        }
    }
}