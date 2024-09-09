using AutoMapper;
using ContactAppApi.Data;
using ContactAppApi.DTOs;
using ContactAppApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactAppApi.Services.Contacts
{
    public class ContactService : IContactService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<ContactService> _logger;

        public ContactService(AppDbContext context, IMapper mapper, ILogger<ContactService> logger) 
        { 
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<ContactDto>?> GetContactsByUserId(int userId)
        {
            try
            {
                var contacts = await _context.Contacts
                        .Where(c => c.UserId == userId)
                        .ToListAsync();

                return _mapper.Map<IEnumerable<ContactDto>>(contacts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching contacts for userId: {UserId}", userId);
                return null;
            }
        }

        public async Task<ContactDto?> AddContact(AddContactDto contact)
        {
            try
            {
                var test = _mapper.Map<Contact>(contact);

                var newContact = _context.Contacts.Add(test);
                await _context.SaveChangesAsync();

                return _mapper.Map<ContactDto>(newContact.Entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a new contact for userId: {UserId}", contact.UserId);
                return null;
            }
        }

        public async Task<ContactDto?> UpdateContact(UpdateContactDto contact)
        {
            try
            {
                var existingContact = await _context.Contacts.FindAsync(contact.Id);
                if (existingContact == null)
                {
                    return null;
                }

                existingContact.Name = contact.Name;
                existingContact.PhoneNumber = contact.PhoneNumber;

                await _context.SaveChangesAsync();
                return _mapper.Map<ContactDto>(existingContact);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating contact with Id: {ContactId}", contact.Id);
                return null;
            }
        }

        public async Task<bool> DeleteContact(int id)
        {
            try
            {
                var contact = await _context.Contacts.FindAsync(id);
                if (contact == null)
                {
                    return false;
                }

                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting contactId: {ContactId}", id);
                return false;
            }
        }

    }
}
