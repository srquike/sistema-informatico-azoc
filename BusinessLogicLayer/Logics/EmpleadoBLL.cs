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
                _empleadoRepository.DeleteEmpleado(empleado);

                if (_empleadoRepository.Save() == 0)
                {
                    return false;
                }

                return true;
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
            _empleadoRepository.InsertEmpleado(empleado);

            if (_empleadoRepository.Save() == 0)
            {
                return false;
            }

            return true;
        }

        public bool Edit(Empleado empleado)
        {
            _empleadoRepository.UpdateEmpleado(empleado);

            if (_empleadoRepository.Save() == 0)
            {
                return false;
            }

            return true;
        }
    }
}
