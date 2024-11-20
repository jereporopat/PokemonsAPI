using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Helpers;
using PokemonAPI.Models;
using PokemonAPI.Services;
using PokemonAPI.Helpers;

namespace PokemonAPI.Controllers
{
    [ApiController]
    [Route("api/pokemon/{pokemonId}/[controller]")]
    public class HabilidadController :ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Habilidad>> GetHabilidades(int pokemonId)
        {
            var pokemon = PokemonDataStore.Current.Pokemons.FirstOrDefault(x => x.Id == pokemonId);

            if (pokemon == null){
                return NotFound(Mensajes.Pokemon.NotFound);
            }
            return Ok(pokemon.Habilidades);
        }
        [HttpGet("{habilidadId}")]
        public ActionResult<Habilidad> GetHabilidad(int pokemonId, int habilidadId)
        { 
            var pokemon = PokemonDataStore.Current.Pokemons.FirstOrDefault(x => x.Id == pokemonId);

            if (pokemon == null){
                return NotFound(Mensajes.Pokemon.NotFound);
            }
            var habilidad = pokemon.Habilidades?.FirstOrDefault(h => h.Id == pokemonId);
            if (habilidad == null){
                return NotFound(Mensajes.Habilidad.NotFound);
            }
            return Ok(habilidad);
        }

        [HttpPost]
        public ActionResult<Habilidad> PostHabilidad(int pokemonId, HabilidadInsert habilidad)
        {
            var pokemon = PokemonDataStore.Current.Pokemons.FirstOrDefault(x => x.Id == pokemonId);

            if (pokemon == null){
                return NotFound(Mensajes.Pokemon.NotFound);
            }    
            var habilidadExistente = pokemon.Habilidades?.FirstOrDefault(h => h.Nombre == habilidad.Nombre);
            if (habilidadExistente != null){
                return BadRequest (Mensajes.Habilidad.NombreExistente);
            }
            var maxHabilidad = pokemon.Habilidades.Max(h => h.Id);

            var habilidadNueva = new Habilidad(){
                Id = maxHabilidad + 1,
                Nombre = habilidad.Nombre,
                Potencia = habilidad.Potencia
            };
            pokemon.Habilidades.Add(habilidadNueva);

            return CreatedAtAction(nameof(GetHabilidad), new { pokemonId = pokemonId, habilidadNueva.Id },
            habilidadNueva);
        }
        [HttpPut("{habilidadId}")]
        public ActionResult<Habilidad> PutHabilidad(int pokemonId, int habilidadId, HabilidadInsert habilidad)
        {
            //VALIDA
            var pokemon = PokemonDataStore.Current.Pokemons.FirstOrDefault(x => x.Id == pokemonId);

            if (pokemon == null){
                return NotFound(Mensajes.Pokemon.NotFound);
            }    
            var habilidadExistente = pokemon.Habilidades?.FirstOrDefault(h => h.Id == habilidadId);

            if (habilidadExistente == null){
                return NotFound (Mensajes.Habilidad.NotFound);
            }
            var habilidadMismoNombre = pokemon.Habilidades?.FirstOrDefault(h => h.Id != habilidadId && h.Nombre == habilidad.Nombre);

            if (habilidadMismoNombre != null){
                return BadRequest(Mensajes.Habilidad.NombreExistente);
            }
            habilidadExistente.Nombre = habilidad.Nombre;
            habilidadExistente.Potencia = habilidad.Potencia;

            return NoContent();
        }
        [HttpDelete("{habilidadId}")]
        public ActionResult<Habilidad> DeleteHabilidad(int pokemonId, int habilidadId)
        {
            //VALIDA
            var pokemon = PokemonDataStore.Current.Pokemons.FirstOrDefault(x => x.Id == pokemonId);

            if (pokemon == null){
                return NotFound(Mensajes.Pokemon.NotFound);
            }    

            var habilidadExistente = pokemon.Habilidades?.FirstOrDefault(h => h.Id == habilidadId);

            if (habilidadExistente == null){
                return NotFound (Mensajes.Habilidad.NotFound);
            }

            //ELIMINA
            pokemon.Habilidades?.Remove(habilidadExistente);

            return NoContent();
        }
    }
}