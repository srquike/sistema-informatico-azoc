using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;
using DataAccessLayer;
using RepositoryLayer;


namespace BusinessLogicLayer.Logics
{
    public class AsociadoBLL
    {
        private IAsociadoRepository _asociadoRepository;

        public AsociadoBLL()
        {
            _asociadoRepository = new AsociadoRepository(new AzocDbContext());
        }

        public void Delete(int id)
        {
            Asociado asociado = _asociadoRepository.GetAsociadoById(id);

            _asociadoRepository.DeleteAsociado(asociado);
            _asociadoRepository.Save();
        }

        public IEnumerable<Asociado> List()
        {
            return _asociadoRepository.GetAsociados();
        }

        public Asociado Find(int id)
        {
            return _asociadoRepository.GetAsociadoById(id);
        }

        public void Create(Asociado asociado)
        {
            _asociadoRepository.InsertAsociado(asociado);
            _asociadoRepository.Save();
        }

        public void Edit(Asociado asociado)
        {
            _asociadoRepository.UpdateAsociado(asociado);
            _asociadoRepository.Save();
        }
    }
}
