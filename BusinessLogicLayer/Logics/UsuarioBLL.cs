using BusinessObjectsLayer.Models;
using DataAccessLayer;
using RepositoryLayer;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Logics
{
    public class UsuarioBLL
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioBLL()
        {
            _usuarioRepository = new UsuarioRepository(new AzocDbContext());
        }

        public bool Delete(int id)
        {
            Usuario usuario = _usuarioRepository.GetUsuarioById(id);

            if (usuario != null)
            {
                try
                {
                    _usuarioRepository.DeleteUsuario(usuario);
                    _usuarioRepository.Save();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }

        public IEnumerable<Usuario> List()
        {
            return _usuarioRepository.GetUsuarios();
        }

        public Usuario Find(int id)
        {
            return _usuarioRepository.GetUsuarioById(id);
        }

        public bool Create(Usuario usuario)
        {
            _usuarioRepository.InsertUsuario(usuario);
            _usuarioRepository.Save();
            return true;
        }

        public bool Edit(Usuario usuario)
        {
            try
            {
                _usuarioRepository.UpdateUsuario(usuario);
                _usuarioRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}