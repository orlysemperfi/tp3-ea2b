using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TMD.GM.Entidades;

namespace TMD.GM.AccesoDatos.Contrato
{
    public interface IInformesDA
    {
        List<InformesBE> ObtenerInformes(int numero, int codigo_empleado, string observacion, DateTime fecha);
        DataTable ObtenerInformes_Orden(int codigo_empleado);
        DataTable Obtener_OrdenDetalle(string numero_orden);
        DataTable ObtenerInformes_OrdenDetalle(string numero_orden, int numero_informe);
        Int32 Informes_Orden_Insertar(DateTime fecha, int empleado, string observacion);
        void Informes_Orden_Actualizar(int numero, DateTime fecha, int empleado, string observacion);
        void Informes_Orden_Insertar_Detalle(int NUMERO_INFORME, int ITEM_INFORME, string NUMERO_ORDEN, int ITEM_ORDEN, string RESULTADO_ATENCION);
        void Informes_Orden_Eliminar_Detalle(int NUMERO_INFORME);
    }
}
