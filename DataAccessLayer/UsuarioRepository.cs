using BusinessObjectsLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class UsuarioRepository : IUsuarioRepository, IDisposable
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

        public UsuarioRepository(AzocDbContext context)
        {
            _context = context;
        }

        public void DeleteUsuario(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            return _context.Usuarios.Include(u => u.Empleado).AsNoTracking().ToList();
        }

        public Usuario GetUsuarioById(int id)
        {
            return _context.Usuarios.Where(u => u.UsuarioId == id)
                .Include(u => u.Empleado)
                .Include(u => u.PermisoUsuarios)
                .AsNoTracking()
                .FirstOrDefault();
        }

        public Usuario GetUsuarioByName(string name)
        {
            return _context.Usuarios.Where(u => u.Nombre == name)
                .AsNoTracking()
                .FirstOrDefault();
        }

        public void InsertUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateUsuario(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
        }

        public Usuario Authentication(string passwordHash)
        {
            Usuario usuario = _context.Usuarios.Where(u => u.Clave == passwordHash).Include(u => u.Empleado).FirstOrDefault();

            return usuario;
        }
    }
}