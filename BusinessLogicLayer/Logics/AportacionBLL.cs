using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;
using DataAccessLayer;
using RepositoryLayer;


namespace BusinessLogicLayer.Logics
{
   public  class AportacionBLL
    {
        private IAportacionRepository _aportacionRepository;

        public AportacionBLL()
        {
            _aportacionRepository = new AportacionRepository(new AzocDbContext());
        }

        public bool Delete(int id)
        {
            Aportacion aportacion = _aportacionRepository.GetAportacionById(id);

            if (aportacion != null)
            {
                try
                {
                    _aportacionRepository.DeleteAportacion(aportacion);
                    _aportacionRepository.Save();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }

        public IEnumerable<Aportacion> List()
        {
            return _aportacionRepository.GetAportacions();
        }

        public Aportacion Find(int id)
        {
            return _aportacionRepository.GetAportacionById(id);
        }

        public bool Create(Aportacion aportacion)
        {
            try
            {
                _aportacionRepository.InsertAportacion(aportacion);
                _aportacionRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Aportacion aportacion)
        {
            try
            {
                _aportacionRepository.UpdateAportacion(aportacion);
                _aportacionRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
