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
            _asociadoRepository = new SocioRepository(new AzocDbContext());
        }

        public bool Delete(int id)
        {
            Socio asociado = _asociadoRepository.GetAsociadoById(id);

            _asociadoRepository.DeleteAsociado(asociado);

            if (_asociadoRepository.Save() == 0)
            {
                return false;
            }

            return true;
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
            _asociadoRepository.InsertAsociado(asociado);

            if (_asociadoRepository.Save() == 0)
            {
                return false;
            }

            return true;
        }

        public bool Edit(Socio asociado)
        {
            _asociadoRepository.UpdateAsociado(asociado);

            if (_asociadoRepository.Save() == 0)
            {
                return false;
            }

            return true;
        }

        public Socio FindByCode(string code)
        {
            return _asociadoRepository.GetSocioByCode(code);
        }
    }
}
