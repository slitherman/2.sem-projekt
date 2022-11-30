using _2._sem_projekt_boglistesystemet.Models.BookData;
using System.ComponentModel.DataAnnotations;

namespace _2._sem_projekt_boglistesystemet.Models
{
    public class Fag
    {
        [Required]
        [Key]
        public int FagId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public ICollection<Underviser> Underviser { get; set; }
    }
}
