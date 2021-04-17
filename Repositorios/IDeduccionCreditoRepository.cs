using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;

namespace RepositoryLayer
{
    public interface IDeduccionCreditopository: IDisposable
    {
        IEnumerable<DeduccionCredito> GetDeduccionCreditos();
        DeduccionCredito GetDeduccionCreditoById(int id);
        void InsertDeduccionCredito(DeduccionCredito deduccioncredito);
        void DeleteDeduccionCredito(DeduccionCredito deduccioncredito);
        void UpdateDeduccionCredito(DeduccionCredito deduccioncredito);
        void Save();
    }
}
