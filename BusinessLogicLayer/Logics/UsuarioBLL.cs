using BusinessObjectsLayer.Models;
using DataAccessLayer;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using BusinessLogicLayer.Services;

namespace BusinessLogicLayer.Logics
{
    public class UsuarioBLL
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioBLL()
        {
            _usuarioRepository = new UsuarioRepository(new AzocDbContext());
        }

        public Usuario Authentication(string userName, string password)
        {
            string hashPassword = CryptoService.EncodePassword(string.Concat(userName, password));

            Usuario usuario = _usuarioRepository.Authentication(userName, hashPassword);

            return usuario;
        }

        public bool Delete(int id)
        {
            Usuario usuario = _usuarioRepository.GetUsuarioById(id);

            if (usuario != null)
            {
                _usuarioRepository.DeleteUsuario(usuario);
                _usuarioRepository.Save();
                return true;
            }

            return false;
        }

        public IEnumerable<Usuario> List()
        {
            return _usuarioRepository.GetUsuarios();
        }

        public Usuario Find(int id)
        {
            Usuario usuario = _usuarioRepository.GetUsuarioById(id);

            return usuario;
        }

        public bool Create(Usuario usuario)
        {
            string hashPassword = CryptoService.EncodePassword(string.Concat(usuario.Nombre, usuario.Clave));

            usuario.Clave = hashPassword;

            _usuarioRepository.InsertUsuario(usuario);
            _usuarioRepository.Save();
            return true;
        }

        public bool Edit(Usuario usuario)
        {
            _usuarioRepository.UpdateUsuario(usuario);
            _usuarioRepository.Save();
            return true;
        }
    }
}