using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<Character[]> Get() {
            var characters = _characterService.GetCharacters();
            return Ok(characters);
        }

        [HttpGet("{id}")]
        public ActionResult<Character> GetById(int id) {
            var character = _characterService.GetCharacterById(id);
            return Ok(character);
        }

        [HttpPost]
        public ActionResult<Character> Create(Character character) {
            _characterService.AddCharacter(character);
            return Ok();
        }
    }
}