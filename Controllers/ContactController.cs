using ContactAppApi.Data;
using ContactAppApi.DTOs;
using ContactAppApi.Models;
using ContactAppApi.Services.Contacts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactAppApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IContactService _contactService;

        public ContactController(ILogger<ContactController> logger, IContactService contactService)
        {
            _logger = logger;
            _contactService = contactService;
        }

        [HttpGet("GetContacts/{userId}")]
        public async Task<IActionResult> GetContacts(int userId)
        {
            var contacts = await _contactService.GetContactsByUserId(userId);

            if (contacts == null || !contacts.Any())
            {
                _logger.LogWarning("No contacts found for userId {UserId}", userId);
                return NotFound();
            }

            return Ok(contacts);
        }

        [HttpPost("AddContact")]
        public async Task<IActionResult> AddContact(AddContactDto contact)
        {
            _logger.LogInformation("Received request to add a new contact for user Id: {UserId}", contact.UserId);

            var newContact = await _contactService.AddContact(contact);

            if (newContact == null)
            {
                return StatusCode(500, new { message = "An error occurred while adding the contact." });
            }

            return Ok(newContact);
        }

        [HttpPut("UpdateContact")]
        public async Task<IActionResult> UpdateContact(UpdateContactDto contact)
        {
            _logger.LogInformation("Received request to update contact with Id: {Id}", contact.Id);

            var result = await _contactService.UpdateContact(contact);

            if(result == null)
            {
                return NotFound(new { message = "Contact update failed." });
            }

            return Ok(result);
        }

        [HttpDelete("DeleteContact/{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            _logger.LogInformation("Received request to delete contact with Id: {Id}", id);

            var success = await _contactService.DeleteContact(id);

            if (!success)
            {
                return NotFound(new { message = "Contact delete failed." });
            }

            return Ok();
        }
    }
}
