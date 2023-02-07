namespace TaxiManager.Services.Data.Interfaces
{
    using System.Threading.Tasks;

    using TaxiManager.Web.ViewModels.Taxis;

    public interface ITaxisService
    {
        Task AddAsync(TaxiAddInputModel input, string imagePath);
    }
}
