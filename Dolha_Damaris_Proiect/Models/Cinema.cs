using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Dolha_Damaris_Proiect.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Display(Name = "Address")]
        public string? Address { get; set; }

        // One-to-many relationship: a cinema can have a list of movies
        public List<Movie>? Movies { get; set; }
    }
}
