using System.ComponentModel.DataAnnotations;

namespace WEBAPI_REL2.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PokemonCatagory> pokemonCatagories { get; set; }
        
    }
}
