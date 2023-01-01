using Microsoft.AspNetCore.Mvc;
using NewProject.Models;
using NewProject.Services;
using NewProject.DataTransferObjects;
namespace NewProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class CharacterController: ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService) 
        {
            _characterService = characterService;
        }

        [HttpGet("/all")]
        public async Task<ActionResult<List<CharacterDTO>>> GetAllCharacters() {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpPut("/addChar")]
        public async Task<ActionResult<List<CharacterDTO>>> AddCharacter(CharacterDTO Char)
        {
            return Ok(await _characterService.AddCharacter(Char));
        }

        [HttpPost("/ModifyChar/{id}")]
        public async Task<ActionResult<List<CharacterDTO>>> ModifyCharacter(CharacterDTO Char,int id)
        {
            try
            {
                return Ok(await _characterService.ModifySingle(Char,id));
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/GetSingleChar/{id}")]
        public async Task<ActionResult<List<CharacterDTO>>> GetSingleChar(int id)
        {
            try
            {
                return Ok(await _characterService.GetSingle(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/DeleteChar/{id}")]
        public async Task<ActionResult<List<CharacterDTO>>> DeletChar(int id)
        {
            try
            {
                return Ok(await _characterService.DeleteCharacter(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
