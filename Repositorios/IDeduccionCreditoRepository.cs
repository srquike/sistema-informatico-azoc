using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;

namespace RepositoryLayer
{
    public interface IDeduccionCreditoRepository: IDisposable
    {
        IEnumerable<DeduccionCredito> GetDeduccionCreditos();
        DeduccionCredito GetDeduccionCreditoById(int id);
        void InsertDeduccionCredito(DeduccionCredito deduccioncredito);
        void InsertMany(ICollection<DeduccionCredito> deduccionesCreditos);
        void DeleteDeduccionCredito(DeduccionCredito deduccioncredito);
        void UpdateDeduccionCredito(DeduccionCredito deduccioncredito);
        int Save();
    }
}
