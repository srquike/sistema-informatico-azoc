using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;
using RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer
{
    public class CreditoRepository : ICreditoRepository, IDisposable
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

        public CreditoRepository(AzocDbContext context)
        {
            _context = context;
        }

        public void DeleteCredito(Credito credito)
        {
            _context.Creditos.Remove(credito);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Credito GetCreditoById(int id)
        {
            return _context.Creditos.Where(c => c.CreditoId == id)
                .Include(c => c.Socio)
                .Include(c => c.Cuotas)
                .Include(c => c.EstadoCredito)
                .Include(c => c.DeduccionesCreditos)
                .AsNoTracking()
                .FirstOrDefault();
        }

        public IEnumerable<Credito> GetCreditos()
        {
            return _context.Creditos.Include(c => c.Socio)
                .Include(c => c.EstadoCredito)
                .Include(c => c.Cuotas)
                .AsNoTracking()
                .ToList();
        }

        public void InsertCredito(Credito credito)
        {
            _context.Creditos.Add(credito);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void UpdateCredito(Credito credito)
        {
            _context.Entry(credito).State = EntityState.Modified;
        }
    }
}
