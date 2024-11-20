using static PokemonAPI.Models.Habilidad;

namespace PokemonAPI.Models
{
    public class HabilidadInsert
    {
        public string Nombre { get; set; } = string.Empty;
        public EPotencia Potencia { get; set; }
    }
}