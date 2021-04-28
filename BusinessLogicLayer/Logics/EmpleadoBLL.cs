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
                _empleadoRepository.Save();
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

        public void Create(Empleado empleado)
        {
            _empleadoRepository.InsertEmpleado(empleado);
            _empleadoRepository.Save();
        }

        public void Edit(Empleado empleado)
        {
            _empleadoRepository.UpdateEmpleado(empleado);
            _empleadoRepository.Save();
        }
    }
}
