using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;
using DataAccessLayer;
using RepositoryLayer;

namespace BusinessLogicLayer.Logics
{
   public class TipoCuotaBLL
    {
        private ITipoCuotaRepository _tipocuotaRepository;

        public TipoCuotaBLL()
        {
            _tipocuotaRepository = new TipoCuotaRepository(new AzocDbContext());
        }

        public bool Delete(int id)
        {
            TipoCuota tipocuota = _tipocuotaRepository.GetTipoCuotaById(id);

            if (tipocuota != null)
            {
                try
                {
                    _tipocuotaRepository.DeleteTipoCuota(tipocuota);
                    _tipocuotaRepository.Save();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }

        public IEnumerable<TipoCuota> List()
        {
            return _tipocuotaRepository.GetTipoCuotas();
        }

        public TipoCuota Find(int id)
        {
            return _tipocuotaRepository.GetTipoCuotaById(id);
        }

        public bool Create(TipoCuota tipocuota)
        {
            try
            {
                _tipocuotaRepository.InsertTipoCuota(tipocuota);
                _tipocuotaRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(TipoCuota tipocuota)
        {
            try
            {
                _tipocuotaRepository.UpdateTipoCuota(tipocuota);
                _tipocuotaRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
