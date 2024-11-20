using PokemonAPI.Models;

namespace PokemonAPI.Services;

public class PokemonDataStore
{
    public List <Pokemon> Pokemons { get; set; }

    public static PokemonDataStore Current {get; } = new PokemonDataStore();

    public PokemonDataStore()
    {
        Pokemons = new List<Pokemon>(){
            new Pokemon(){
                Id = 1,
                Nombre = "Pikachu",
                Tipo = "Electric",
                Habilidades = new List<Habilidad>(){
                    new Habilidad(){
                        Id = 1,
                        Nombre = "Electroshock",
                        Potencia = Habilidad.EPotencia.Potente
                    } 
                }
            },
            new Pokemon(){
                Id = 2,
                Nombre = "Charmander",
                Tipo = "Fuego",
                Habilidades = new List<Habilidad>(){
                    new Habilidad(){
                        Id = 2,
                        Nombre = "Fuego",
                        Potencia = Habilidad.EPotencia.Intenso
                    },
                    new Habilidad(){
                        Id = 3,
                        Nombre = "Fuego Intenso",
                        Potencia = Habilidad.EPotencia.Potente
                    },
                    new Habilidad(){
                        Id = 4,
                        Nombre = "Fuego Extremo",
                        Potencia = Habilidad.EPotencia.Extremo
                    }
                }
            },
            new Pokemon(){
                Id = 3,
                Nombre = "Bulbasaur",
                Tipo = "Planta",
                Habilidades = new List<Habilidad>(){
                    new Habilidad(){
                        Id = 5,
                        Nombre = "Hoja",
                        Potencia = Habilidad.EPotencia.Intenso
                    },
                    new Habilidad(){
                        Id = 6,
                        Nombre = "Hoja Intensa",
                        Potencia = Habilidad.EPotencia.Potente
                    }
                }
            }
        };
    }
}