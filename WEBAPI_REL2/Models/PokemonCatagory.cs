using System.ComponentModel.DataAnnotations;

namespace WEBAPI_REL2.Models
{
    public class PokemonCatagory
    {
        [Key]
        public int Id { get; set; }
        public int p_id { get; set; }

        public int c_id {  get; set; }

        public Pokemon Pokemons { get; set; }

        public Category Categories { get; set; }


    }
}
