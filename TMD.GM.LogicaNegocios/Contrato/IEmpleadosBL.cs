using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.GM.Entidades;

namespace TMD.GM.LogicaNegocios.Contrato
{
    public interface IEmpleadosBL
    {
        List<EmpleadosBE> ObtenerEmpleados(string nombres);
        List<EspecialidadBE> RegistrarActividad(int empleado, int actividad, ref string mensaje, ref bool registrado);
        void Eliminar_Actividad_Empleado(int empleado, int actividad);
        void Especialidad_Actividad_Empleado(int empleado, int actividad, bool especialidad);
    }
}
