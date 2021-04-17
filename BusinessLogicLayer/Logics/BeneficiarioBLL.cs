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
                try
                {
                    _beneficiarioRepository.DeleteBeneficiario(beneficiario);
                    _beneficiarioRepository.Save();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
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
            try
            {
                _beneficiarioRepository.InsertBeneficiario(beneficiario);
                _beneficiarioRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Beneficiario beneficiario)
        {
            try
            {
                _beneficiarioRepository.UpdateBeneficiario(beneficiario);
                _beneficiarioRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}