using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using net_template_web_api.Dtos.Character;
using net_template_web_api.Models;

namespace net_template_web_api.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetCharacters();
        ServiceResponse<GetCharacterDto> GetCharacterById(int id);
        ServiceResponse<GetCharacterDto> AddCharacter(AddCharacterDto character);
        ServiceResponse<Character> updateCharacter(Character character, int id);

    }
}