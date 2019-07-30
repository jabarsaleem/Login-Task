using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Login_Task.Models;
using Microsoft.AspNetCore.Http;

namespace Login_Task.Controllers
{
    public class MainController : Controller
    {
        Users orm = null;

        public MainController(Users _ORM)
        {
            orm = _ORM;

        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult register()
        {
            return View();

        }
        [HttpPost]
        public IActionResult register(Userlogin u)
        {
            try
            {
                u.status = "active";
                u.role = "staff";
                orm.userlogin.Add(u);
                orm.SaveChanges();
                ViewBag.Message = u.UserName + " register Successfully";
            }
            catch
            {
                ViewBag.Message = "Please try again";
            }
            return View();

        }

        [HttpGet]
        public IActionResult login()
        {
            return View();

        }

        [HttpPost]

        public IActionResult login(Userlogin u)

        {
            Userlogin user = orm.userlogin.Where(x => x.UserName == u.UserName && x.password == u.password).FirstOrDefault();
            {
                if (user==null)
                {
                    ViewBag.Message = "Please try again";
                    return View();
                }

                else
                {

                   HttpContext.Session.SetString("UserName",user.UserName);
                    HttpContext.Session.SetString("status", user.status);
                    HttpContext.Session.SetString("role", user.role);

                   

                    return RedirectToAction("Dashborad");

                   
                }
                }
            }
            
            
           

           
    
        public IActionResult Dashborad()
        {

            if(string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.role = HttpContext.Session.GetString("role");
            ViewBag.status = HttpContext.Session.GetString("status");
            return View();
        }


        public IActionResult logout()
        {

            HttpContext.Session.Clear();
           return RedirectToAction("login");
        }
    }

}