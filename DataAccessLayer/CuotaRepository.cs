using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;
using RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer
{
    public class CuotaRepository : ICuotaRepository, IDisposable
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

        public CuotaRepository(AzocDbContext context)
        {
            _context = context;
        }

        public void DeleteCuota(Cuota cuota)
        {
            _context.Cuota.Remove(cuota);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Cuota GetCuotaById(int id)
        {
            return _context.Cuota.Where(c => c.CuotaId == id)
                .Include(c => c.Credito)
                .Include(c => c.EstadoCuota)
                .AsNoTracking()
                .First();
        }

        public IEnumerable<Cuota> GetCuotas()
        {
            return _context.Cuota
                .Include(c => c.Credito)
                .Include(c => c.EstadoCuota)
                .AsNoTracking()
                .ToList();
        }

        public void InsertCuota(Cuota cuota)
        {
            _context.Cuota.Add(cuota);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void UpdateCuota(Cuota cuota)
        {
            _context.Entry(cuota).State = EntityState.Modified;
        }

        public void InsertMany(ICollection<Cuota> cuotas)
        {
            _context.Cuota.AddRange(cuotas);
        }
    }
}
