using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;
using DataAccessLayer;
using RepositoryLayer;


namespace BusinessLogicLayer.Logics
{
    public class SocioBLL
    {
        private IAsociadoRepository _asociadoRepository;

        public SocioBLL()
        {
            _asociadoRepository = new SocioRepository();
        }

        public bool Delete(int id)
        {
            Socio asociado = _asociadoRepository.GetAsociadoById(id);

            if (asociado != null)
            {
                try
                {
                    _asociadoRepository.DeleteAsociado(asociado);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }

        public IEnumerable<Socio> List()
        {
            return _asociadoRepository.GetAsociados();
        }

        public Socio Find(int id)
        {
            return _asociadoRepository.GetAsociadoById(id);
        }

        public bool Create(Socio asociado)
        {
            try
            {
                _asociadoRepository.InsertAsociado(asociado);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Socio asociado)
        {
            try
            {
                _asociadoRepository.UpdateAsociado(asociado);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
