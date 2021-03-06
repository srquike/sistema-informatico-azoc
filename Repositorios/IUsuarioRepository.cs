using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;

namespace RepositoryLayer
{
    public interface IUsuarioRepository : IDisposable
    {
        IEnumerable<Usuario> GetUsuarios();
        Usuario GetUsuarioById(int id);
        void InsertUsuario(Usuario usuario);
        void DeleteUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        void Save();
    }
}
