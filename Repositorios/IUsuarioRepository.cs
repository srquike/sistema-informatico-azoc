using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;

namespace RepositoryLayer
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> GetUsuarios();
        Usuario GetUsuarioById(int id);
        Usuario GetUsuarioByName(string name);
        void InsertUsuario(Usuario usuario);
        void DeleteUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        Usuario Authentication(string password, string userName);
    }
}
