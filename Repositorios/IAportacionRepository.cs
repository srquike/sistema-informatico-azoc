using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;

namespace RepositoryLayer
{
   public interface IAportacionRepository:IDisposable

    {
        IEnumerable<Aportacion> GetAportacions();
        Aportacion GetAportacionById(int id);
        void InsertAportacion(Aportacion aportacion);
        void DeleteAportacion(Aportacion aportacion);
        void UpdateAportacion(Aportacion aportacion);
        void Save();
    }
}
