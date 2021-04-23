using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;
using DataAccessLayer;
using RepositoryLayer;

namespace BusinessLogicLayer.Logics
{
    public class RegistroBLL
    {
        private IRegistroRepository _registroRepository;

        public RegistroBLL()
        {
            _registroRepository = new RegistroRepository(new AzocDbContext());
        }

        public bool Delete(int id)
        {
            Registro registro = _registroRepository.GetRegistroById(id);

            if (registro != null)
            {
                try
                {
                    _registroRepository.DeleteRegistro(registro);
                    _registroRepository.Save();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }

        public IEnumerable<Registro> List()
        {
            return _registroRepository.GetRegistros();
        }

        public Registro Find(int id)
        {
            return _registroRepository.GetRegistroById(id);
        }

        public bool Create(Registro registro)
        {
            try
            {
                _registroRepository.InsertRegistro(registro);
                _registroRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Registro registro)
        {
            try
            {
                _registroRepository.UpdateRegistro(registro);
                _registroRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
