using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;

namespace RepositoryLayer
{
   public  interface IAsociadoRepository:IDisposable
    {
        IEnumerable<Asociado> GetAsociados();
        Asociado GetAsociadoById(int id);
        void InsertAsociado(Asociado asociado);
        void DeleteAsociado(Asociado asociado);
        void UpdateAsociado(Asociado asociado);
        void Save();

    }
}
