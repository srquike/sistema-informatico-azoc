using System;
using BusinessObjectsLayer.Models;
using System.Collections.Generic;


namespace RepositoryLayer
{
    public interface ICuotaRepository : IDisposable
    {
        IEnumerable<Cuota> GetCuotas();
        Cuota GetCuotaById(int id);
        void InsertCuota(Cuota cuota);
        void DeleteCuota(Cuota cuota);
        void UpdateCuota(Cuota cuota);
        int Save();
        void InsertMany(ICollection<Cuota> cuotas);
    }
}
