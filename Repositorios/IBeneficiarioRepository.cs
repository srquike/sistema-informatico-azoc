using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;

namespace RepositoryLayer
{
   public  interface IBeneficiarioRepository
    {
        IEnumerable<Beneficiario> GetBeneficiarios();
        Beneficiario GetBeneficiarioById(int id);
        void InsertBeneficiario(Beneficiario beneficiario);
        void InsertMany(ICollection<Beneficiario> beneficiarios);
        void DeleteBeneficiario(Beneficiario beneficiario);
        void UpdateBeneficiario(Beneficiario beneficiario);
    }
}
