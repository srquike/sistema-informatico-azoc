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

        public void Delete(int id)
        {
            Socio asociado = _asociadoRepository.GetAsociadoById(id);

            _asociadoRepository.DeleteAsociado(asociado);
            _asociadoRepository.Save();
        }

        public IEnumerable<Socio> List()
        {
            return _asociadoRepository.GetAsociados();
        }

        public Socio Find(int id)
        {
            return _asociadoRepository.GetAsociadoById(id);
        }

        public void Create(Socio asociado)
        {
            _asociadoRepository.InsertAsociado(asociado);
            _asociadoRepository.Save();
        }

        public void Edit(Socio asociado)
        {
            _asociadoRepository.UpdateAsociado(asociado);
            _asociadoRepository.Save();
        }
    }
}
