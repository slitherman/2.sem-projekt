using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace _2._sem_projekt_boglistesystemet.Models
{
    [DataContract]
    public class Books
    {
        [Required]
        [MinLength(1), MaxLength(30)]
        [Range(0,1000)]
        [Key]
        [DataMember]
        public int BogId { get; set; }
        [Required]
        [StringLength(50)]
        [DataMember]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DataMember]
        public DateTime Year { get; set; }
        [Required]
        [StringLength(50)]
        [DataMember]
        public string Author { get; set; }
       
        [Range(0,1000)]
        [DataMember]
        public int? ISBN { get; set; }
        public Boghandler BookStore;

      
    }
}
