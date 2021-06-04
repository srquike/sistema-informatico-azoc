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
            _usuarioRepository = new UsuarioRepository(new AzocDbContext());
        }

        public Usuario Authentication(string password, string nombre)
        {
            string hashPassword = CryptoService.Encode(password);

            Usuario usuario = _usuarioRepository.Authentication(hashPassword, nombre);

            return usuario;
        }

        public bool Delete(int id)
        {
            Usuario usuario = _usuarioRepository.GetUsuarioById(id);

            if (usuario != null)
            {
                _usuarioRepository.DeleteUsuario(usuario);

                if (_usuarioRepository.Save() == 0)
                {
                    return false;
                }
                else
                {
                    return true;
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

            _usuarioRepository.InsertUsuario(usuario);

            if (_usuarioRepository.Save() == 0)
            {
                return false;
            }

            return true;
        }

        public bool Edit(Usuario usuario, bool cambiarClave)
        {
            if (cambiarClave)
            {
                string hashPassword = CryptoService.Encode(usuario.Clave);
                usuario.Clave = hashPassword;
            }

            _usuarioRepository.UpdateUsuario(usuario);

            if (_usuarioRepository.Save() == 0)
            {
                return false;
            }

            return true;
        }
    }
}