﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore_Study.Controllers
{
    public class BlogSingleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
