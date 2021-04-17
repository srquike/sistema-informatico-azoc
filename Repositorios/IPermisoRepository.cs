using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;

namespace RepositoryLayer
{
   public interface IPermisoRepository : IDisposable
    {
        IEnumerable<Permiso> GetPermisos();
        Permiso GetPermisoById(int id);
        void InsertPermiso(Permiso permiso);
        void DeletePermiso(Permiso permiso);
        void UpdatePermiso(Permiso permiso);
        void Save();
       
    }
}
