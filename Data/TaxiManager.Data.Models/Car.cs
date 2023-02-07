namespace TaxiManager.Data.Models
{
    using System;

    using TaxiManager.Data.Common.Models;

    public class Car : BaseModel<string>
    {
        public Car()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public bool ForSmokers { get; set; }

        public string Number { get; set; }

        public Image Image { get; set; }

        public ApplicationUser Owner { get; set; }

        public string OwnerId { get; set; }
    }
}