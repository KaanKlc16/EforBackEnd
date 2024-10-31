using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EforBackend.Models
{
    public class KullaniciGirisResult
    {
        public JsonSonucModel Sonuc { get; set; }
        public Personeller Personel { get; set; }

        public string Url { get; set; }
    }
}
