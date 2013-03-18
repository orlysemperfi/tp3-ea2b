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
    public class EspecialidadBL:IEspecialidadBL
    {
        #region Constructor
        private readonly IEspecialidadDA instanciaDA;
        public EspecialidadBL()
        {
            instanciaDA = new EspecialidadDA();
        }
        #endregion

        public List<EspecialidadBE> ObtenerEspecialidades()
        {
            return instanciaDA.ObtenerEspecialidades();
        }

        public List<EspecialidadBE> ObtenerEspecialidadesxEmp(int codEmpleado)
        {
            return instanciaDA.ObtenerEspecialidadesxEmp(codEmpleado);
        }
    }
}
