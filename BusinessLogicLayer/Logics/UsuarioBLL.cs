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

        public Usuario Authentication(string password)
        {
            string hashPassword = CryptoService.EncodePassword(password);

            Usuario usuario = _usuarioRepository.Authentication(hashPassword);

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

        public void Create(Usuario usuario)
        {
            string hashPassword = CryptoService.EncodePassword(usuario.Clave);

            usuario.Clave = hashPassword;

            _usuarioRepository.InsertUsuario(usuario);
            _usuarioRepository.Save();
        }

        public bool Edit(Usuario usuario, bool cambiarClave)
        {
            string hashPassword;

            if (cambiarClave)
            {
                hashPassword = CryptoService.EncodePassword(usuario.Clave);
                usuario.Clave = hashPassword;
            }

            _usuarioRepository.UpdateUsuario(usuario);
            _usuarioRepository.Save();

            return true;
        }
    }
}