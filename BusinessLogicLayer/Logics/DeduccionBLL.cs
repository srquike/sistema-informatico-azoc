using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;
using DataAccessLayer;
using RepositoryLayer;

namespace BusinessLogicLayer.Logics
{
   public class DeduccionBLL
    {
        private IDeduccionRepository _deduccionRepository;

        public DeduccionBLL()
        {
            _deduccionRepository = new DeduccionRepository(new AzocDbContext());
        }

        public bool Delete(int id)
        {
            Deduccion deduccion = _deduccionRepository.GetDeduccionById(id);

            if (deduccion != null)
            {
                try
                {
                    _deduccionRepository.DeleteDeduccion(deduccion);
                    _deduccionRepository.Save();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }

        public IEnumerable<Deduccion> List()
        {
            return _deduccionRepository.GetDeduccions();
        }

        public Deduccion Find(int id)
        {
            return _deduccionRepository.GetDeduccionById(id);
        }

        public bool Create(Deduccion deduccion)
        {
            try
            {
                _deduccionRepository.InsertDeduccion(deduccion);
                _deduccionRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Deduccion deduccion)
        {
            try
            {
                _deduccionRepository.UpdateDeduccion(deduccion);
                _deduccionRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
