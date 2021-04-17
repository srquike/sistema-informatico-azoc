using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;
using RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer
{
    public class AsociadoRepository : IAsociadoRepository, IDisposable
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
        public AsociadoRepository(AzocDbContext context)
        {
            _context = context;
        }
        public void DeleteAsociado(Asociado asociado)
        {
            _context.Asociados.Remove(asociado);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Asociado GetAsociadoById(int id)
        {
            return _context.Asociados.Find(id);
        }

        public IEnumerable<Asociado> GetAsociados()
        {
            return _context.Asociados.ToList();
        }

        public void InsertAsociado(Asociado asociado)
        {
            _context.Asociados.Add(asociado);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateAsociado(Asociado asociado)
        {
            _context.Entry(asociado).State = EntityState.Modified;
        }
    }
}
