using _2._sem_projekt_boglistesystemet.Models.BookData;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace _2._sem_projekt_boglistesystemet.Models
{
    [DataContract]
    public class Uddannelser
    {
        [Required]
        [StringLength(50)]
        [DisplayName("First Name")]
        [DataMember]
        public string Name { get; set; }
        [Required]
        [Key]
        [DataMember]
        public int UddannelseId { get; set; }
        public ICollection<Semestre> semestres { get; set; }
    }
}
