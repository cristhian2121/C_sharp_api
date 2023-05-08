using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using net_template_web_api.Dtos.Character;
using net_template_web_api.Services.CharacterService;
// also we can use global using

namespace net_template_web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactersController : ControllerBase
    {        

        private readonly ICharacterService _characterService;

        public CharactersController(ICharacterService characterService)
        {
            this._characterService = characterService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto[]>>> Get() {
            var characters = await _characterService.GetCharacters();
            return Ok(characters);
        }

        [HttpGet("{id}")]
        public ActionResult<ServiceResponse<GetCharacterDto>> GetById(int id) {
            var character = _characterService.GetCharacterById(id);
            return Ok(character);
        }

        [HttpPost]
        public ActionResult<ServiceResponse<Character>> Create(AddCharacterDto character) {
            _characterService.AddCharacter(character);
            return Ok();
        }
    }
}