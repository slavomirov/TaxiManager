namespace TaxiManager.Web.Controllers
{
    using System.Diagnostics;

    using TaxiManager.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using TaxiManager.Data;
    using Microsoft.AspNetCore.Identity;
    using TaxiManager.Data.Models;
    using System.Security.Claims;
    using System.Linq;
    using System.Threading.Tasks;
    using System;

    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
        }


        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = this.dbContext.Users.Where(x => x.Id == userId).FirstOrDefault();
            var idk = this.userManager.IsInRoleAsync(user, "Taxi");
            await idk;
            var isInTaxiRole = idk.Result;

            this.Response.Cookies.Append("taxiRole", isInTaxiRole.ToString().ToLower());
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
