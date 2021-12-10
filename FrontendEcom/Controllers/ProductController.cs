using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendEcom.Controllers
{
    public class ProductController : Controller
    {

        public IActionResult ProductList()
        {
            return View();
        }
    }
}
