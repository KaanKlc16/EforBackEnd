using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EforBackend.Models
{

    public class Isler
    {
        public int isId { get; set; }
        public string isBaslik { get; set; }
        public string isAciklama { get; set; }
        public int? isPersonelId { get; set; }
        public DateTime iletilenTarih { get; set; }
        public DateTime yapilanTarih { get; set; }
        public int isDurumId { get; set; }
        public string isYorum { get; set; }
        public int tahminiSure { get; set; }
        public bool isOkunma { get; set; }
        public DateTime isBaslangic { get; set; }
        public DateTime isBitirmeSure { get; set; }

        public string isBaslangicString { get { return isBaslangic.Year == 2000 ? "" :  isBaslangic.ToString("dd.MM.yyyy"); } }
    }
}
