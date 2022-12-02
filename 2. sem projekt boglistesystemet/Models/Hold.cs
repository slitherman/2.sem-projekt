using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _2._sem_projekt_boglistesystemet.Models
{
    public class Hold
    {
        [Required]
        [StringLength(50)]
        [DisplayName("Class Name")]
        public string Name { get; set; }
        [Required]
        public int Id { get; set; }
        public ICollection<Semestre> semestre { get; set; }
        public ICollection<Books> Bøger { get; set; }


    }
}
