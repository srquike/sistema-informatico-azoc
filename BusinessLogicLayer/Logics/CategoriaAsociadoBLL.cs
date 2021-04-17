using System;
using System.Collections.Generic;
using DataAccessLayer;
using RepositoryLayer;
using BusinessObjectsLayer.Models;


namespace BusinessLogicLayer.Logics
{
   public class CategoriaAsociadoBLL
    {
        private ICategoriaAsociadoRepository _categoriaasociadoRepository;

        public CategoriaAsociadoBLL()
        {
            _categoriaasociadoRepository = new CategoriaAsociadoRepository(new AzocDbContext());
        }

        public bool Delete(int id)
        {
            CategoriaAsociado categoriaasociado = _categoriaasociadoRepository.GetCategoriaAsociadoById(id);

            if (categoriaasociado != null)
            {
                try
                {
                    _categoriaasociadoRepository.DeleteCategoriaAsociado(categoriaasociado);
                    _categoriaasociadoRepository.Save();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }

        public IEnumerable<CategoriaAsociado> List()
        {
            return _categoriaasociadoRepository.GetCategoriaAsociados();
        }

        public CategoriaAsociado Find(int id)
        {
            return _categoriaasociadoRepository.GetCategoriaAsociadoById(id);
        }

        public bool Create(CategoriaAsociado categoriaasociado)
        {
            _categoriaasociadoRepository.InsertCategoriaAsociado(categoriaasociado);
            _categoriaasociadoRepository.Save();
            return true;
        }

        public bool Edit(CategoriaAsociado categoriaasociado)
        {
            try
            {
                _categoriaasociadoRepository.UpdateCategoriaAsociado(categoriaasociado);
                _categoriaasociadoRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
