namespace TaxiManager.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class OrdersController : BaseController
    {

        public OrdersController()
        {

        }

        public IActionResult New()
        {
            return this.View();
        }

    }
}
