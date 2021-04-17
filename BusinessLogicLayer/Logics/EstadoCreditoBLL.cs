using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;
using DataAccessLayer;
using RepositoryLayer;


namespace BusinessLogicLayer.Logics
{
   public class EstadoCreditoBLL
    {
        private IEstadoCreditoRepository _estadocreditoRepository;

        public EstadoCreditoBLL()
        {
            _estadocreditoRepository = new EstadoCreditoRepository(new AzocDbContext());
        }

        public bool Delete(int id)
        {
            EstadoCredito estadocredito = _estadocreditoRepository.GetEstadoCreditoById(id);

            if (estadocredito != null)
            {
                try
                {
                    _estadocreditoRepository.DeleteEstadoCredito(estadocredito);
                    _estadocreditoRepository.Save();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }

        public IEnumerable<EstadoCredito> List()
        {
            return _estadocreditoRepository.GetEstadoCreditos();
        }

        public EstadoCredito Find(int id)
        {
            return _estadocreditoRepository.GetEstadoCreditoById(id);
        }

        public bool Create(EstadoCredito estadocredito)
        {
            try
            {
                _estadocreditoRepository.InsertEstadoCredito(estadocredito);
                _estadocreditoRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(EstadoCredito estadocredito)
        {
            try
            {
                _estadocreditoRepository.UpdateEstadoCredito(estadocredito);
                _estadocreditoRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
