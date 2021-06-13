using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;
using RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer
{
    public class CargoRepository : ICargoRepository
    {
        public CargoRepository()
        {

        }

        public void DeleteCargo(Cargo cargo)
        {
            using (AzocDbContext context = new AzocDbContext())
            {
                context.Cargos.Remove(cargo);
                context.SaveChanges();
            }
        }

        public Cargo GetCargoById(int id)
        {
            Cargo cargo;

            using (AzocDbContext context = new AzocDbContext())
            {
                cargo = context.Cargos
                    .AsNoTracking()
                    .Where(c => c.CargoId == id)
                    .FirstOrDefault();
            }

            return cargo;
        }

        public IEnumerable<Cargo> GetCargos()
        {
            IEnumerable<Cargo> cargos;

            using (AzocDbContext context = new AzocDbContext())
            {
                cargos = context.Cargos
                    .AsNoTracking()
                    .ToList();
            }

            return cargos;
        }

        public void InsertCargo(Cargo cargo)
        {
            using (AzocDbContext context = new AzocDbContext())
            {
                context.Cargos.Add(cargo);
                context.SaveChanges();
            }
        }

        public void UpdateCargo(Cargo cargo)
        {
            using (AzocDbContext context = new AzocDbContext())
            {
                context.Entry(cargo).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
