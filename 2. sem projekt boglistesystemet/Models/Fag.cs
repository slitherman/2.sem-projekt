using _2._sem_projekt_boglistesystemet.Models.BookData;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace _2._sem_projekt_boglistesystemet.Models
{
    [DataContract]
    public class Fag
    {
        [Required]
        [Key]
        [DataMember]
        public int FagId { get; set; }

        [Required]
        [StringLength(50)]
        [DataMember]
        public string Name { get; set; }
        public ICollection<Underviser> Underviser { get; set; }
        public Koordinator Koordinator { get; set; }
        public ICollection<Hold> Hold { get; set; }
    }
}
