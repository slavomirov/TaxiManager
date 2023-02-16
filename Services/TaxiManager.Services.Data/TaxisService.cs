namespace TaxiManager.Services.Data
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using TaxiManager.Data;
    using TaxiManager.Data.Models;
    using TaxiManager.Services.Data.Interfaces;
    using TaxiManager.Web.ViewModels.Taxis;

    public class TaxisService : ITaxisService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext dbContext;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif", "jpeg" };

        public TaxisService(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task AddAsync(TaxiAddInputModel input, string imagePath)
        {
            var car = new Car
            {
                Color = input.Color,
                ForSmokers = input.ForSmokers,
                Make = input.Make,
                Model = input.Model,
                Number = input.Number,
                OwnerId = input.UserId,
                CreatedOn = DateTime.Now,
            };

            var user = await this.userManager.FindByIdAsync(input.UserId);
            car.OwnerId = user.Id;
            user.CarId = car.Id;

            Directory.CreateDirectory($"{imagePath}/cars/");

            var image = input.Image;

            var extension = Path.GetExtension(image.FileName).TrimStart('.');

            if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
            {
                throw new Exception($"Invalid image extension {extension}");
            }

            var dbImage = new Image
            {
                CreatedOn = DateTime.Now,
                AddedByUserId = input.UserId,
                Extension = extension,
                CarId = car.Id,
            };

            car.Image = dbImage;

            var physicalPath = $"{imagePath}/cars/{dbImage.Id}.{extension}";

            // "/images/cars/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension
            dbImage.RemoteImageUrl = "/images/cars/" + dbImage.Id + "." + dbImage.Extension;
            using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
            await image.CopyToAsync(fileStream);

            await this.userManager.AddToRoleAsync(user, "Taxi");

            // await this.userManager.UpdateAsync(user); // check if needed
            await this.dbContext.AddAsync<Car>(car);
            await this.signInManager.RefreshSignInAsync(user);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
