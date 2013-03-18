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
    public class EmpleadosBL : IEmpleadosBL
    {
        #region Constructor
        private readonly IEmpleadosDA instanciaDA;
        private readonly IEspecialidadDA instanciaEspecialidadDA;
        public EmpleadosBL()
        {
            instanciaDA = new EmpleadosDA();
            instanciaEspecialidadDA = new EspecialidadDA();
        }
        #endregion

        public List<EmpleadosBE> ObtenerEmpleados(string nombres)
        {
            return instanciaDA.ObtenerEmpleados(nombres);
        }

        public List<EspecialidadBE> RegistrarActividad(int empleado, int actividad, ref string mensaje, ref bool registrado)
        {
            registrado = false;
            int registros = instanciaDA.Registrar_Actividad(empleado, actividad);

            if (registros == 0)
            {
                List<EspecialidadBE> lista = instanciaEspecialidadDA.ObtenerEspecialidadesxEmp(empleado);
                mensaje = "Acividad Asignada.";
                registrado = true;
                return lista;
            }
            else
            {
                mensaje = "Imposible, la Acividad ya fue asignada anteriormente.";
                return null;
            }
        }

        public void Eliminar_Actividad_Empleado(int empleado, int actividad)
        {
            instanciaDA.Eliminar_Actividad_Empleado(empleado, actividad);
        }

        public void Especialidad_Actividad_Empleado(int empleado, int actividad, bool especialidad)
        {
            instanciaDA.Especialidad_Actividad_Empleado(empleado, actividad, especialidad);
        }
    }
}
