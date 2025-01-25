using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetsManagerApi.DataAccess;
using PetsManagerApi.Models;
using PetsManagerApi.Services;

namespace PetsManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : Controller
    {
        private readonly SecurityService _securityService;
        public SecurityController(SecurityService securityService)
        {
            _securityService = securityService;
        }
        [HttpGet("{email}/{password}")]
        public async Task<ActionResult<Users>> Login(string email,string password)
        {
            Users user = _securityService.GetLogin(email, password);
            if (user == null) { 
                return NotFound();
            }
            return user;
        }
    }


}
