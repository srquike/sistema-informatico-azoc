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
            _empleadoRepository = new EmpleadoRepository();
        }

        public bool Delete(int id)
        {
            Empleado empleado = _empleadoRepository.GetEmpleadoById(id);

            if (empleado != null)
            {
                try
                {
                    _empleadoRepository.DeleteEmpleado(empleado);
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
            Empleado empleado = _empleadoRepository.GetEmpleadoById(id);

            if (empleado != null)
            {
                return empleado;
            }

            return null;
        }

        public bool Create(Empleado empleado)
        {
            try
            {
                _empleadoRepository.InsertEmpleado(empleado);
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
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
