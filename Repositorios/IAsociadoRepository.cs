using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;

namespace RepositoryLayer
{
    public interface IAsociadoRepository
    {
        IEnumerable<Socio> GetAsociados();
        Socio GetAsociadoById(int id);
        void InsertAsociado(Socio asociado);
        void DeleteAsociado(Socio asociado);
        void UpdateAsociado(Socio asociado);
    }
}
