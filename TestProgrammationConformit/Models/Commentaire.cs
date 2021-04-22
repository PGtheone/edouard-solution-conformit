using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestProgrammationConformit.Models
{
    public class Commentaire
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public DateTime date { get; set; }
        [JsonIgnore]
        public Evenement Evenement { get; set; }
        public int EvenementId { get; set; }
       
      


    }
}
