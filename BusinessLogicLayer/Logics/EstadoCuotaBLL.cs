using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;
using DataAccessLayer;
using RepositoryLayer;

namespace BusinessLogicLayer.Logics
{
   public class EstadoCuotaBLL
    {
        private IEstadoCuotaRepository _estadocuotaRepository;

        public EstadoCuotaBLL()
        {
            _estadocuotaRepository = new EstadoCuotaRepository(new AzocDbContext());
        }

        public bool Delete(int id)
        {
            EstadoCuota estadocuota = _estadocuotaRepository.GetEstadoCuotaById(id);

            if (estadocuota != null)
            {
                try
                {
                    _estadocuotaRepository.DeleteEstadoCuota(estadocuota);
                    _estadocuotaRepository.Save();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }

        public IEnumerable<EstadoCuota> List()
        {
            return _estadocuotaRepository.GetEstadoCuotas();
        }

        public EstadoCuota Find(int id)
        {
            return _estadocuotaRepository.GetEstadoCuotaById(id);
        }

        public bool Create(EstadoCuota estadocuota)
        {
            try
            {
                _estadocuotaRepository.InsertEstadoCuota(estadocuota);
                _estadocuotaRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(EstadoCuota estadocuota)
        {
            try
            {
                _estadocuotaRepository.UpdateEstadoCuota(estadocuota);
                _estadocuotaRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
