﻿using EforBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EforBackend.DAL.Abstract
{
    public interface IIslerRepository
    {
        List<Isler> CalisanIsleriniGetir(int PersonelId);

        bool GorevDurumuDegistir (int IsId,string IsYorum);

        int IsEkle(Isler m);
    }
}
