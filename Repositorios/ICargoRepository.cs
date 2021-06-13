using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;

namespace RepositoryLayer
{
   public interface ICargoRepository
    {
        IEnumerable<Cargo> GetCargos();
        Cargo GetCargoById(int id);
        void InsertCargo(Cargo cargo);
        void DeleteCargo(Cargo cargo);
        void UpdateCargo(Cargo cargo);
    }
}
