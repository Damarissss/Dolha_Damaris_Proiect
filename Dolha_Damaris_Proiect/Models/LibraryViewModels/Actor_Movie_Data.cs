using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Dolha_Damaris_Proiect.Models.LibraryViewModels
{
    public class Actor_Movie_Data
    {
        public int ActorId { get; set; }

        [Display(Name = "Full name")]
        public string? FullName { get; set; }
    }
}
