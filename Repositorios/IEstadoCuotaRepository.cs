using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;

namespace RepositoryLayer
{
    public interface IEstadoCuotaRepository: IDisposable
    {
        IEnumerable<EstadoCuota> GetEstadoCuotas();
        EstadoCuota GetEstadoCuotaById(int id);
        void InsertEstadoCuota(EstadoCuota estadocuota);
        void DeleteEstadoCuota(EstadoCuota estadocuota);
        void UpdateEstadoCuota(EstadoCuota estadocuota);
        void Save();
    }
}
