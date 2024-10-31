using EforBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EforBackend.DAL.Abstract
{
    public interface ILoginRepository
    {
        JsonSonucModel LoginOl(string KullaniciAd, string Parola);
        Personeller PersonelIdyeGoreGetir(int PersonelId);

        List<Personeller> YoneticininPersonelleriniGetir(int PersonelId);
    }
}
