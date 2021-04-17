using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsLayer.Models;
using DataAccessLayer;
using RepositoryLayer;

namespace BusinessLogicLayer.Logics
{
  public  class PermisoBLL
    {
        private IPermisoRepository _permisoRepository;

        public PermisoBLL()
        {
            _permisoRepository = new PermisoRepository(new AzocDbContext());
        }

        public bool Delete(int id)
        {
            Permiso permiso = _permisoRepository.GetPermisoById(id);

            if (permiso != null)
            {
                try
                {
                    _permisoRepository.DeletePermiso(permiso);
                    _permisoRepository.Save();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }

        public IEnumerable<Permiso> List()
        {
            return _permisoRepository.GetPermisos();
        }

        public Permiso Find(int id)
        {
            return _permisoRepository.GetPermisoById(id);
        }

        public bool Create(Permiso permiso)
        {
            try
            {
                _permisoRepository.InsertPermiso(permiso);
                _permisoRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Permiso permiso)
        {
            try
            {
                _permisoRepository.UpdatePermiso(permiso);
                _permisoRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
