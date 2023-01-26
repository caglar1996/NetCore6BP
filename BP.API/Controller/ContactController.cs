using BP.API.Models;
using BP.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace BP.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IContactService contactService;
        public ContactController(IConfiguration configuration, IContactService contactService)
        {
            this.configuration = configuration;
            this.contactService = contactService;
        }



        [HttpGet]
        public string Get()
        {
            return configuration["ConnectionString"];
        }

        [HttpGet("{id}")]
        [ResponseCache(Duration = 10)]
        public ContactDTO GetContactById(int id)
        {
            return contactService.GetContactById(id);
        }

        [HttpPost]
        [Route("NewContact")]
        public ContactDTO CreateContact(ContactDTO model)
        {
            return model;
        }

    }
}
