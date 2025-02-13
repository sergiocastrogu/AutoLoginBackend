using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLogin.Domain.Entities
{
    public class Person
    {

        [Key]
        [Column("person_id")]
        public long Id { get; set; }

        [Required]
        [Column("identification")]
        public string Identification { get; set; }

        [Required]
        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("second_name")]
        public string? SecondName { get; set; }

        [Required]
        [Column("first_last_name")]
        public string LastName { get; set; }

        [Column("second_last_name")]
        public string? SecondLastName { get; set; }

        [Column("phone")]
        public string? Phone {  get; set; }

        [Required]
        [Column("email")]
        public string Email { get; set; }

    }
}
