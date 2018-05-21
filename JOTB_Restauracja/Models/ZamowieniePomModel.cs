using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace JOTB_Restauracja.Models
{
    public class ZamowieniePomModel
    {
        public string czyZaznaczone { get; set; }
        public string idDania { get; set; }
        public string NazwaDania { get; set; }
        public int Ilosc { get; set; }
        public string IdZamowienia { get; set; }
    }
}