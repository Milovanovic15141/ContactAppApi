using ContactAppApi.Models;
using System.ComponentModel.DataAnnotations;

namespace ContactAppApi.DTOs
{
    public class AddContactDto
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public int UserId { get; set; }
    }
}
