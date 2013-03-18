using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.GM.AccesoDatos.Implementacion;
using TMD.GM.Entidades;
using TMD.GM.LogicaNegocios.Contrato;
using TMD.GM.AccesoDatos.Contrato;

namespace TMD.GM.LogicaNegocios.Implementacion
{
    public class EquipoBL:IEquipoBL
    {
        #region Constructor
        private readonly IEquipoDA instanciaDA;
        public EquipoBL()
        {
            instanciaDA = new EquipoDA();
        }
        #endregion

        public List<EquipoBE> BuscarEquipos()
        {
            return instanciaDA.BuscarEquipos();
        }

    }
}
