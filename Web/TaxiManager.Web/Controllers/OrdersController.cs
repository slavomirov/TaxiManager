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
            if (this.User.IsInRole("Taxi"))
            {
                return this.Redirect("/");
            }

            return this.View();
        }

    }
}
