﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.GM.Entidades;

namespace TMD.GM.AccesoDatos.Contrato
{
    public interface IEquipoDA
    {
        List<EquipoBE> BuscarEquipos(EquipoBE equipoBE);
        List<EquipoBE> ListarEquiposTodos(EquipoBE equipoBE);
        void Registrar(EquipoBE equipoBE);
        void Actualizar(EquipoBE equipoBE);
        void Eliminar(EquipoBE equipoBE);
        EquipoBE Visualizar(EquipoBE equipoBE);
    }
}
