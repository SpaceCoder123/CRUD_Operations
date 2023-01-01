using NewProject.DataTransferObjects;
using NewProject.Models;
namespace NewProject.Services
{
    public interface ICharacterService
    {

        public Task<ServiceResponse<List<CharacterDTO>>> GetAllCharacters();
        public Task<ServiceResponse<CharacterDTO>> GetSingle(int id);
        public Task<ServiceResponse<List<CharacterDTO>>> ModifySingle(CharacterDTO Char,int id);
        public Task<ServiceResponse<List<CharacterDTO>>> AddCharacter (CharacterDTO Char);
        public Task<ServiceResponse<List<CharacterDTO>>> DeleteCharacter(int id);
    }
}
