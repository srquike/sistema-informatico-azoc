using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;
using DataAccessLayer;
using RepositoryLayer;

namespace BusinessLogicLayer.Logics
{
  public  class CargoBLL
    {
        private ICargoRepository _cargoRepository;

        public CargoBLL()
        {
            _cargoRepository = new CargoRepository();
        }

        public bool Delete(int id)
        {
            Cargo cargo = _cargoRepository.GetCargoById(id);

            if (cargo != null)
            {
                try
                {
                    _cargoRepository.DeleteCargo(cargo);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }

        public IEnumerable<Cargo> List()
        {
            return _cargoRepository.GetCargos();
        }

        public Cargo Find(int id)
        {
            return _cargoRepository.GetCargoById(id);
        }

        public bool Create(Cargo cargo)
        {
            try
            {
                _cargoRepository.InsertCargo(cargo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Cargo cargo)
        {
            try
            {
                _cargoRepository.UpdateCargo(cargo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
