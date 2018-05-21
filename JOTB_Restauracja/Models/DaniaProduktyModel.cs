using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JOTB_Restauracja.Models
{
    public class DaniaProduktyModel
    {
        public string ID { get; set; }
        public string IdDania { get; set; }
        public string IdProdukt { get; set; }
        [Required]
        public UInt16 IloscProdukt { get; set; }
        [ForeignKey("IdDania")]
        public DaniaModel Danie { get; set; }
        [ForeignKey("IdProdukt")]
        public ProduktyModel Produkt { get; set; }
    }
}