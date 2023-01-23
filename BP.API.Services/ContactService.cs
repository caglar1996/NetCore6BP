using AutoMapper;
using BP.API.Data.Models;
using BP.API.Models;

namespace BP.API.Service
{
    public class ContactService : IContactService
    {
        private readonly IMapper mapper;
        public ContactService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public ContactDTO GetContactById(int id)
        {
            ContactDTO result = new();

            // Get value from Db
            Contact dbContact = GetDummyContact();

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
