using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;

namespace RepositoryLayer
{
    public interface IRegistroRepository : IDisposable
    {
        IEnumerable<Registro> GetRegistros();
        Registro GetRegistroById(int id);
        void InsertRegistro(Registro registro);
        void DeleteRegistro(Registro registro);
        void UpdateRegistro(Registro registro);
        void Save();
    }
}
