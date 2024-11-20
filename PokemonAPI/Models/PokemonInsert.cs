using System.ComponentModel.DataAnnotations;

namespace PokemonAPI.Models
{
    public class PokemonInsert
    {
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Tipo { get; set; } = string.Empty;
    }
}