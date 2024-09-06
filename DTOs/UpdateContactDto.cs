using ContactAppApi.Models;
using System.ComponentModel.DataAnnotations;

namespace ContactAppApi.DTOs
{
    public class UpdateContactDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
