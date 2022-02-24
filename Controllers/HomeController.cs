using Microsoft.AspNetCore.Mvc;
using Mission7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;
        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index()
        {
            var myVar = repo.Books.ToList();

            return View(myVar);
        }
    }
}
