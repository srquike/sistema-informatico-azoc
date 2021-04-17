using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;
using RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer
{
    public class PermisoRepository : IPermisoRepository, IDisposable
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

        public PermisoRepository(AzocDbContext context)
        {
            _context = context;
        }
        public void DeletePermiso(Permiso permiso)
        {
            _context.Permisos.Remove(permiso);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Permiso GetPermisoById(int id)
        {
            return _context.Permisos.Find(id);
        }

        public IEnumerable<Permiso> GetPermisos()
        {
            return _context.Permisos.ToList();
        }

        public void InsertPermiso(Permiso permiso)
        {
            _context.Permisos.Add(permiso);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdatePermiso(Permiso permiso)
        {
            _context.Entry(permiso).State = EntityState.Modified;
        }
    }
}
