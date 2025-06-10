using System.ComponentModel.DataAnnotations.Schema;

namespace BRS.Basecode.Data.Entity
{
    public class User
    {
        [Column("ID")]
        public Guid Id { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("User_ID")]
        public int UserId { get; set; }

        [Column("User_Pin")]
        public int UserPin { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [Column("Date_Created")]
        public DateTime DateCreated { get; set; }
    }
}
