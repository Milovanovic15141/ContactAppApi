using ContactAppApi.Models;

namespace ContactAppApi.DTOs
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
