using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;

namespace RepositoryLayer
{
   public  interface IBeneficiarioRepository:IDisposable
    {
        IEnumerable<Beneficiario> GetBeneficiarios();
        Beneficiario GetBeneficiarioById(int id);
        void InsertBeneficiario(Beneficiario beneficiario);
        void DeleteBeneficiario(Beneficiario beneficiario);
        void UpdateBeneficiario(Beneficiario beneficiario);
        void Save();

    }
}
