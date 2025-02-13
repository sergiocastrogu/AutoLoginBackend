using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLogin.Domain.Entities
{
    public class User
    {
        [Key]
        [Column("user_id")]
        public long Id { get; set; }

        [Column("person_id")]
        [Required]
        public long PersonId { get; set; }

        [Column("user_name")]
        [Required]
        public string UserName { get; set; }

        [Column("password")]
        [Required]
        public string Password { get; set; }

        [Column("status")]
        [Required]
        public bool Status { get; set; }


        public User(long id, long personId, string userName, string password, bool status)
        {
            Id = id;
            PersonId = personId;
            UserName = userName;
            Password = BCrypt.Net.BCrypt.HashPassword(password, 12);
            Status = status;
        }

        public bool validatePassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Password);
        }


    }
}
