using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;
using DataAccessLayer;
using RepositoryLayer;

namespace BusinessLogicLayer.Logics
{
    public class BeneficiarioBLL
    {
        private IBeneficiarioRepository _beneficiarioRepository;

        public BeneficiarioBLL()
        {
            _beneficiarioRepository = new BeneficiarioRepository(new AzocDbContext());
        }

        public bool Delete(int id)
        {
            Beneficiario beneficiario = _beneficiarioRepository.GetBeneficiarioById(id);

            if (beneficiario != null)
            {
                _beneficiarioRepository.DeleteBeneficiario(beneficiario);

                if (_beneficiarioRepository.Save() == 0)
                {
                    return false;
                }

                return true;
            }

            return false;
        }
        public IEnumerable<Beneficiario> List()
        {
            return _beneficiarioRepository.GetBeneficiarios();
        }

        public Beneficiario Find(int id)
        {
            return _beneficiarioRepository.GetBeneficiarioById(id);
        }

        public bool Create(Beneficiario beneficiario)
        {
            _beneficiarioRepository.InsertBeneficiario(beneficiario);

            if (_beneficiarioRepository.Save() == 0)
            {
                return false;
            }

            return true;
        }

        public bool CreateMany(ICollection<Beneficiario> beneficiarios)
        {
            _beneficiarioRepository.InsertMany(beneficiarios);

            if (_beneficiarioRepository.Save() == 0)
            {
                return false;
            }

            return true;
        }

        public bool Edit(Beneficiario beneficiario)
        {
            _beneficiarioRepository.UpdateBeneficiario(beneficiario);

            if (_beneficiarioRepository.Save() == 0)
            {
                return false;
            }

            return true;
        }
    }
}