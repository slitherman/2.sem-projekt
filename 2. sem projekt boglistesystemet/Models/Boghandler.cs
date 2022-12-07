using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace _2._sem_projekt_boglistesystemet.Models
{
    [DataContract]
    public class Boghandler
    {
        [Required]
        [StringLength(50)]
        [DataMember]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        [DataMember]
        public string Address { get; set; }
        [Required]
        [DisplayName("Postal Code")]
        [DataMember]
        public int PostalCode { get; set; }
        [Required]
        [Key]
        [DataMember]
        public int BoghandlerId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [PasswordPropertyText(true)]
        [DataMember]
        public int password { get; set; }
        public ICollection<Books> Books {get; set; }   
    }
}
