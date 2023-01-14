using System.ComponentModel.DataAnnotations;

namespace Dolha_Damaris_Proiect.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name = "Full name")]
        public string? FullName { get; set; }

        public string? Address { get; set; }

        [Display(Name = "Birthdate")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
