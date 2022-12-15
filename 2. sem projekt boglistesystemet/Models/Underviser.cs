using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace _2._sem_projekt_boglistesystemet.Models.BookData
{
    [DataContract]
    public class Underviser
    {
        [Required]
        [StringLength(100)]
        [DisplayName("First Name")]
        [DataMember]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Last Name")]
        [DataMember]
        public string LastName { get; set; }
      
        [StringLength(10)]
        [DisplayName("Initials")]
        [DisplayFormat(NullDisplayText = "No Initials")]
        [DataMember]
        public string? Initials { get; set; }
        [Required]
        [Key]
        [DataMember]
        public int UnderviserId { get; set; }
        public ICollection<Fag> Fag { get; set; }
        public ICollection<Books> Books { get; set; }
        public ICollection<Hold> Hold { get; set; }
        public Koordinator Koordinator { get; set; }
        public Underviser()
        {

        }
        public Underviser(string firstname, string lastname, string initials, Koordinator k)
        {
            FirstName = firstname;
            LastName = lastname;
            Initials = initials;
            Koordinator= k; 
           
        }
    }
}
