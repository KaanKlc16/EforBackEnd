using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EforBackend.Models
{
    public class Personeller
    {
        public int personelId { get; set; }
        public string personelAdSoyad { get; set; }
        public string personelKullaniciAd { get; set; }
        public string personelParola { get; set; }
        public int personlBirimId { get; set; }
        public int personelYetkiTurId { get; set; }
    }
}
