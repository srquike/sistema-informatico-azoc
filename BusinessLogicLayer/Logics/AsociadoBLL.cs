using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;
using DataAccessLayer;
using RepositoryLayer;


namespace BusinessLogicLayer.Logics
{
  public  class AsociadoBLL
    {
        private IAsociadoRepository _asociadoRepository;

        public AsociadoBLL()
        {
            _asociadoRepository = new AsociadoRepository(new AzocDbContext());
        }

        public bool Delete(int id)
        {
            Asociado asociado = _asociadoRepository.GetAsociadoById(id);

            if (asociado != null)
            {
                try
                {
                    _asociadoRepository.DeleteAsociado(asociado);
                    _asociadoRepository.Save();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }
        public IEnumerable<Asociado> List()
        {
            return _asociadoRepository.GetAsociados();
        }

        public Asociado Find(int id)
        {
            return _asociadoRepository.GetAsociadoById(id);
        }

        public bool Create(Asociado asociado)
        {
            try
            {
                _asociadoRepository.InsertAsociado(asociado);
                _asociadoRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Asociado asociado)
        {
            try
            {
                _asociadoRepository.UpdateAsociado(asociado);
                _asociadoRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
