using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.GM.Entidades;

namespace TMD.GM.LogicaNegocios.Contrato
{
    public interface IEquipoBL
    {
        List<EquipoBE> BuscarEquipos();
        List<EquipoBE> ListarEquiposTodos(EquipoBE equipoBE);
        void Registrar(EquipoBE equipoBE);
        void Actualizar(EquipoBE equipoBE);
        void Eliminar(EquipoBE equipoBE);
        EquipoBE Visualizar(EquipoBE equipoBE);
    }
}
