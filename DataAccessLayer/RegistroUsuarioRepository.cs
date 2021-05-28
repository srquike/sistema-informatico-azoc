using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using System.Linq;

namespace DataAccessLayer
{
    public class RegistroUsuarioRepository : IRegistroUsuarioRepository, IDisposable
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

        public RegistroUsuarioRepository(AzocDbContext context)
        {
            _context = context;
        }

        public void DeleteRegistroUsuario(RegistroUsuario registroUsuario)
        {
            _context.RegistrosUsuarios.Remove(registroUsuario);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public RegistroUsuario GetRegistroUsuarioById(int id)
        {
            return _context.RegistrosUsuarios.Where(ru => ru.RegistroUsuarioId == id).AsNoTracking().FirstOrDefault();
        }

        public IEnumerable<RegistroUsuario> GetRegistroUsuarios()
        {
            return _context.RegistrosUsuarios.AsNoTracking().ToList();
        }

        public void InsertRegistroUsuario(RegistroUsuario registroUsuario)
        {
            _context.RegistrosUsuarios.Add(registroUsuario);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateRegistroUsuario(RegistroUsuario registroUsuario)
        {
            _context.Entry(registroUsuario).State = EntityState.Modified;
        }
    }
}
