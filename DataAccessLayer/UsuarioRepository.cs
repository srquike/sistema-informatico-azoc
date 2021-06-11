using BusinessObjectsLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public UsuarioRepository()
        {

        }

        public void DeleteUsuario(Usuario usuario)
        {
            using (AzocDbContext context = new AzocDbContext())
            {
                context.Usuarios.Remove(usuario);
                context.SaveChanges();
            }
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            IEnumerable<Usuario> usuarios;

            using (AzocDbContext context = new AzocDbContext())
            {
                usuarios = context.Usuarios
                .AsNoTracking()
                .Include(u => u.Empleado)
                .Include(u => u.PermisoUsuarios)
                .ToList();
            }

            return usuarios;
        }

        public Usuario GetUsuarioById(int id)
        {
            Usuario usuario;

            using (AzocDbContext context = new AzocDbContext())
            {
                usuario = context.Usuarios
                .AsNoTracking()
                .Include(u => u.Empleado)
                .Include(u => u.PermisoUsuarios)
                .Where(u => u.UsuarioId == id)
                .First();
            }

            return usuario;
        }

        public Usuario GetUsuarioByName(string name)
        {
            Usuario usuario;

            using (AzocDbContext context = new AzocDbContext())
            {
                usuario = context.Usuarios
                    .AsNoTracking()
                    .Where(u => u.Nombre == name)
                    .First();
            }

            return usuario;
        }

        public void InsertUsuario(Usuario usuario)
        {
            using (AzocDbContext context = new AzocDbContext())
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
            }
        }

        public void UpdateUsuario(Usuario usuario)
        {
            using (AzocDbContext context = new AzocDbContext())
            {
                context.Entry(usuario).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Usuario Authentication(string clave, string nombre)
        {
            Usuario usuario;

            using (AzocDbContext context = new AzocDbContext())
            {
                usuario = context.Usuarios
                    .AsNoTracking()
                    .Include(u => u.Empleado)
                    .Include(u => u.PermisoUsuarios)
                    .Where(u => u.Clave == clave && u.Nombre == nombre)
                    .First();
            }

            return usuario;
        }
    }
}