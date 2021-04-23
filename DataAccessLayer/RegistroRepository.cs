using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjectsLayer.Models;
using RepositoryLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class RegistroRepository : IRegistroRepository, IDisposable
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

        public RegistroRepository(AzocDbContext context)
        {
            _context = context;
        }

        public void DeleteRegistro(Registro registro)
        {
            _context.Registros.Remove(registro);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Registro GetRegistroById(int id)
        {
            return _context.Registros.Find(id);
        }

        public IEnumerable<Registro> GetRegistros()
        {
            return _context.Registros.ToList();
        }

        public void InsertRegistro(Registro registro)
        {
            _context.Registros.Add(registro);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateRegistro(Registro registro)
        {
            _context.Entry(registro).State = EntityState.Modified;
        }
    }
}
