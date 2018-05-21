using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JOTB_Restauracja.Models
{
    public class PracownikModel
    {
        [Key]
        public string ID { get; set; }
        [Required]
        public string Nazwisko { get; set; }
        [Required]
        public string Imie { get; set; }
        [Required]
        public string PESEL { get; set; }
        public string Stanowisko { get; set; }
        [Required]
        public float Wynagrodzenie { get; set; }
    }
}