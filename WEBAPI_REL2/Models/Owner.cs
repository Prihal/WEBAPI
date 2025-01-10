using System.ComponentModel.DataAnnotations;

namespace WEBAPI_REL2.Models
{
    public class Owner
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string gym { get; set; }

        public Country country { get; set; }

        public ICollection<Pokemonowner>  Pokemonowners { get; set; }   

    }
}
