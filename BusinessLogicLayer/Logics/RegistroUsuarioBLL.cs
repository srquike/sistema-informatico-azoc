using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;
using DataAccessLayer;
using RepositoryLayer;

namespace BusinessLogicLayer.Logics
{
    public class RegistroUsuarioBLL
    {
        private IRegistroUsuarioRepository _registroUsuarioRepository;

        public RegistroUsuarioBLL()
        {
            _registroUsuarioRepository = new RegistroUsuarioRepository(new AzocDbContext());
        }

        public bool Delete(int id)
        {
            RegistroUsuario registroUsuario = _registroUsuarioRepository.GetRegistroUsuarioById(id);

            if (registroUsuario != null)
            {
                _registroUsuarioRepository.DeleteRegistroUsuario(registroUsuario);

                if (_registroUsuarioRepository.Save() == 0)
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

        public IEnumerable<RegistroUsuario> List()
        {
            return _registroUsuarioRepository.GetRegistroUsuarios();
        }

        public RegistroUsuario Find(int id)
        {
            RegistroUsuario registro = _registroUsuarioRepository.GetRegistroUsuarioById(id);

            if (registro != null)
            {
                return registro;
            }

            return null;
        }

        public bool Create(RegistroUsuario registroUsuario)
        {
            _registroUsuarioRepository.InsertRegistroUsuario(registroUsuario);

            if (_registroUsuarioRepository.Save() == 0)
            {
                return false;
            }

            return true;
        }

        public bool Edit(RegistroUsuario registroUsuario)
        {
            _registroUsuarioRepository.UpdateRegistroUsuario(registroUsuario);

            if (_registroUsuarioRepository.Save() == 0)
            {
                return false;
            }

            return true;
        }
    }
}
