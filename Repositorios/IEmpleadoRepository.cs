using BusinessObjectsLayer.Models;
using System;
using System.Collections.Generic;

namespace RepositoryLayer
{
    public interface IEmpleadoRepository : IDisposable
    {
        IEnumerable<Empleado> GetEmpleados();
        Empleado GetEmpleadoById(int id);
        void InsertEmpleado(Empleado empleado);
        void DeleteEmpleado(Empleado empleado);
        void UpdateEmpleado(Empleado empleado);
        void Save();
    }
}
