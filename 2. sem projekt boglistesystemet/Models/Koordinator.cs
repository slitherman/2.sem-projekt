using _2._sem_projekt_boglistesystemet.Models.BookData;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace _2._sem_projekt_boglistesystemet.Models
{
    [DataContract]
    public class Koordinator
    {

        [Required]
        [Key]
        [DataMember]
        public int KoordinatorId { get; set; }
        [Required]

        [PasswordPropertyText(true)]
        [DataType(DataType.Password)]
        [DataMember]
        public int Password { get; set; }
       public ICollection<Uddannelser>  uddannelser { get; set; }
       public ICollection<Hold> Hold { get; set; }
       public ICollection<Fag> Fag { get; set; }
       public ICollection<Semestre> semestres { get; set; }
       public ICollection<Underviser> Undervisers  { get; set; }
        
        //ICollection<Books> Books { get; set; }

    }
}
