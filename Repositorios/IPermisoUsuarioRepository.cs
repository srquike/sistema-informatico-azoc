using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;

namespace RepositoryLayer
{
    public interface IPermisoUsuarioRepository : IDisposable
    {
        IEnumerable<PermisoUsuario> GetPermisosUsuario();
        PermisoUsuario GetPermisoUsuarioById(int id);
        void InsertPermisoUsuario(PermisoUsuario permisoUsuario);
        void DeletePermisoUsuario(PermisoUsuario permisoUsuario);
        void UpdatePermisoUsuario(PermisoUsuario permisoUsuario);
        void Save();
    }
}
