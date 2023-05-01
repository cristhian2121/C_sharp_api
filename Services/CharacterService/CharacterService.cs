using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using net_template_web_api.Models;

namespace net_template_web_api.Services.CharacterService
{
   public class CharacterService : ICharacterService
   {

        private static List<Character> characters = new List<Character>() {
            new Character(),
            new Character { Name = "Cris" }
        };

      public void AddCharacter(Character character)
      {
         characters.Add(character);
         return;
      }

      public Character GetCharacterById(int id)
      {
         var character = characters.FirstOrDefault(c => c.Id == id);
         if (character is not null){
            return character;
         }

         throw new Exception("Could not find character");
      }

      public List<Character> GetCharacters()
      {
         return characters;
      }

      public void updateCharacter(Character character, int id)
      {
         throw new NotImplementedException();
      }
   }
}