using System.ComponentModel.DataAnnotations;
using System.Data;

namespace RACEDAY_PART3_.Models.Entites
{
    public class Users
    {

        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }

    }
}
