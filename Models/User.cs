using System.ComponentModel.DataAnnotations.Schema;

namespace ContactAppApi.Models
{
    public class User
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("username")]
        public string Username { get; set; } = null!;

        [Column("password")]
        public string Password { get; set; } = null!;
    }
}
