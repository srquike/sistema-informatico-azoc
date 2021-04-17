using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;

namespace RepositoryLayer
{
    public interface ICreditoRepository : IDisposable
    {
        IEnumerable<Credito> GetCreditos();
        Credito GetCreditoById(int id);
        void InsertCredito(Credito credito);
        void DeleteCredito(Credito credito);
        void UpdateCredito(Credito credito);
        void Save();

        void Prueba();
    }
}
