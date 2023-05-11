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
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto character);
        Task<ServiceResponse<GetCharacterDto>> updateCharacter(UpdateCharacterDto character, int id);
        Task<ServiceResponse<GetCharacterDto?>> deleteCharacter(int id);

    }
}