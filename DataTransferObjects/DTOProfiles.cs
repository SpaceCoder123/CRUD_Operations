using AutoMapper;
using NewProject.Models;
namespace NewProject.DataTransferObjects
{
    public class DTOProfiles: Profile
    {
        public DTOProfiles() 
        {
            CreateMap<CharacterDTO, Character>();
            CreateMap<Character, CharacterDTO>();

        }
    }
}
