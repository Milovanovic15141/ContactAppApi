using System.ComponentModel.DataAnnotations.Schema;

namespace ContactAppApi.Models
{
    public class Contact
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("userid")]
        public int UserId { get; set; }

        [Column("name")]
        public string Name { get; set; } = null!;

        [Column("phonenumber")]
        public string PhoneNumber { get; set; } = null!;

        public User User { get; set; }
    }
}
