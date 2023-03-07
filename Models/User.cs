using System.ComponentModel.DataAnnotations.Schema;

namespace HomeWork_4.Models
{
    [Table("users")]
    public class User
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("firstname")]
        public string? FirstName { get; set; }

        [Column("lastname")]
        public string? LastName { get; set; }

        [Column("middlename")]
        public string? MiddleName { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("phone")]
        public string? Phone { get; set; }

        public override string ToString()
        {
            return @$"ID:{Id} || {LastName} {FirstName} {MiddleName}, Email:{Email}, Phone:{Phone}";
        }
    }
}
