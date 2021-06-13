using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;
using RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer
{
    public class EmpleadoRepository : IEmpleadoRepository
    {

        public EmpleadoRepository()
        {

        }

        public void DeleteEmpleado(Empleado empleado)
        {
            using (AzocDbContext context = new AzocDbContext())
            {
                context.Empleados.Remove(empleado);
                context.SaveChanges();
            }
        }

        public Empleado GetEmpleadoById(int id)
        {
            Empleado empleado;

            using (AzocDbContext context = new AzocDbContext())
            {
                empleado = context.Empleados
                .AsNoTracking()
                .Include(e => e.Cargo)
                .Include(e => e.Usuarios)
                .Where(e => e.EmpleadoId == id)
                .FirstOrDefault();
            }

            return empleado;
        }

        public IEnumerable<Empleado> GetEmpleados()
        {
            IEnumerable<Empleado> empleados;

            using (AzocDbContext context = new AzocDbContext())
            {
                empleados = context.Empleados
                .AsNoTracking()
                .Include(e => e.Cargo)
                .Include(e => e.Usuarios)
                .ToList();
            }

            return empleados;
        }

        public void InsertEmpleado(Empleado empleado)
        {
            using (AzocDbContext context = new AzocDbContext())
            {
                context.Empleados.Add(empleado);
                context.SaveChanges();
            }
        }

        public void UpdateEmpleado(Empleado empleado)
        {
            using (AzocDbContext context = new AzocDbContext())
            {
                context.Entry(empleado).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
