using AutoMapper;
using BP.API.Data.Models;
using BP.API.Models;
using System.Net.Http;

namespace BP.API.Service
{
    public class ContactService : IContactService
    {
        private readonly IMapper mapper;
        private readonly IHttpClientFactory httpClientFactory;
        public ContactService(IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            this.mapper = mapper;
            this.httpClientFactory = httpClientFactory;
        }

        public ContactDTO GetContactById(int id)
        {
            ContactDTO result = new();

            // Get value from Db
            Contact dbContact = GetDummyContact();

            var client = httpClientFactory.CreateClient("GarantiApi");

            //ContactDTO result = mapper.Map<ContactDTO>(dbContact); // Diğer Kullanım

            mapper.Map(dbContact, result);

            return result;

        }

        private Contact GetDummyContact()
        {
            return new Contact()
            {
                Id = 1,
                FirstName = "Çağlar",
                LastName = "KARABACAK"
            };
        }
    }
}
