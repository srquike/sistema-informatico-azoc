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
                try
                {
                    _registroUsuarioRepository.DeleteRegistroUsuario(registroUsuario);
                    _registroUsuarioRepository.Save();
                    return true;
                }
                catch (Exception)
                {
                    return false;
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
            return _registroUsuarioRepository.GetRegistroUsuarioById(id);
        }

        public void Create(RegistroUsuario registroUsuario)
        {
            _registroUsuarioRepository.InsertRegistroUsuario(registroUsuario);
            _registroUsuarioRepository.Save();
        }

        public bool Edit(RegistroUsuario registroUsuario)
        {
            try
            {
                _registroUsuarioRepository.UpdateRegistroUsuario(registroUsuario);
                _registroUsuarioRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
