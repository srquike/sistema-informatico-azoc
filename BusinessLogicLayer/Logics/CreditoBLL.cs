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
                _creditoRepository.DeleteCredito(credito);

                if (_creditoRepository.Save() == 0)
                {
                    return false;
                }
            }

            return true;
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
            _creditoRepository.InsertCredito(credito);

            if (_creditoRepository.Save() == 0)
            {
                return false;
            }

            return true;
        }

        public bool Edit(Credito credito)
        {
            _creditoRepository.UpdateCredito(credito);

            if (_creditoRepository.Save() == 0)
            {
                return false;
            }

            return true;
        }
    }
}
