using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;
using RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer
{
    public class TipoCuotaRepository : ITipoCuotaRepository, IDisposable
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

        public TipoCuotaRepository(AzocDbContext context)
        {
            _context = context;
        }
        public void DeleteTipoCuota(TipoCuota tipocuota)
        {
            _context.TipoCuota.Remove(tipocuota);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public TipoCuota GetTipoCuotaById(int id)
        {
            return _context.TipoCuota.Find(id);
        }

        public IEnumerable<TipoCuota> GetTipoCuotas()
        {
            return _context.TipoCuota.ToList();
        }

        public void InsertTipoCuota(TipoCuota tipocuota)
        {
            _context.TipoCuota.Add(tipocuota);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateTipoCuota(TipoCuota tipocuota)
        {
            _context.Entry(tipocuota).State = EntityState.Modified;
        }
    }
}
