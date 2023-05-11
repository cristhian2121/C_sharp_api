using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using net_template_web_api.Data;
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
      private readonly DataContext _context;

      public CharacterService(IMapper mapper, DataContext context)
      {
         this._context = context;
         this._mapper = mapper;
      }

      public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
      {

         var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
         var character = _mapper.Map<Character>(newCharacter);

         System.Console.WriteLine(character);

         _context.Characters.Add(character);
         await _context.SaveChangesAsync();

         if (newCharacter is null){
            throw new Exception("Could not find character");
         }

         serviceResponse.data =
            await _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();
         return serviceResponse;
      }

      public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
      {
         var serviceResponse = new ServiceResponse<GetCharacterDto>();
         var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
         serviceResponse.data = _mapper.Map<GetCharacterDto>(character);
         if (character is not null){
            return serviceResponse;
         }

         throw new Exception($"Could not find the {id} character");
      }

      public async Task<ServiceResponse<List<GetCharacterDto>>> GetCharacters()
      {
         var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
         var dbCharacters = await _context.Characters.ToListAsync();
         serviceResponse.data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
         return serviceResponse;
      }

      public async Task<ServiceResponse<GetCharacterDto>> updateCharacter(UpdateCharacterDto characterUpdated, int id)
      {
         var serviceResponse = new ServiceResponse<GetCharacterDto>();
         var character_ = _mapper.Map<Character>(characterUpdated);

         try
         {
            var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);

            if(character is null){
               throw new Exception($"Character {id} not found");
            }

            // Fill with automapper
            // _mapper.Map(characterUpdated, character);
            
            // Fill object 
            character.Name = characterUpdated.Name;
            character.HitPoints = characterUpdated.HitPoints;
            character.Strength = characterUpdated.Strength;
            character.Defense = characterUpdated.Defense;
            character.Intelligence = characterUpdated.Intelligence;
            character.Class = characterUpdated.Class;

            await _context.SaveChangesAsync();
            serviceResponse.data = _mapper.Map<GetCharacterDto>(character);
         }
         catch (System.Exception ex)
         {
            serviceResponse.success = false;
            serviceResponse.message = ex.Message;
         }
         

         return serviceResponse;
      }
   
      public async Task<ServiceResponse<GetCharacterDto?>> deleteCharacter(int id){
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