using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;
using RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer
{
    public class SocioRepository : IAsociadoRepository
    {
        public SocioRepository()
        {

        }

        public void DeleteAsociado(Socio asociado)
        {
            using (AzocDbContext context = new AzocDbContext())
            {
                context.Socios.Remove(asociado);
                context.SaveChanges();
            }
        }

        public Socio GetAsociadoById(int id)
        {
            Socio socio;

            using (AzocDbContext context = new AzocDbContext())
            {
                socio = context.Socios
                    .AsNoTracking()
                    .Include(a => a.Beneficiarios)
                    .Include(a => a.Creditos)
                    .Where(a => a.SocioId == id)
                    .FirstOrDefault();
            }

            return socio;
        }

        public IEnumerable<Socio> GetAsociados()
        {
            IEnumerable<Socio> socios;

            using (AzocDbContext context = new AzocDbContext())
            {
                socios = context.Socios
                    .AsNoTracking()
                    .Include(a => a.Beneficiarios)
                    .Include(a => a.Creditos)
                    .ToList();
            }

            return socios;
        }

        public void InsertAsociado(Socio asociado)
        {
            using (AzocDbContext context = new AzocDbContext())
            {
                context.Socios.Add(asociado);
                context.SaveChanges();
            }
        }

        public void UpdateAsociado(Socio asociado)
        {
            using (AzocDbContext context = new AzocDbContext())
            {
                context.Entry(asociado).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
