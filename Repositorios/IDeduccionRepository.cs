using System;
using BusinessObjectsLayer.Models;
using System.Collections.Generic;


namespace RepositoryLayer
{
   public interface IDeduccionRepository:IDisposable
    {
        IEnumerable<Deduccion> GetDeduccions();
        Deduccion GetDeduccionById(int id);
        void InsertDeduccion(Deduccion deduccion);
        void DeleteDeduccion(Deduccion deduccion);
        void UpdateDeduccion(Deduccion deduccion);
        void Save();
    }
}
