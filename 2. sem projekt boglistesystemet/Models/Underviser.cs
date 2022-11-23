using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _2._sem_projekt_boglistesystemet.Models.BookData
{
    public class Underviser
    {
        [Required]
        [StringLength(100)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(10)]
        [DisplayName("Initials")]
        [DisplayFormat(NullDisplayText = "No Initials")]
        public string Initials { get; set; }
        [Required]
        public int Id { get; set; }
        public ICollection<Fag> Fag { get; set; }
        ICollection<Books> Books { get; set; }
    }
}
