namespace Dolha_Damaris_Proiect.Models
{
    public class Actor_Movie
    {
        // Foreign key
        public int MovieId { get; set; }
        // Navigation property
        public Movie? Movie { get; set; }

        public int ActorId { get; set; }
        public Actor? Actor { get; set; }
    }
}
