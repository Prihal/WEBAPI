using System.ComponentModel.DataAnnotations;

namespace WEBAPI_REL2.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string name{ get; set; }

        public ICollection<Owner> owners{ get; set; }
    }
}
