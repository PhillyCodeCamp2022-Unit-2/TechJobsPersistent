using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            // create an instance of the AddEmployerViewModel
            // then pass it to the view
            return View();
        }

        public IActionResult ProcessAddEmployerForm()
        {
            return View();
        }

        public IActionResult About(int id)
        {
            return View();
        }
    }
}
