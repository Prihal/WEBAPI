using System.ComponentModel.DataAnnotations;

namespace WEBAPI_REL2.Models
{
    public class Pokemonowner
    {
        [Key]
        public int Id { get; set; }
        public int p_id {  get; set; }
        public int o_id {  get; set; }

        public Pokemon Pokemons { get; set; }

        public Owner Owners { get; set; }

        
    }
}
