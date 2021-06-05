using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;
using RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer
{
    public class PermisoUsuarioRepository : IPermisoUsuarioRepository, IDisposable
    {
        private AzocDbContext _context;
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            disposed = true;
        }

        public PermisoUsuarioRepository(AzocDbContext context)
        {
            _context = context;
        }

        public void DeletePermisoUsuario(PermisoUsuario permisoUsuario)
        {
            _context.PermisoUsuarios.Remove(permisoUsuario);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<PermisoUsuario> GetPermisosUsuario()
        {
            return _context.PermisoUsuarios.ToList();
        }

        public PermisoUsuario GetPermisoUsuarioById(int id)
        {
            return _context.PermisoUsuarios.Find(id);
        }

        public void InsertPermisoUsuario(PermisoUsuario permisoUsuario)
        {
            _context.PermisoUsuarios.Add(permisoUsuario);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void UpdatePermisoUsuario(PermisoUsuario permisoUsuario)
        {
            _context.Entry(permisoUsuario).State = EntityState.Modified;
        }

        public void InsertMany(ICollection<PermisoUsuario> permisosUsuarios)
        {
            _context.PermisoUsuarios.AddRange(permisosUsuarios);
        }
    }
}
