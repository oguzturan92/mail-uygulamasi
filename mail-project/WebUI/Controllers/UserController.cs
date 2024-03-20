using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.EmailServis;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // DEPENCENCY INJECTION ------------------------------------------------
        private UserManager<ProjeUser> _userManager; // SignIn(Kullanıcı) işlemlerini yönetecek sınıf
        private SignInManager<ProjeUser> _signInManager; // Kullanıcıya giriş yaptıracak
        private IPasswordValidator<ProjeUser> _passwordValidator; // Şifre değiştirme işlemleri için kullanıcaz
        private IPasswordHasher<ProjeUser> _passwordHasher; // Şifre değiştirme işlemleri için kullanıcaz
        private IEmailGonder _emailGonder; // Email gönderme işlemleri için kullanıcaz
        private RoleManager<ProjeRole> _roleManager;
        public UserController(UserManager<ProjeUser> userManager,
            SignInManager<ProjeUser> signInManager,
            IPasswordValidator<ProjeUser> passwordValidator,
            IPasswordHasher<ProjeUser> passwordHasher,
            IEmailGonder emailGonder,
            RoleManager<ProjeRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordValidator = passwordValidator;
            _passwordHasher = passwordHasher;
            _emailGonder = emailGonder;
            _roleManager = roleManager;
        }

        // METOTLAR ------------------------------------------------------------

        [AllowAnonymous]
        [HttpGet]
        public IActionResult UserLogin(string ReturnUrl = null)
        {
            var model = new UserLoginModel(){
                ReturnUrl = ReturnUrl
            };
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var userSorgusu = await _userManager.FindByEmailAsync(model.Email);
                if (userSorgusu == null)
                {
                    var newRole = new ProjeRole(){Name = "Admin", NormalizedName = "ADMIN"};
                    await _roleManager.CreateAsync(newRole);

                    var user = new ProjeUser()
                    {
                        UserName = model.Email.Trim().ToLower(),
                        Email = model.Email.Trim().ToLower(),
                        UserRegisterDate = DateTime.Now,
                        EmailConfirmed = true
                    };

                    var sonuc = await _userManager.CreateAsync(user, model.Password);

                    await _userManager.AddToRoleAsync(user, newRole.Name);

                    if (sonuc.Succeeded)
                    {
                        TempData["icon"] = "success";
                        TempData["title"] = "Kullanıcı oluşturuldu. Giriş yapabilirsiniz.";
                        return RedirectToAction("UserLogin", "User");
                    } else
                    {
                        TempData["iconOK"] = "warning";
                        TempData["iconText"] = "Bir sorun oluştu. Lütfen tekrar deneyin";
                        return View(model);
                    }
                }

                if (userSorgusu != null)
                {
                    if (await _userManager.IsEmailConfirmedAsync(userSorgusu)) // Email onaylı ise
                    {
                        var passwordSorgusu = await _signInManager.PasswordSignInAsync( // Aşağıdaki bilgilerle giriş yaptır
                            userSorgusu,
                            model.Password,
                            true, // True ise tarayıcı kapandığında Cookie silinir, false ise StartUp içinde elle girdiğimiz değeri baz alır.
                            false // StartUp içindeki yanlış şifre girilmesi durumundaki hesap kilitleme ayarı kapalı. True ise açık.
                        );
                        
                        if (passwordSorgusu.Succeeded)
                        {
                            return Redirect(model.ReturnUrl ?? "~/Home/Index"); // ReturnUrl == Null ise Anasayfaya yönlendirilir.
                        } else
                        {
                            ModelState.AddModelError("Password", "Şifre hatalı.");
                        }
                    } else // Emaili onaylanmamışsa
                    {
                        ModelState.AddModelError("Email", "Lütfen email adresinizi onaylayınız.");
                    }
                } else // eMail sorgusuna uygun kullanıcı yoksa
                {
                    ModelState.AddModelError("Email", "Bu email adresine ait hesap bulunamadı.");
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> UserLogout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("UserLogin", "User");
        }

    }
}