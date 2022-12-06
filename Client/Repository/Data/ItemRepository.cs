using Client.Base;
using WebAPi.Models;

namespace Client.Repository.Data
{
    public class ItemRepository : GeneralRepository<Item, int>
    {
        private readonly Address address;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;
        public ItemRepository(Address address, string request = "https://localhost:7095/API/Items") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }

    }
}
