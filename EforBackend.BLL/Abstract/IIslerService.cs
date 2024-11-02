using EforBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EforBackend.BLL.Abstract
{
    public interface IIslerService
    {
        List<Isler> CalisanIsleriniGetir(int PersonelId);

        int IsEkle(Isler m);
        bool GorevDurumuDegistir(int IsId, string IsYorum);

    }
}
