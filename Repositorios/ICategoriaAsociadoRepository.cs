using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;

namespace RepositoryLayer
{
   public interface ICategoriaAsociadoRepository:IDisposable
    {
        IEnumerable<CategoriaAsociado> GetCategoriaAsociados();
        CategoriaAsociado GetCategoriaAsociadoById(int id);
        void InsertCategoriaAsociado(CategoriaAsociado categoriaasociado);
        void DeleteCategoriaAsociado(CategoriaAsociado categoriaasociado);
        void UpdateCategoriaAsociado(CategoriaAsociado categoriaasociado);
        void Save();
    }
}
