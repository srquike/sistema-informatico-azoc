using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;
using DataAccessLayer;
using RepositoryLayer;

namespace BusinessLogicLayer.Logics
{
   public class DeducccionCreditoBLL
    {
        private IDeduccionCreditoRepository _deduccioncreditoRepository;

        public DeducccionCreditoBLL()
        {
            _deduccioncreditoRepository = new DeduccionCreditoRepository(new AzocDbContext());
        }

        public bool Delete(int id)
        {
            DeduccionCredito deduccioncredito = _deduccioncreditoRepository.GetDeduccionCreditoById(id);

            if (deduccioncredito != null)
            {
                try
                {
                    _deduccioncreditoRepository.DeleteDeduccionCredito(deduccioncredito);
                    _deduccioncreditoRepository.Save();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }

        public IEnumerable<DeduccionCredito> List()
        {
            return _deduccioncreditoRepository.GetDeduccionCreditos();
        }

        public DeduccionCredito Find(int id)
        {
            return _deduccioncreditoRepository.GetDeduccionCreditoById(id);
        }

        public bool Create(DeduccionCredito deduccioncredito)
        {
            try
            {
                _deduccioncreditoRepository.InsertDeduccionCredito(deduccioncredito);
                _deduccioncreditoRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(DeduccionCredito deduccioncredito)
        {
            try
            {
                _deduccioncreditoRepository.UpdateDeduccionCredito(deduccioncredito);
                _deduccioncreditoRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
