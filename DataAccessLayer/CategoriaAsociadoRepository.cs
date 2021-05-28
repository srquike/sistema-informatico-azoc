﻿using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;
using RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer
{
    public class CategoriaAsociadoRepository : ICategoriaAsociadoRepository, IDisposable
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
        public CategoriaAsociadoRepository(AzocDbContext context)
        {
            _context = context;
        }
        public void DeleteCategoriaAsociado(CategoriaAsociado categoriaasociado)
        {
            _context.CategoriasAsociados.Remove(categoriaasociado);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public CategoriaAsociado GetCategoriaAsociadoById(int id)
        {
            return _context.CategoriasAsociados.Where(ca => ca.CategoriaAsociadoId == id)
                .AsNoTracking()
                .FirstOrDefault();
        }

        public IEnumerable<CategoriaAsociado> GetCategoriaAsociados()
        {
            return _context.CategoriasAsociados
                .AsNoTracking()
                .ToList();
        }

        public void InsertCategoriaAsociado(CategoriaAsociado categoriaasociado)
        {
            _context.CategoriasAsociados.Add(categoriaasociado);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateCategoriaAsociado(CategoriaAsociado categoriaasociado)
        {
            _context.Entry(categoriaasociado).State = EntityState.Modified;
        }
    }
}
