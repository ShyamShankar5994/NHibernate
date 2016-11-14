using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLogin.Models;

namespace MvcLogin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(login lg)
        {
            if (ModelState.IsValid)
            {
                using (NhibernateMVCEntities nh = new NhibernateMVCEntities())
                {
                    var log=nh.Users_tbl.Where( a=> a.UserName.Equals(lg.username) && a.Password.Equals(lg.password)).FirstOrDefault();
                    if(log != null)
                    {
                        return RedirectToAction("UsersHome","Home");
                    }
                    else
                    {
                        Response.Write("<script> alert('Invalid Password'</script>)");
                    }
                }
            }
            return View();
        }

        public ActionResult UsersHome()
        {
            return View();
        }
    }
}