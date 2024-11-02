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
    public class IslerService : IIslerService
    {
        private IIslerRepository _repos;
        public IslerService()
        {
            _repos = new IslerRepository();
        }
        public List<Isler> CalisanIsleriniGetir(int PersonelId)
        {
            return _repos.CalisanIsleriniGetir(PersonelId);
        }

        public int IsEkle(Isler m) 
        {
            return _repos.IsEkle(m);
        }
        public bool GorevDurumuDegistir(int IsId, string IsYorum)
        {
            return _repos.GorevDurumuDegistir(IsId,IsYorum);
        }

    }
}
