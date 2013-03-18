using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TMD.GM.AccesoDatos.Implementacion;
using TMD.GM.Entidades;
using TMD.GM.LogicaNegocios.Contrato;
using TMD.GM.AccesoDatos.Contrato;

namespace TMD.GM.LogicaNegocios.Implementacion
{
    public class InformesBL : IInformesBL
    {
        #region Constructor
        private readonly IInformesDA instanciaDA;
        //private readonly IInformesDA instanciaEspecialidadDA;
        public InformesBL()
        {
            instanciaDA = new InformesDA();
            //instanciaEspecialidadDA = new InformesDA();
        }
        #endregion

        public List<InformesBE> ObtenerInformes(int numero, int codigo_empleado, string observacion, DateTime fecha)
        {
            return instanciaDA.ObtenerInformes(numero, codigo_empleado, observacion, fecha);
        }

        public DataTable ObtenerInformes_Orden(int codigo_empleado)
        {
            return instanciaDA.ObtenerInformes_Orden(codigo_empleado);
        }

        public DataTable Obtener_OrdenDetalle(string numero_orden)
        {
            return instanciaDA.Obtener_OrdenDetalle(numero_orden);
        }

        public DataTable ObtenerInformes_OrdenDetalle(string numero_orden, int numero_informe)
        {
            return instanciaDA.ObtenerInformes_OrdenDetalle(numero_orden, numero_informe);
        }

        public Int32 Informes_Orden_Insertar(DateTime fecha, int empleado, string observacion)
        {
            int numero = instanciaDA.Informes_Orden_Insertar(fecha, empleado, observacion);

            return numero;
        }

        public void Informes_Orden_Actualizar(int numero, DateTime fecha, int empleado, string observacion)
        {
            instanciaDA.Informes_Orden_Actualizar(numero, fecha, empleado, observacion);
        }

        public void Informes_Orden_Insertar_Detalle(int NUMERO_INFORME, int ITEM_INFORME, string NUMERO_ORDEN, int ITEM_ORDEN, string RESULTADO_ATENCION)
        {
            instanciaDA.Informes_Orden_Insertar_Detalle(NUMERO_INFORME, ITEM_INFORME, NUMERO_ORDEN, ITEM_ORDEN, RESULTADO_ATENCION);
        }

        public void Informes_Orden_Eliminar_Detalle(int NUMERO_INFORME)
        {
            instanciaDA.Informes_Orden_Eliminar_Detalle(NUMERO_INFORME);
        }

    }
}
