using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace _2._sem_projekt_boglistesystemet.Models
{
    [DataContract]
    public class Semestre
    {
        [Required]
        [StringLength(100)]
        [DataMember]
        public string Name { get; set; }
        [Required]
        [Key]
        [DataMember]
        public int SemesterId { get; set; }
        public ICollection<Hold> Hold { get; set; }
        public Uddannelser Uddannelse { get; set; }
        public Koordinator Koordinator { get; set; }
    }
}
