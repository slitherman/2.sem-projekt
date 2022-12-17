using _2._sem_projekt_boglistesystemet.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace _2._sem_projekt_boglistesystemet.Models
{
    [DataContract]
    public class Books
    {
        [Required]
        [MinLength(1), MaxLength(30)]
        [Range(0, 1000)]
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
        public string Year { get; set; }
        [Required]
        [StringLength(50)]
        [DataMember]
        public string Author { get; set; }

        [Range(0, 1000)]
        [DataMember]
        [Required]
        public int ISBN { get; set; }
        public Boghandler BookStore;
        public ICollection<Hold> Hold { get; set; }

        public Books()
        {

        }
        public Books(string name, string yr, string author, int isbn)
        {

            Name = name;
            Year = yr;
            Author = author;
            ISBN = isbn;

        }

        
    }
}
