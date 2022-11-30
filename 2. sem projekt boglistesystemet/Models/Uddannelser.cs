using _2._sem_projekt_boglistesystemet.Models.BookData;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _2._sem_projekt_boglistesystemet.Models
{
    public class Uddannelser
    {
        [Required]
        [StringLength(50)]
        [DisplayName("First Name")]
        public string Name { get; set; }
        [Required]
        [Key]
        public int UddannelseId { get; set; }
        public ICollection<Semestre> semestres { get; set; }
    }
}
