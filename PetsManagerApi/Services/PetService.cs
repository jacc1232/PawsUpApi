using Microsoft.EntityFrameworkCore;
using PetsManagerApi.DataAccess;
using PetsManagerApi.Helpers.Blob;
using PetsManagerApi.Models;

namespace PetsManagerApi.Services
{
    public class PetService
    {
        private readonly PetDbContext _petDbContext;
        private readonly Blob _blob;
        public PetService(PetDbContext petDbContext, Blob blob) { 
            _petDbContext = petDbContext;
            _blob = blob;
        }

        public async Task<string>  RegisterPet(Pets pet)
        {
            try
            {
                if (pet.ImageFile != null && pet.ImageFile.Length > 0)
                {
                    pet.ImageUrl = await _blob.UploadToBlobAsync(pet.ImageFile);
                }
                _petDbContext.Pets.Add(pet);
                _petDbContext.SaveChanges();
                return "La información de la mascota se guardo correctamente";
            }
            catch (Exception ex) {
                return ex.Message;
            }


        }

        public List<Pets> GetPetsByUser(int IdUser)
        {
            return _petDbContext.Pets.Where(x => x.IdUser == IdUser).ToList();
        }

        public List<Pets> GetPetsByName(string name)
        {
            var sql = $"SELECT * FROM Pets WHERE Name = '{name}'";
            return _petDbContext.Pets.FromSqlRaw(sql).ToList();
        }

    }
}
