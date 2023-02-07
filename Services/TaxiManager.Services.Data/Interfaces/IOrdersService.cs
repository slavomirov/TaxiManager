namespace TaxiManager.Services.Data.Interfaces
{
    public interface IOrdersService
    {
        void New();

        void Accept(string id);

        void Decline(string id);

        void Delete(string id);
    }
}
