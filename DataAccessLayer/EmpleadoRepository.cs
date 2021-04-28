using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;
using RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer
{
    public class EmpleadoRepository : IEmpleadoRepository, IDisposable
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

        public EmpleadoRepository(AzocDbContext context)
        {
            _context = context;
        }

        public void DeleteEmpleado(Empleado empleado)
        {
            _context.Empleados.Remove(empleado);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Empleado GetEmpleadoById(int id)
        {
            return _context.Empleados.Find(id);
        }

        public IEnumerable<Empleado> GetEmpleados()
        {
            return _context.Empleados.Include(e => e.Cargo).ToList();
        }

        public void InsertEmpleado(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateEmpleado(Empleado empleado)
        {
            _context.Entry(empleado).State = EntityState.Modified;
        }
    }
}
