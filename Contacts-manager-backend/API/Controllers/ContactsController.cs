using Core.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/contacts")]
    [ApiExplorerSettings(GroupName = "Contacts")]
    [ApiController]
    public class ContactsController : Controller
    {
        private readonly IContactsRepository contactsRepository;

        public ContactsController(IContactsRepository contactsRepository)
        {
            this.contactsRepository = contactsRepository;
        }


    }
}
