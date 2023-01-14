using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dolha_Damaris_Proiect.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Order date")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        public Customer? Customer { get; set; }

        [Display(Name = "Movie")]
        public int MovieId { get; set; }

        public Movie? Movie { get; set; }
    }
}
