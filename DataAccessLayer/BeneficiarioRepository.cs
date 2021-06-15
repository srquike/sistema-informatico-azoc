using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;
using RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer
{
    public class BeneficiarioRepository : IBeneficiarioRepository
    {
        public BeneficiarioRepository()
        {

        }

        public void DeleteBeneficiario(Beneficiario beneficiario)
        {
            using (AzocDbContext context = new AzocDbContext())
            {
                context.Beneficiarios.Remove(beneficiario);
                context.SaveChanges();
            }
        }

        public Beneficiario GetBeneficiarioById(int id)
        {
            Beneficiario beneficiario;

            using (AzocDbContext context = new AzocDbContext())
            {
                beneficiario = context.Beneficiarios
                    .AsNoTracking()
                    .Include(b => b.Asociado)
                    .Where(b => b.BeneficiarioId == id)
                    .FirstOrDefault();
            }

            return beneficiario;
        }

        public IEnumerable<Beneficiario> GetBeneficiarios()
        {
            IEnumerable<Beneficiario> beneficiarios;

            using (AzocDbContext context = new AzocDbContext())
            {
                beneficiarios = context.Beneficiarios
                    .AsNoTracking()
                    .Include(b => b.Asociado)
                    .ToList();
            }

            return beneficiarios;
        }

        public void InsertBeneficiario(Beneficiario beneficiario)
        {
            using (AzocDbContext context = new AzocDbContext())
            {
                context.Beneficiarios.Add(beneficiario);
                context.SaveChanges();
            }
        }

        public void UpdateBeneficiario(Beneficiario beneficiario)
        {
            using (AzocDbContext context = new AzocDbContext())
            {
                context.Entry(beneficiario).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void InsertMany(ICollection<Beneficiario> beneficiarios)
        {
            using (AzocDbContext context = new AzocDbContext())
            {
                context.Beneficiarios.AddRange(beneficiarios);
                context.SaveChanges();
            }
        }
    }
}

