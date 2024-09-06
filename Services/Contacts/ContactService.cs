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

        public ContactService(AppDbContext context, IMapper mapper) 
        { 
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContactDto>> GetContactsByUserId(int userId)
        {
            var contacts =  await _context.Contacts
                .Where(c => c.UserId == userId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ContactDto>>(contacts);
        }

        public async Task<ContactDto> AddContact(AddContactDto contact)
        {
            var test = _mapper.Map<Contact>(contact);

            var newContact = _context.Contacts.Add(test);
            await _context.SaveChangesAsync();

            return _mapper.Map<ContactDto>(newContact.Entity);
        }

        public async Task<ContactDto> UpdateContact(UpdateContactDto contact)
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

        public async Task<bool> DeleteContact(int id)
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

    }
}
