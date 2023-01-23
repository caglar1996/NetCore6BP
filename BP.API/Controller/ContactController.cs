using BP.API.Models;
using BP.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace BP.API.Controller
{
    [ApiController]
    [Route("[controller]")]
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
        public ContactDTO GetContactById(int id)
        {
            return contactService.GetContactById(id);
        }
    }
}
