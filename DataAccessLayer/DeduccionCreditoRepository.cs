using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;
using RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer
{
    public class DeduccionCreditoRepository : IDeduccionCreditoRepository, IDisposable
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

        public DeduccionCreditoRepository(AzocDbContext context)
        {
            _context = context;
        }
        public void DeleteDeduccionCredito(DeduccionCredito deduccioncredito)
        {
            _context.DeduccionCreditos.Remove(deduccioncredito);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public DeduccionCredito GetDeduccionCreditoById(int id)
        {
            return _context.DeduccionCreditos.Find(id);
        }

        public IEnumerable<DeduccionCredito> GetDeduccionCreditos()
        {
            return _context.DeduccionCreditos.ToList();
        }

        public void InsertDeduccionCredito(DeduccionCredito deduccioncredito)
        {
            _context.DeduccionCreditos.Add(deduccioncredito);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateDeduccionCredito(DeduccionCredito deduccioncredito)
        {
            _context.Entry(deduccioncredito).State = EntityState.Modified;
        }
    }
}
