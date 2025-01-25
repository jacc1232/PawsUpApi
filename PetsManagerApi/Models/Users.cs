using System.ComponentModel.DataAnnotations.Schema;

namespace PetsManagerApi.Models
{
    [Table("tblUsers")]
    public class Users
    {
        public int IdUser { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }
}
