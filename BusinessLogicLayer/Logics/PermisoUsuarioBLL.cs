using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using RepositoryLayer;
using BusinessObjectsLayer.Models;

namespace BusinessLogicLayer.Logics
{
    public class PermisoUsuarioBLL
    {
        private IPermisoUsuarioRepository _permisoUsuarioRepository;

        public PermisoUsuarioBLL()
        {
            _permisoUsuarioRepository = new PermisoUsuarioRepository(new AzocDbContext());
        }

        public bool Delete(int id)
        {
            PermisoUsuario permisoUsuario = _permisoUsuarioRepository.GetPermisoUsuarioById(id);

            if (permisoUsuario != null)
            {
                try
                {
                    _permisoUsuarioRepository.DeletePermisoUsuario(permisoUsuario);
                    _permisoUsuarioRepository.Save();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }

        public IEnumerable<PermisoUsuario> List()
        {
            return _permisoUsuarioRepository.GetPermisosUsuario();
        }

        public PermisoUsuario Find(int id)
        {
            return _permisoUsuarioRepository.GetPermisoUsuarioById(id);
        }

        public bool Create(PermisoUsuario permisoUsuario)
        {
            _permisoUsuarioRepository.InsertPermisoUsuario(permisoUsuario);
            _permisoUsuarioRepository.Save();
            return true;
        }

        public bool Edit(PermisoUsuario permisoUsuario)
        {
            try
            {
                _permisoUsuarioRepository.UpdatePermisoUsuario(permisoUsuario);
                _permisoUsuarioRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
