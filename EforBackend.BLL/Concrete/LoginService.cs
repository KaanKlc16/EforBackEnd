using EforBackend.BLL.Abstract;
using EforBackend.DAL.Abstract;
using EforBackend.DAL.Concrete;
using EforBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EforBackend.BLL.Concrete
{
    public class LoginService : ILoginService
    {
        private ILoginRepository _repos;
        public LoginService()
        {
            _repos = new LoginRepository();
        }

        public JsonSonucModel LoginOl(string KullaniciAd, string Parola)
        {
            return _repos.LoginOl(KullaniciAd, Parola);
        }

        public Personeller PersonelIdyeGoreGetir(int PersonelId) 
        {
            return _repos.PersonelIdyeGoreGetir(PersonelId);
        }

        public List<Personeller> YoneticininPersonelleriniGetir(int PersonelId) 
        {
            return _repos.YoneticininPersonelleriniGetir(PersonelId);
        }
    }
}
