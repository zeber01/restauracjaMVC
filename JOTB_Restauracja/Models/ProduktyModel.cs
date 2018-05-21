using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JOTB_Restauracja.Models
{
    public class ProduktyModel
    {
        [Key]
        public string ID { get; set; }
        [Index(IsUnique = true)]
        [StringLength(250)]
        [Required]
        public string Nazwa { get; set; }
        [Required]
        public int Ilosc { get; set; }
        [Required]
        public string Jednostka { get; set; }
        [Required]
        public float Koszt { get; set; }
    }
}