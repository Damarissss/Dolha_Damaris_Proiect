using System.ComponentModel.DataAnnotations;

namespace Dolha_Damaris_Proiect.Models.LibraryViewModels
{
    public class OrderGroup
    {
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }
        public int MovieCount { get; set; }
    }
}
