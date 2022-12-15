using _2._sem_projekt_boglistesystemet.Models.BookData;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace _2._sem_projekt_boglistesystemet.Models
{
    [DataContract]
    public class Hold
    {
        [Required]
        [StringLength(50)]
        [DisplayName("Class Name")]
        [DataMember]
        public string Name { get; set; }
        [Required]
        [Key]
        [DataMember]
        public int HoldId { get; set; }
        public ICollection<Semestre> semestre { get; set; }
        public ICollection<Fag> fag { get; set; }
        public Koordinator Koordinator { get; set; }
        public ICollection<Books> Bøger { get; set; }

        public Hold()
        {

        }
        public Hold(string name, Koordinator k)
        {
            Name = name;
            Koordinator = k;    
          
            

        }


    }
}
