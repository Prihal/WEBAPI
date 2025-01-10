using System.ComponentModel.DataAnnotations;

namespace WEBAPI_REL2.Models
{
    public class Pokemon
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime bod{ get; set; }
        public ICollection<Review> Reviews { get; set; }  
        public ICollection<PokemonCatagory>  PokemonCatagorys { get; set; }
        public ICollection<Pokemonowner> Pokemonowners { get; set; }


    }
}
