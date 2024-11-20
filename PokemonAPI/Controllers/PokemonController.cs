using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models;
using PokemonAPI.Services;

namespace PokemonAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PokemonController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Pokemon>> GetPokemon()
    {
        return Ok(PokemonDataStore.Current.Pokemons);
    }
    [HttpGet("{pokemonId}")]
    public ActionResult <Pokemon> GetPokemon(int pokemonId)
    {
        var pokemon = PokemonDataStore.Current.Pokemons.FirstOrDefault(x => x.Id == pokemonId);

        if (pokemon == null){
            return NotFound("El Pokemon solicitado no existe.");
        }
        return Ok(pokemon);
    }
    [HttpPost]
    public ActionResult <Pokemon> PostPokemon(PokemonInsert pokemonInsert)
    {
        var maxPokemonId = PokemonDataStore.Current.Pokemons.Max(x => x.Id);

        var pokemonNuevo = new Pokemon(){
            Id = maxPokemonId + 1,
            Nombre = pokemonInsert.Nombre,
            Tipo = pokemonInsert.Tipo,
        };

        PokemonDataStore.Current.Pokemons.Add(pokemonNuevo);

        return CreatedAtAction(nameof(GetPokemon),
        new { id = pokemonNuevo.Id }, pokemonNuevo);
    }
    [HttpPut("{pokemonId}")]
    public ActionResult<Pokemon> PutPokemon([FromRoute] int pokemonId, [FromBody] PokemonInsert pokemonInsert)
    {
        var pokemon = PokemonDataStore.Current.Pokemons.FirstOrDefault(x => x.Id == pokemonId);

        if (pokemon == null){
            return NotFound("El Pokemon solicitado no existe.");
        }
        pokemon.Nombre = pokemonInsert.Nombre;
        pokemon.Tipo = pokemonInsert.Tipo;

        return NoContent();
    }
    [HttpDelete("{pokemonId}")]
    public ActionResult<Pokemon> DeletePokemon (int pokemonId)
    {
        var pokemon = PokemonDataStore.Current.Pokemons.FirstOrDefault(x => x.Id == pokemonId);
        if (pokemon == null){
           return NotFound("El Pokemon solicitado no existe.");
        }
        PokemonDataStore.Current.Pokemons.Remove(pokemon);

        return NoContent();
    }
}