using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JOTB_Restauracja.Models
{
    public class ZamowienieDanieModel
    {
        public string ID { get; set; }
        public string IdZamowienia { get; set; }
        public string IdDania { get; set; }
        public int Ilosc { get; set; }
        [ForeignKey("IdZamowienia")]
        public ZamowienieModel Zamowienie { get; set; }
        [ForeignKey("IdDania")]
        public DaniaModel Danie { get; set; }
    }
}