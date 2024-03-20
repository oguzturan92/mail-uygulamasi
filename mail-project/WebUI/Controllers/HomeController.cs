using System.Diagnostics;
using Business.Concrete;
using Data.Concrete.EfCore;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        MailManager _mailService = new MailManager(new MailDal());
        private UserManager<ProjeUser> _userManager;
        public HomeController(UserManager<ProjeUser> userManager)
        {
            _userManager = userManager;
        }

        // METOTLAR ------------------------------------------------
        public async Task<IActionResult> Index(int page = 1)
        {
            const int pageSize = 10;
            ViewBag.active1 = "active";
            var loginUser = User.Identity.Name;
            if (loginUser != null)
            {
                var user = await _userManager.FindByNameAsync(loginUser);
                if (user != null)
                {
                    var model = new MailModel()
                    {
                        PageInfo = new PageInfoModel(){
                            TotalItems = _mailService.GetAll().Where(i => i.MailKimeMailName.ToLower() == user.Email.ToLower() && !i.MailTrash).Count(),
                            CurrentPage = page,
                            ItemsPerPage = pageSize
                        },
                        Mails = _mailService.GetAll().Where(i => i.MailKimeMailName.ToLower() == user.Email.ToLower() && !i.MailTrash).OrderByDescending(i => i.MailDate).ToList(),
                        ToplamAdet = _mailService.GetAll().Where(i => i.MailKimeMailName.ToLower() == user.Email.ToLower() && !i.MailTrash).OrderByDescending(i => i.MailDate).ToList().Count()
                    };
                    return View(model);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult NewMail(int? id)
        {
            if (id != null)
            {
                var taslak = _mailService.GetById((int)id);
                if (taslak != null)
                {
                    var model = new MailModel()
                    {
                        MailId = taslak.MailId,
                        MailKimeMailName = taslak.MailKimeMailName,
                        MailSubject = taslak.MailSubject,
                        MailContent = taslak.MailContent,
                    };
                    return View(model);
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewMail(MailModel model)
        {
            var loginUser = User.Identity.Name;
            if (loginUser != null)
            {
                var user = await _userManager.FindByNameAsync(loginUser);
                if (user != null)
                {
                    var mail = new Mail()
                    {
                        MailKimdenMailId = user.Id,
                        MailKimeMailName = model.MailKimeMailName.ToLower(),
                        MailSubject = model.MailSubject,
                        MailContent = model.MailContent,
                        MailDate = DateTime.Now,
                        MailRead = false,
                        MailImportant = false,
                        MailDraft = false,
                        MailTrash = false,
                    };
                    _mailService.Create(mail);
                    
                    var taslakSil = _mailService.GetById(model.MailId);
                    if (taslakSil != null)
                    {
                        _mailService.Delete(taslakSil);
                    }

                    TempData["icon"] = "success";
                    TempData["title"] = "Gönderildi.";
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GidenMail(int page = 1)
        {
            const int pageSize = 10;
            ViewBag.active2 = "active";
            var loginUser = User.Identity.Name;
            if (loginUser != null)
            {
                var user = await _userManager.FindByNameAsync(loginUser);
                if (user != null)
                {
                    var model = new MailModel()
                    {
                        PageInfo = new PageInfoModel(){
                            TotalItems = _mailService.GetAll().Where(i => i.MailKimdenMailId == user.Id && !i.MailDraft && !i.MailTrash).Count(),
                            CurrentPage = page,
                            ItemsPerPage = pageSize
                        },
                        Mails = _mailService.GetAll().Where(i => i.MailKimdenMailId == user.Id && !i.MailDraft && !i.MailTrash).OrderByDescending(i => i.MailDate).ToList(),
                        ToplamAdet = _mailService.GetAll().Where(i => i.MailKimdenMailId == user.Id && !i.MailDraft && !i.MailTrash).ToList().Count()
                    };
                    return View(model);
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> OnemliMail(int page = 1)
        {
            const int pageSize = 10;
            ViewBag.active3 = "active";
            var loginUser = User.Identity.Name;
            if (loginUser != null)
            {
                var user = await _userManager.FindByNameAsync(loginUser);
                if (user != null)
                {
                    var model = new MailModel()
                    {
                        PageInfo = new PageInfoModel(){
                            TotalItems = _mailService.GetAll().Where(i => (i.MailKimeMailName.ToLower() == user.Email.ToLower() || i.MailKimdenMailId == user.Id) && i.MailImportant && !i.MailTrash).Count(),
                            CurrentPage = page,
                            ItemsPerPage = pageSize
                        },
                        Mails = _mailService.GetAll().Where(i => (i.MailKimeMailName.ToLower() == user.Email.ToLower() || i.MailKimdenMailId == user.Id) && i.MailImportant && !i.MailTrash).OrderByDescending(i => i.MailDate).ToList(),
                        ToplamAdet = _mailService.GetAll().Where(i => (i.MailKimeMailName.ToLower() == user.Email.ToLower() || i.MailKimdenMailId == user.Id) && i.MailImportant && !i.MailTrash).ToList().Count(),
                        UserId = user.Id
                    };
                    return View(model);
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult OnemliMail(int id, string x)
        {
            var mail = _mailService.GetById(id);
            if (mail != null)
            {
                if (mail.MailImportant)
                {
                    mail.MailImportant = false;
                } else
                {
                    mail.MailImportant = true;
                }
                _mailService.Update(mail);
                return RedirectToAction(x, "Home");
            }
            TempData["iconOK"] = "warning";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction(x, "Home");
        }

        [HttpGet]
        public async Task<IActionResult> TaslakMail(int page = 1)
        {
            const int pageSize = 10;
            ViewBag.active4 = "active";
            var loginUser = User.Identity.Name;
            if (loginUser != null)
            {
                var user = await _userManager.FindByNameAsync(loginUser);
                if (user != null)
                {
                    var model = new MailModel()
                    {
                        PageInfo = new PageInfoModel(){
                            TotalItems = _mailService.GetAll().Where(i => i.MailKimdenMailId == user.Id && i.MailDraft && !i.MailTrash).Count(),
                            CurrentPage = page,
                            ItemsPerPage = pageSize
                        },
                        Mails = _mailService.GetAll().Where(i => i.MailKimdenMailId == user.Id && i.MailDraft && !i.MailTrash).OrderByDescending(i => i.MailDate).ToList(),
                        ToplamAdet = _mailService.GetAll().Where(i => i.MailKimdenMailId == user.Id && i.MailDraft && !i.MailTrash).ToList().Count()
                    };
                    return View(model);
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TaslakMail(MailModel model)
        {
            var loginUser = User.Identity.Name;
            if (loginUser != null)
            {
                var user = await _userManager.FindByNameAsync(loginUser);
                if (user != null)
                {
                    var mail = new Mail()
                    {
                        MailKimdenMailId = user.Id,
                        MailKimeMailName = model.MailKimeMailName.ToLower(),
                        MailSubject = model.MailSubject,
                        MailContent = model.MailContent,
                        MailDate = DateTime.Now,
                        MailRead = false,
                        MailImportant = false,
                        MailDraft = true,
                        MailTrash = false,
                    };
                    _mailService.Create(mail);
                    var values = JsonConvert.SerializeObject(mail);
                    return Json(values);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SilinmisMail(int page = 1)
        {
            const int pageSize = 10;
            ViewBag.active5 = "active";
            var loginUser = User.Identity.Name;
            if (loginUser != null)
            {
                var user = await _userManager.FindByNameAsync(loginUser);
                if (user != null)
                {
                    var model = new MailModel()
                    {
                        PageInfo = new PageInfoModel(){
                            TotalItems = _mailService.GetAll().Where(i => (i.MailKimdenMailId == user.Id || i.MailKimeMailName.ToLower() == user.Email.ToLower()) && i.MailTrash).Count(),
                            CurrentPage = page,
                            ItemsPerPage = pageSize
                        },
                        Mails = _mailService.GetAll().Where(i => (i.MailKimdenMailId == user.Id || i.MailKimeMailName.ToLower() == user.Email.ToLower()) && i.MailTrash).OrderByDescending(i => i.MailDate).ToList(),
                        ToplamAdet = _mailService.GetAll().Where(i => (i.MailKimdenMailId == user.Id || i.MailKimeMailName.ToLower() == user.Email.ToLower()) && i.MailTrash).OrderByDescending(i => i.MailDate).ToList().Count(),
                        UserId = user.Id
                    };
                    return View(model);
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult SilinmisMail(int id, string y)
        {
            var mail = _mailService.GetById(id);
            if (mail != null)
            {
                mail.MailTrash = true;
                _mailService.Update(mail);
                TempData["icon"] = "success";
                TempData["title"] = "Silinmiş olarak işaretlendi.";
                return RedirectToAction(y, "Home");
            }
            TempData["iconOK"] = "warning";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction(y, "Home");
        }

        [HttpPost]
        public IActionResult IptalSilinmisMail(int id, string y)
        {
            var mail = _mailService.GetById(id);
            if (mail != null)
            {
                mail.MailTrash = false;
                _mailService.Update(mail);
                TempData["icon"] = "success";
                TempData["title"] = "Mail geri yüklendi.";
                return RedirectToAction(y, "Home");
            }
            TempData["iconOK"] = "warning";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction(y, "Home");
        }

        public IActionResult DeleteMail(int id)
        {
            var mail = _mailService.GetById(id);
            if (mail != null)
            {
                _mailService.Delete(mail);
                TempData["icon"] = "success";
                TempData["title"] = "Mail silindi.";
                return RedirectToAction("SilinmisMail", "Home");
            }
            TempData["iconOK"] = "warning";
            TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public async Task<IActionResult> DetailMail(int id)
        {
            var loginUser = User.Identity.Name;
            if (loginUser != null)
            {
                var user = await _userManager.FindByNameAsync(loginUser);
                if (user != null)
                {
                    var mail = _mailService.GetById((int)id);
                    if (mail != null)
                    {
                        if (mail.MailKimeMailName.ToLower() == user.Email.ToLower() && !mail.MailRead)
                        {
                            mail.MailRead = true;
                            _mailService.Update(mail);
                        }

                        var model = new MailModel()
                        {
                            Mail = mail
                        };
                        return View(model);
                    }
                }
            }
            return View();
        }
    }
}