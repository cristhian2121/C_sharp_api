using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using net_template_web_api.Models;

namespace net_template_web_api.Services.CharacterService
{
    public interface ICharacterService
    {
        List<Character> GetCharacters();
        Character GetCharacterById(int id);
        void AddCharacter(Character character);
        void updateCharacter(Character character, int id);

    }
}