﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsoEnaip2018_ProjectManagement.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            var v = View(); 

            return View();
        }
    }
}
