using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Refactoring.Web.Models;
using static Refactoring.Web.Services.Helpers.DistrictHelper;

namespace Refactoring.Web.Controllers
{
   //expression bodied constructor
   //class Example1
   //{
   //   public Example1()
   //   {
   //      Console.WriteLine("Expression-bodied constructor");
   //   }
   //}
   //
   //public class Example2
   //{
   //   public Example2() => Console.WriteLine("Expression-bodied constructor");
   //}

}
public class HomeController : Controller
{
   private readonly ILogger<HomeController> _logger;

   public HomeController(ILogger<HomeController> logger)
   {
      _logger = logger;
   }

   public IActionResult Index()
   {
      _logger.LogDebug("Index loaded");
      var viewModel = new OrderFormModel
      {
         Districts = District.StandardDistricts.Select(d => new SelectListItem
         {
            Value = d.ToLower(),
            Text = d
         })
      };
      return View(viewModel);
   }

   [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
   public IActionResult Error()
   {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
   }
}
