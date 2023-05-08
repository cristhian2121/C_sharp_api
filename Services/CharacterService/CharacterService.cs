using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using net_template_web_api.Dtos.Character;
using net_template_web_api.Models;

namespace net_template_web_api.Services.CharacterService
{
   public class CharacterService : ICharacterService
   {

      private static List<Character> characters = new List<Character>() {
          new Character(),
          new Character { Name = "Cris" }
      };

      private readonly IMapper _mapper;

      public CharacterService(IMapper mapper)
      {
         this._mapper = mapper;         
      }

      public ServiceResponse<GetCharacterDto> AddCharacter(AddCharacterDto character)
      {
         var serviceResponse = new ServiceResponse<GetCharacterDto>();
         var newCharacter = _mapper.Map<Character>(character);
         newCharacter.Id = characters.Max(c => c.Id) + 1;
         characters.Add(newCharacter);
         var characterFound = characters.FirstOrDefault(c => c.Name == character.Name);

         if (characterFound is null){
            throw new Exception("Could not find character");
         }

         serviceResponse.data = _mapper.Map<GetCharacterDto>(characterFound);
         return serviceResponse;
      }

      public ServiceResponse<GetCharacterDto> GetCharacterById(int id)
      {
         var serviceResponse = new ServiceResponse<GetCharacterDto>();
         var character = characters.FirstOrDefault(c => c.Id == id);
         serviceResponse.data = _mapper.Map<GetCharacterDto>(character);
         if (character is not null){
            return serviceResponse;
         }

         throw new Exception("Could not find character");
      }

      public async Task<ServiceResponse<List<GetCharacterDto>>> GetCharacters()
      {
         var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
         serviceResponse.data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
         return serviceResponse;
      }

      public ServiceResponse<GetCharacterDto> updateCharacter(UpdateCharacterDto characterUpdated, int id)
      {
         var serviceResponse = new ServiceResponse<GetCharacterDto>();

         try
         {
            var character = characters.FirstOrDefault(c => c.Id == id); 

            if(character is null){
               throw new Exception($"Character {id} not found");
            }

            // Fill with automapper
            _mapper.Map(characterUpdated, character);
            
            // Fill object 
            // character.Name = characterUpdated.Name;
            // character.HitPoints = characterUpdated.HitPoints;
            // character.Strength = characterUpdated.Strength;
            // character.Defense = characterUpdated.Defense;
            // character.Intelligence = characterUpdated.Intelligence;
            // character.Class = characterUpdated.Class;
            
            serviceResponse.data = _mapper.Map<GetCharacterDto>(character);
         }
         catch (System.Exception ex)
         {
            serviceResponse.success = false;
            serviceResponse.message = ex.Message;
         }
         

         return serviceResponse;
      }
   
      public ServiceResponse<GetCharacterDto?> deleteCharacter(int id){
         var serviceResponse = new ServiceResponse<GetCharacterDto?>();

         try
         {
            // find by id
            var character = characters.Find(c => c.Id == id);
            if(character is null){
               throw new Exception($"Character {id} not found");
            }

            characters.Remove(character);
            serviceResponse.data = null;

         }
         catch (System.Exception ex)
         {
            serviceResponse.success = false; 
            serviceResponse.message = ex.Message;
         }

         return serviceResponse;
      }

   }
}