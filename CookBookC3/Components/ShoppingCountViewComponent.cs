﻿using CookBookASP.Controllers;
using CookBookASP.Models;
using CookBookASP.Session;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookASP.Components
{
    public class ShoppingCountViewComponent : ViewComponent
    {
        private SessionManager<Purchase> sessionManager;

        public ShoppingCountViewComponent(SessionManager<Purchase> sessionManager)
        {
            this.sessionManager = sessionManager;
        }

        public IViewComponentResult Invoke()
        {

            var x = sessionManager.GetItem().Positions.Count();
            return View(x);
        }
    }
}
