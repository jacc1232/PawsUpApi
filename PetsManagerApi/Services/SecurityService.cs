using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PetsManagerApi.DataAccess;
using PetsManagerApi.Models;

namespace PetsManagerApi.Services
{
    public class SecurityService
    {
        private readonly PetDbContext _petDbContext;
        public SecurityService(PetDbContext petDbContext) {
            _petDbContext = petDbContext;
        }

        public Users GetLogin(string email, string password)
        {
            password = EncryptPassword(password);
            var user = _petDbContext.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
            return user;
        }
        public string EncryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("La contraseña no puede estar vacía.");

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                StringBuilder hashString = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hashString.Append(b.ToString("x2"));
                }

                return hashString.ToString();
            }
        }
    }
}
