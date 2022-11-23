using System.ComponentModel.DataAnnotations;

namespace _2._sem_projekt_boglistesystemet.Models
{
    public class Books
    {
        [Required]
        [MinLength(1), MaxLength(30)]
        [Range(0,1000)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Year { get; set; }
        [Required]
        [StringLength(50)]
        public string Author { get; set; }
        [Required]
        [Range(0,1000)]
        public int ISBN { get; set; }
        public Boghandler BookStore;

      
    }
}
