using System.ComponentModel.DataAnnotations;

namespace WEBAPI_REL2.Models
{
    public class Reviewer
    {
        [Key]
        public int Id { get; set; }
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
