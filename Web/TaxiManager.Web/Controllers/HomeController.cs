namespace TaxiManager.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TaxiManager.Data;
    using TaxiManager.Data.Models;
    using TaxiManager.Web.ViewModels;

    public class HomeController : BaseController
    {
        public HomeController()
        {
        }


        public  IActionResult Index()
        {
            return this.View();
        }

        [Authorize(Roles = "Taxi")]
        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
