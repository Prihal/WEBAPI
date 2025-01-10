using System.ComponentModel.DataAnnotations;

namespace WEBAPI_REL2.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string title { get; set; }
        public string text { get; set; }

        public int rating { get; set; }

        public Reviewer Reviewers { get; set; }  

        public Pokemon Pokemons { get; set; }
        
    }
}
