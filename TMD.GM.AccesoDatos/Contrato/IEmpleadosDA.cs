using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.GM.Entidades;

namespace TMD.GM.AccesoDatos.Contrato
{
    public interface IEmpleadosDA
    {
        List<EmpleadosBE> ObtenerEmpleados(string nombres);
        int Registrar_Actividad(int empleado, int actividad);
        void Eliminar_Actividad_Empleado(int empleado, int actividad);
        void Especialidad_Actividad_Empleado(int empleado, int actividad, bool especialidad);
    }
}
