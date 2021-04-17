using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;

namespace RepositoryLayer
{
   public interface IEstadoCreditoRepository:IDisposable
    {
        IEnumerable<EstadoCredito> GetEstadoCreditos();
        EstadoCredito GetEstadoCreditoById(int id);
        void InsertEstadoCredito(EstadoCredito estadocredito);
        void DeleteEstadoCredito(EstadoCredito estadocredito);
        void UpdateEstadoCredito(EstadoCredito estadocredito);
        void Save();
    }
}
