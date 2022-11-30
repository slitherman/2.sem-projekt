﻿using System.ComponentModel.DataAnnotations;

namespace _2._sem_projekt_boglistesystemet.Models
{
    public class Semestre
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [Key]
        public int SemesterId { get; set; }
        public ICollection<Hold> Hold { get; set; }
    }
}
