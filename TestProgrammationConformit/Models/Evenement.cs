using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TestProgrammationConformit.Models
{
    
    public class Evenement
    {
        [Key]
        public int id { get; set; }
        [Required]

     
        public string titre { get; set; }
        [Required]
        public string description { get; set; }
        public string realisateur { get; set; }
     
        public ICollection<Commentaire> comments { get; set; } = new List<Commentaire>();
    }
}
