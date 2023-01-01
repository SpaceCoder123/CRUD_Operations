using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewProject.Data;
using NewProject.DataTransferObjects;
using NewProject.Models;

namespace NewProject.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CharacterService(DataContext Context,IMapper mapper) 
        {
            _context = Context;
            _mapper = mapper;
        }


        public async Task<ServiceResponse<List<CharacterDTO>>> AddCharacter(CharacterDTO Char)
        {
            var NormChar = _mapper.Map<Character>(Char);
            await _context.Characters.AddAsync(NormChar);
            await _context.SaveChangesAsync();

            var DbCharactersList = await _context.Characters.ToListAsync();
            var Dboutput = DbCharactersList.Select(value => _mapper.Map<CharacterDTO>(value));
            var serviceResponse = new ServiceResponse<List<CharacterDTO>>();
            serviceResponse.Data= Dboutput.ToList();
            serviceResponse.Success = true;
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CharacterDTO>>> DeleteCharacter(int id)
        {
            var serviceResponse  = new ServiceResponse<List<CharacterDTO>>();
            var Character = await _context.Characters.FindAsync(id);
            if (Character == null)
            {
                var DbCharactersList = await _context.Characters.ToListAsync();
                var Dboutput = DbCharactersList.Select(value => _mapper.Map<CharacterDTO>(value));
                serviceResponse.Data = Dboutput.ToList();
                serviceResponse.Success = false;
                serviceResponse.Message = "No character Found, Please Enter a valid id";
                return serviceResponse;
            }
            else 
            {
                _context.Characters.Remove(Character);
                await _context.SaveChangesAsync();
                serviceResponse.Success = true;
                var DbCharactersList = await _context.Characters.ToListAsync();
                var Dboutput = DbCharactersList.Select(value => _mapper.Map<CharacterDTO>(value));
                serviceResponse.Data = Dboutput.ToList();
                return serviceResponse;
            }
            
        }

        public async Task<ServiceResponse<List<CharacterDTO>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<CharacterDTO>>();
            var DbCharactersList = await _context.Characters.ToListAsync();
            var Dboutput = DbCharactersList.Select(value => _mapper.Map<CharacterDTO>(value));
            serviceResponse.Data = Dboutput.ToList();
            serviceResponse.Success = true;
            return serviceResponse;
        }

        public async Task<ServiceResponse<CharacterDTO>> GetSingle(int id)
        {
            // map here
            var CharacterFound = await  _context.Characters.FindAsync(id);
            var FoundConvertedChar = _mapper.Map<CharacterDTO>(CharacterFound);
            var serviceResponse = new ServiceResponse<CharacterDTO>();
            if (CharacterFound == null)
            {
                serviceResponse.Data = FoundConvertedChar;
                serviceResponse.Success = false;
                serviceResponse.Message = "No character Found, Please Enter a valid id";
                return serviceResponse;
            }
            else
            {
                serviceResponse.Success = true;
                serviceResponse.Data = FoundConvertedChar;
                return serviceResponse;
            }

        }

        public async Task<ServiceResponse<List<CharacterDTO>>> ModifySingle(CharacterDTO Char, int id)
        {
            var Character = await _context.Characters.FindAsync(id);
            var serviceResponse = new ServiceResponse<List<CharacterDTO>>();
            if (Character == null)
            {
                var DbCharactersList = await _context.Characters.ToListAsync();
                var Dboutput = DbCharactersList.Select(value => _mapper.Map<CharacterDTO>(value));
                serviceResponse.Data = Dboutput.ToList();
                serviceResponse.Success = false;
                serviceResponse.Message = "No character Found, Please Enter a valid id";
                return serviceResponse;
            }
            else
            {
                Character.FirstName = Char.FirstName;
                Character.LastName = Char.LastName;
                Character.Location = Char.Location;
                Character.CharacterName = Char.CharacterName;
                await _context.SaveChangesAsync();
                serviceResponse.Success = true;
                var DbCharactersList = await _context.Characters.ToListAsync();
                var Dboutput = DbCharactersList.Select(value => _mapper.Map<CharacterDTO>(value));
                serviceResponse.Data = Dboutput.ToList();
                return serviceResponse;
            }
        }
    }
}
