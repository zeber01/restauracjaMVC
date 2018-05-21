using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JOTB_Restauracja.Models
{
    public class DaniaModel
    {
        [Key]
        public string ID { get; set; }
        [Required]
        public string Nazwa { get; set; }
        [Required]
        public float Cena { get; set; }
        [Required]
        public string Kategoria { get; set; }
    }
}