using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Dolha_Damaris_Proiect.Models
{
    public class Actor
    {
        // Unique identifier
        [Key]
        public int Id { get; set; }

        [Display(Name = "Full name")]
        public string? FullName { get; set; }

        [Display(Name = "Biography")]
        public string? Bio { get; set; }

        // Relationship:
        public ICollection<Actor_Movie>? Actors_Movies { get; set; }
    }
}
