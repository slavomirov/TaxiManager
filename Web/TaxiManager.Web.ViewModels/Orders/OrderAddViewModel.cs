namespace TaxiManager.Web.ViewModels.Orders
{
    public class OrderAddViewModel
    {
        public string UserId { get; set; }

        public string TaxiId { get; set; }

        public string Location { get; set; }

        public string Destination { get; set; }

        public double Kilometers { get; set; }

    }
}
