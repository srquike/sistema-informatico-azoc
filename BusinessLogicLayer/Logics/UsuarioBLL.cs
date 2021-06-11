using BusinessObjectsLayer.Models;
using DataAccessLayer;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using BusinessLogicLayer.Services;
using System.Windows.Forms;

namespace BusinessLogicLayer.Logics
{
    public class UsuarioBLL
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioBLL()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        public Usuario Authentication(string clave, string nombre)
        {
            Usuario usuario = _usuarioRepository.Authentication(CryptoService.Encode(clave), nombre);

            if (usuario != null)
            {
                return usuario;
            }

            return null;
        }

        public bool Delete(int id)
        {
            Usuario usuario = _usuarioRepository.GetUsuarioById(id);

            if (usuario != null)
            {
                try
                {
                    _usuarioRepository.DeleteUsuario(usuario);
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
            Usuario usuario = _usuarioRepository.GetUsuarioById(id);

            if (usuario != null)
            {
                return usuario;
            }

            return null;
        }

        public Usuario FindByName(string name)
        {
            Usuario usuario = _usuarioRepository.GetUsuarioByName(name);

            if (usuario != null)
            {
                return usuario;
            }

            return null;
        }

        public bool Create(Usuario usuario)
        {
            string hashPassword = CryptoService.Encode(usuario.Clave);

            usuario.Clave = hashPassword;

            try
            {
                _usuarioRepository.InsertUsuario(usuario);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Usuario usuario, bool cambiarClave)
        {
            if (cambiarClave)
            {
                string hashPassword = CryptoService.Encode(usuario.Clave);
                usuario.Clave = hashPassword;
            }

            try
            {
                _usuarioRepository.UpdateUsuario(usuario);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}