using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Dolha_Damaris_Proiect.Models
{
    public class Producer
    {
        // Unique identifier
        [Key]
        public int Id { get; set; }

        [Display(Name = "Full name")]
        public string? FullName { get; set; }

        [Display(Name = "Biography")]
        public string? Bio { get; set; }

        // One-to-many relationship: a producer can have multiple movies
        public List<Movie>? Movies { get; set; }
    }
}
