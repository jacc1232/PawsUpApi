using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetsManagerApi.DataAccess;
using PetsManagerApi.Helpers.Blob;
using PetsManagerApi.Models;
using PetsManagerApi.Services;

namespace PetsManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : Controller
    {
        private readonly PetService _petService;
        public PetsController(PetService petService)
        {
            _petService = petService;
        }
        [HttpPost("RegisterPet")]
        public async Task<ActionResult> RegisterPet([FromForm] Pets pets)
        {
            try
            {
                string message = string.Empty;
                if (pets == null)
                {
                    return BadRequest("Los campos son obligatorios");
                }
                else
                {
                    message = await _petService.RegisterPet(pets);
                }
                return Ok(message);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{IdUser}")]
        public async Task<ActionResult<List<Pets>>> GetPetsByUser(int IdUser)
        {
            var pets = _petService.GetPetsByUser(IdUser);
            if (pets == null)
            {
                return NotFound();
            }
            return pets;
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            var result = _petService.GetPetsByName(name);
            return Ok(result);
        }
    }
}
