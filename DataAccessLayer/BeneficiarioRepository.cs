using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;
using RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer
{
    public class BeneficiarioRepository : IBeneficiarioRepository, IDisposable
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
        public BeneficiarioRepository(AzocDbContext context)
        {
            _context = context;
        }
        public void DeleteBeneficiario(Beneficiario beneficiario)
        {
            _context.Beneficiarios.Remove(beneficiario);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Beneficiario GetBeneficiarioById(int id)
        {
            return _context.Beneficiarios.Find(id);
        }

        public IEnumerable<Beneficiario> GetBeneficiarios()
        {
            return _context.Beneficiarios.ToList();
        }

        public void InsertBeneficiario(Beneficiario beneficiario)
        {
            _context.Beneficiarios.Add(beneficiario);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateBeneficiario(Beneficiario beneficiario)
        {
            _context.Entry(beneficiario).State = EntityState.Modified;
        }
    }
}

