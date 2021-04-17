using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;
using RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer
{
    public class DeduccionRepository : IDeduccionRepository, IDisposable
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

        public DeduccionRepository(AzocDbContext context)
        {
            _context = context;
        }
        public void DeleteDeduccion(Deduccion deduccion)
        {
            _context.Deduccions.Remove(deduccion);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Deduccion GetDeduccionById(int id)
        {
            return _context.Deduccions.Find(id);
        }

        public IEnumerable<Deduccion> GetDeduccions()
        {
            return _context.Deduccions.ToList();
        }

        public void InsertDeduccion(Deduccion deduccion)
        {
            _context.Deduccions.Add(deduccion);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateDeduccion(Deduccion deduccion)
        {
            _context.Entry(deduccion).State = EntityState.Modified;
        }
    }
}
