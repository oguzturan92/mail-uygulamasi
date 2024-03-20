using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using Data.Concrete.EfCore;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.ViewComponents.EnCokMesajlasilan
{
    public class EnCokMesajlasilanViewComponent : ViewComponent
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        MailManager _mailService = new MailManager(new MailDal());
        private UserManager<ProjeUser> _userManager;
        public EnCokMesajlasilanViewComponent(UserManager<ProjeUser> userManager)
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
                    var model = new MailModel()
                    {
                        EnCokMesajlasilanlar = _mailService.GetAll()
                        .Where(i => i.MailKimdenMailId == user.Id)
                        .OrderByDescending(i => i.MailDate)
                        .Take(5)
                        .ToList()
                    };
                    return View(model);
                }
            }
            return View();
        }
    }
}