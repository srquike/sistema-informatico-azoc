using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;
using DataAccessLayer;
using RepositoryLayer;

namespace BusinessLogicLayer.Logics
{
    public class CreditoBLL
    {
        private ICreditoRepository _creditoRepository;

        public CreditoBLL()
        {
            _creditoRepository = new CreditoRepository(new AzocDbContext());
        }

        public bool Delete(int id)
        {
            Credito credito = _creditoRepository.GetCreditoById(id);

            if (credito != null)
            {
                try
                {
                    _creditoRepository.DeleteCredito(credito);
                    _creditoRepository.Save();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }

        public IEnumerable<Credito> List()
        {
            return _creditoRepository.GetCreditos();
        }

        public Credito Find(int id)
        {
            return _creditoRepository.GetCreditoById(id);
        }

        public bool Create(Credito credito)
        {
            try
            {
                _creditoRepository.InsertCredito(credito);
                _creditoRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Credito credito)
        {
            try
            {
                _creditoRepository.UpdateCredito(credito);
                _creditoRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
