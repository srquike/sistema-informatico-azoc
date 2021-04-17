using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;

namespace RepositoryLayer
{
  public  interface ITipoCuotaRepository:IDisposable
    {
        IEnumerable<TipoCuota> GetTipoCuotas();
        TipoCuota GetTipoCuotaById(int id);
        void InsertTipoCuota(TipoCuota tipocuota);
        void DeleteTipoCuota(TipoCuota tipocuota);
        void UpdateTipoCuota(TipoCuota tipocuota);
        void Save();
    }
}
