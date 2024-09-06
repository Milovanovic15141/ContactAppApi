using ContactAppApi.DTOs;
using ContactAppApi.Models;

namespace ContactAppApi.Services.Contacts
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDto>> GetContactsByUserId(int userId);
        Task<ContactDto> AddContact(AddContactDto contact);
        Task<ContactDto> UpdateContact(UpdateContactDto contact);
        Task<bool> DeleteContact(int id);
    }
}
