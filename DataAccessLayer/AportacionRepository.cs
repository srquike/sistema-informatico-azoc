using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;
using RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer
{
    public class AportacionRepository : IAportacionRepository, IDisposable
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
        public AportacionRepository(AzocDbContext context)
        {
            _context = context;
        }

        public void DeleteAportacion(Aportacion aportacion)
        {
            _context.Aportacions.Remove(aportacion);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Aportacion GetAportacionById(int id)
        {
            return _context.Aportacions.Find(id);
        }

        public IEnumerable<Aportacion> GetAportacions()
        {
            return _context.Aportacions.ToList();
        }

        public void InsertAportacion(Aportacion aportacion)
        {
            _context.Aportacions.Add(aportacion);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateAportacion(Aportacion aportacion)
        {
            _context.Entry(aportacion).State = EntityState.Modified;
        }
    }
}
