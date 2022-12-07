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


    }
}
