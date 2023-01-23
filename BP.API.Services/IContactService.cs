using BP.API.Models;

namespace BP.API.Service
{
    public interface IContactService
    {
        public ContactDTO GetContactById(int id);
    }
}
