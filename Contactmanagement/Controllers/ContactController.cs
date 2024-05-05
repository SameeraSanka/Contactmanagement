using Contactmanagement.Data;
using Contactmanagement.Models;
using Contactmanagement.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contactmanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ApplicationDbContaxt _dbContext;
        public ContactController(ApplicationDbContaxt dbContaxt)
        {
            _dbContext = dbContaxt;
        }

        [HttpGet]
        public IActionResult getAllContacts()
        {
            var contacts = _dbContext.Contacts.ToList();

            return Ok(contacts);
        }

        [HttpPost]
        public IActionResult addContacts(AddContactRequestDTO addContactRequestDTO)
        {
            var domainModelContact = new Contact
            {
                Id = Guid.NewGuid(),
                Name = addContactRequestDTO.Name,
                Email = addContactRequestDTO.Email, 
                Phone = addContactRequestDTO.Phone,
                Favorite = addContactRequestDTO.Favorite,
            };
            _dbContext.Contacts.Add(domainModelContact);
            _dbContext.SaveChanges();

            return Ok(domainModelContact);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteContacts(Guid id)
        {
            var contact = _dbContext.Contacts.Find(id);
            if (contact is not null)
            {
                _dbContext.Contacts.Remove(contact);
                _dbContext.SaveChanges();
            }
            return Ok();
        }
    }
}
