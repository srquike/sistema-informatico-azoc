using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;
using RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer
{
    public class CargoRepository : ICargoRepository, IDisposable
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
        public CargoRepository(AzocDbContext context)
        {
            _context = context;
        }
        public void DeleteCargo(Cargo cargo)
        {
            _context.Cargos.Remove(cargo);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Cargo GetCargoById(int id)
        {
            return _context.Cargos.Find(id);
        }

        public IEnumerable<Cargo> GetCargos()
        {
            return _context.Cargos.ToList();
        }

        public void InsertCargo(Cargo cargo)
        {
            _context.Cargos.Add(cargo);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateCargo(Cargo cargo)
        {
            _context.Entry(cargo).State = EntityState.Modified;
        }
    }
}
