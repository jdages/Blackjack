﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blackjack.MVC.Models;
using Blackjack.Play.Entities;

namespace Blackjack.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new HomeModel {ApiUrl = ConfigurationManager.AppSettings.Get("APIUrl")};
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public PartialViewResult AddPlayer()
        {
            return PartialView("Player");
        }

        public PartialViewResult Results(IEnumerable<ResultModel> result)
        {
            return PartialView("Result",result.ToList());
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
   
}