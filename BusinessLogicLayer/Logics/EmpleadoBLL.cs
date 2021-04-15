using BusinessObjectsLayer.Models;
using DataAccessLayer;
using RepositoryLayer;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Logics
{
    public class EmpleadoBLL
    {
        private IEmpleadoRepository _empleadoRepository;

        public EmpleadoBLL()
        {
            _empleadoRepository = new EmpleadoRepository(new AzocDbContext());
        }

        public bool Delete(int id)
        {
            Empleado empleado = _empleadoRepository.GetEmpleadoById(id);

            if (empleado != null)
            {
                try
                {
                    _empleadoRepository.DeleteEmpleado(empleado);
                    _empleadoRepository.Save();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }

        public IEnumerable<Empleado> List()
        {
            return _empleadoRepository.GetEmpleados();
        }

        public Empleado Find(int id)
        {
            return _empleadoRepository.GetEmpleadoById(id);
        }

        public bool Create(Empleado empleado)
        {
            try
            {
                _empleadoRepository.InsertEmpleado(empleado);
                _empleadoRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Empleado empleado)
        {
            try
            {
                _empleadoRepository.UpdateEmpleado(empleado);
                _empleadoRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
