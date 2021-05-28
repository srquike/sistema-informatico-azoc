using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;
using RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer
{
    public class EstadoCreditoRepository : IEstadoCreditoRepository, IDisposable
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

        public EstadoCreditoRepository(AzocDbContext context)
        {
            _context = context;
        }
        public void DeleteEstadoCredito(EstadoCredito estadocredito)
        {
            _context.EstadosCreditos.Remove(estadocredito);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public EstadoCredito GetEstadoCreditoById(int id)
        {
            return _context.EstadosCreditos.Find(id);
        }

        public IEnumerable<EstadoCredito> GetEstadoCreditos()
        {
            return _context.EstadosCreditos.ToList();
        }

        public void InsertEstadoCredito(EstadoCredito estadocredito)
        {
            _context.EstadosCreditos.Add(estadocredito);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateEstadoCredito(EstadoCredito estadocredito)
        {
            _context.Entry(estadocredito).State = EntityState.Modified;
        }
    }
}
