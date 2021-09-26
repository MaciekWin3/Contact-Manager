using AutoMapper;
using Core.Data.Dtos;
using Core.Data.Repositories;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/contacts")]
    //[ApiExplorerSettings(GroupName = "Contacts")]
    [ApiController]
    public class ContactsController : Controller
    {
        private readonly IContactRepository contactsRepository;
        private readonly IMapper mapper;

        public ContactsController(IContactRepository contactsRepository, IMapper mapper)
        {
            this.contactsRepository = contactsRepository;
            this.mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetContact")]
        [ProducesResponseType(200, Type = typeof(ContactDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetContactAsync(int id)
        {
            var contact = await contactsRepository.GetAsync(id);
            return contact is not null ? Ok(contact) : NotFound();
        }

        [HttpGet(Name = "GetContacts")]
        [ProducesResponseType(200, Type = typeof(List<ContactDto>))]
        public async Task<IActionResult> GetContactListAsync()
        {
            var contacts = await contactsRepository.GetAllAsync();
            return Ok(contacts);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> CreateContactAsync([FromBody] ContactForCreationDto contact)
        {
            var contactEntity = mapper.Map<ContactForCreationDto, Contact>(contact);
            await contactsRepository.AddAsync(contactEntity);
            var contactDto = mapper.Map<Contact, ContactDto>(contactEntity);

            return CreatedAtRoute("GetContact", new { id = contactDto.Id }, contactDto);

        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> UpdateContactAsync(int id, [FromBody] ContactForUpdateDto contactForUpdateDto)
        {
            var contact = await contactsRepository.GetAsync(id);
            var updatedContact = mapper.Map(contactForUpdateDto, contact);
            await contactsRepository.UpdateAsync(updatedContact);
            var updatedContactDto = mapper.Map<Contact, ContactForUpdateDto>(updatedContact);
            return Ok(updatedContactDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contactToDelete = await contactsRepository.GetAsync(id);
            if (contactToDelete is null)
            {
                return NotFound();
            }
            await contactsRepository.DeleteAsync(contactToDelete);
            return NoContent();
        }
    }
}
