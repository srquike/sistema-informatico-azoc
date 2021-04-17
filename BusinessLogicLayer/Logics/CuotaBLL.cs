using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;
using DataAccessLayer;
using RepositoryLayer;


namespace BusinessLogicLayer.Logics
{
  public  class CuotaBLL
    {
        private ICuotaRepository _cuotaRepository;

        public CuotaBLL()
        {
            _cuotaRepository = new CuotaRepository(new AzocDbContext());
        }

        public bool Delete(int id)
        {
            Cuota cuota = _cuotaRepository.GetCuotaById(id);

            if (cuota != null)
            {
                try
                {
                    _cuotaRepository.DeleteCuota(cuota);
                    _cuotaRepository.Save();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }

        public IEnumerable<Cuota> List()
        {
            return _cuotaRepository.GetCuotas();
        }

        public Cuota Find(int id)
        {
            return _cuotaRepository.GetCuotaById(id);
        }

        public bool Create(Cuota cuota)
        {
            try
            {
                _cuotaRepository.InsertCuota(cuota);
                _cuotaRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Cuota cuota)
        {
            try
            {
                _cuotaRepository.UpdateCuota(cuota);
                _cuotaRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
