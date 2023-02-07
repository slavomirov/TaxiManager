namespace TaxiManager.Web.Areas.Administration.Controllers
{
    using TaxiManager.Web.ViewModels.Administration.Dashboard;

    using Microsoft.AspNetCore.Mvc;
    using TaxiManager.Services.Data.Interfaces;

    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;

        public DashboardController(ISettingsService settingsService)
        {
            this.settingsService = settingsService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel { SettingsCount = this.settingsService.GetCount(), };
            return this.View(viewModel);
        }
    }
}
