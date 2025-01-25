using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetsManagerApi.Models
{
    [Table("tblPets")]
    public class Pets
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPets { get; set; }
        public string NamePet { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public string OwnerName { get; set; }
        public string ImageUrl { get; set; }
        public int IdUser { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
