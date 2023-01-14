using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Dolha_Damaris_Proiect.Data.Enums;

namespace Dolha_Damaris_Proiect.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }

        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Genre")]
        public MovieGenre MovieGenre { get; set; }

        [Display(Name = "Poster title")]
        public string? ImageTitle { get; set; }
        
        // Relationships:
        [Display(Name = "Main actors")]
        public ICollection<Actor_Movie>? Actors_Movies { get; set; }

        [Display(Name = "Cinema")]
        public int CinemaId { get; set; }
        public Cinema? Cinema { get; set; }

        [Display(Name = "Producer")]
        public int ProducerId { get; set; }
        public Producer? Producer { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
