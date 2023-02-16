namespace TaxiManager.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using TaxiManager.Services.Data.Interfaces;
    using TaxiManager.Web.ViewModels.Taxis;

    public class TaxisController : BaseController
    {
        private readonly ITaxisService taxisService;
        private readonly IWebHostEnvironment environment;

        public TaxisController(ITaxisService taxisService, IWebHostEnvironment environment)
        {
            this.taxisService = taxisService;
            this.environment = environment;
        }

        [Authorize]
        public IActionResult Add()
        {
            if (this.User.IsInRole("Taxi"))
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddAsync(TaxiAddInputModel input)
        {
            if (this.User.IsInRole("Taxi"))
            {
                return this.Redirect("/");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != null)
            {
                input.UserId = userId;
            }

            await this.taxisService.AddAsync(input, $"{this.environment.WebRootPath}/images");


            this.TempData["Message"] = "You are Taxi now!"; // not finished
            return this.Redirect("/");
        }
    }
}
