using EforBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EforBackend.BLL.Abstract
{
    public interface ILoginService
    {
        JsonSonucModel LoginOl(string KullaniciAd, string Parola);

        Personeller PersonelIdyeGoreGetir(int PersonelId);
        List<Personeller> YoneticininPersonelleriniGetir(int PersonelId);
    }
}
