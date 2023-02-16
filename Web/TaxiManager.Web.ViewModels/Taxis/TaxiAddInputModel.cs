namespace TaxiManager.Web.ViewModels.Taxis
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class TaxiAddInputModel
    {
        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        [Display(Name = "Smoking in the car?")]
        public bool ForSmokers { get; set; }

        [Required]
        [MaxLength(6)]
        public string Number { get; set; }

        [Required]
        public IFormFile Image { get; set; }

        public string UserId { get; set; }
    }
}
