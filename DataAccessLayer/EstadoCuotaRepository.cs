using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;
using RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer
{
    public class EstadoCuotaRepository : IEstadoCuotaRepository, IDisposable
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

        public EstadoCuotaRepository(AzocDbContext context)
        {
            _context = context;
        }
        public void DeleteEstadoCuota(EstadoCuota estadocuota)
        {
            _context.EstadosCuotas.Remove(estadocuota);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public EstadoCuota GetEstadoCuotaById(int id)
        {
            return _context.EstadosCuotas.Find(id);
        }

        public IEnumerable<EstadoCuota> GetEstadoCuotas()
        {
            return _context.EstadosCuotas.ToList();
        }

        public void InsertEstadoCuota(EstadoCuota estadocuota)
        {
            _context.EstadosCuotas.Add(estadocuota);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateEstadoCuota(EstadoCuota estadocuota)
        {
            _context.Entry(estadocuota).State = EntityState.Modified;
        }
    }
}
