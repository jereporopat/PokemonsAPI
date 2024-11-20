namespace PokemonAPI.Models;

public class Pokemon
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public List <Habilidad>? Habilidades { get; set; } = new List<Habilidad>();
}