using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;
using RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer
{
    public class SocioRepository : IAsociadoRepository, IDisposable
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

        public SocioRepository(AzocDbContext context)
        {
            _context = context;
        }

        public void DeleteAsociado(Socio asociado)
        {
            _context.Socios.Remove(asociado);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Socio GetAsociadoById(int id)
        {
            return _context.Socios.Where(a => a.SocioId == id)
                .Include(a => a.CategoriaAsociado)
                .Include(a => a.Beneficiarios)
                .Include(a => a.Creditos)
                .AsNoTracking()
                .FirstOrDefault();
        }

        public IEnumerable<Socio> GetAsociados()
        {
            return _context.Socios.Include(a => a.CategoriaAsociado)
                .Include(a => a.Beneficiarios)
                .Include(a => a.Creditos)
                .AsNoTracking()
                .ToList();
        }

        public void InsertAsociado(Socio asociado)
        {
            _context.Socios.Add(asociado);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void UpdateAsociado(Socio asociado)
        {
            _context.Entry(asociado).State = EntityState.Modified;
        }

        public Socio GetSocioByCode(string code)
        {
            return _context.Socios.Where(a => a.Codigo == code)
                .Include(a => a.CategoriaAsociado)
                .Include(a => a.Beneficiarios)
                .Include(a => a.Creditos)
                .AsNoTracking()
                .FirstOrDefault();
        }
    }
}
