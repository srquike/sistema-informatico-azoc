﻿using System;
using System.Collections.Generic;
using BusinessObjectsLayer.Models;

namespace RepositoryLayer
{
    public interface IAsociadoRepository : IDisposable
    {
        IEnumerable<Socio> GetAsociados();
        Socio GetAsociadoById(int id);
        Socio GetSocioByCode(string code);
        void InsertAsociado(Socio asociado);
        void DeleteAsociado(Socio asociado);
        void UpdateAsociado(Socio asociado);
        int Save();
    }
}
