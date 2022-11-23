using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _2._sem_projekt_boglistesystemet.Models
{
    public class Boghandler
    {
        [Required]
        [StringLength(50)]

        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        [DisplayName("Postal Code")]
        public int PostalCode { get; set; }
        [Required]
        public int Id { get; set; }
        public ICollection<Books> Books {get; set; }   
    }
}
