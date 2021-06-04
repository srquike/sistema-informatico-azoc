using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;

namespace RepositoryLayer
{
    public interface IRegistroUsuarioRepository : IDisposable
    {
        IEnumerable<RegistroUsuario> GetRegistroUsuarios();
        RegistroUsuario GetRegistroUsuarioById(int id);
        void InsertRegistroUsuario(RegistroUsuario registroUsuario);
        void DeleteRegistroUsuario(RegistroUsuario registroUsuario);
        void UpdateRegistroUsuario(RegistroUsuario registroUsuario);
        int Save();
    }
}
