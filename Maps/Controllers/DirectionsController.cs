﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maps.Controllers
{
    public class DirectionsController : Controller
    {
        // GET: Directions
        public ActionResult Index()
        {
            return View();
        }
    }
}