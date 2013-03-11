﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.ACP.AccesoDatos.Contrato
{
    public interface IHallazgoData
    {
        int Agregar(Hallazgo hallazgo);
        void Modificar(Hallazgo hallazgo);
        void Eliminar(int idHallazgo);
        List<Hallazgo> Obtener(Hallazgo filtro);
    }
}