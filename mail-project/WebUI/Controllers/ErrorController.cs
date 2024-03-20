using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Error404(int code)
        {
            return View();
        }
    }
}