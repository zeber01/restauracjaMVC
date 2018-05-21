using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JOTB_Restauracja.Models
{
    public class ZamowienieModel
    {
        [Key]
        public string ID { get; set; }
        [Required]
        public DateTime data { get; set; }
        public bool Zrealizowane { get; set; }
        public string idKlienta { get; set; }
    }
}