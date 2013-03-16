using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TMD.Entidades;
using TMD.ACP.AccesoDatos.Util;

namespace TMD.ACP.AccesoDatos.Map
{
    class EntidadAuditadaDataMap
    {
        public static EntidadAuditada SelectEntidadAuditada(IDataReader reader)
        {
            EntidadAuditada objEntidadAuditada = new EntidadAuditada();

            objEntidadAuditada.IdEntidadAuditada = reader.GetInt("IdEntidadAuditada");
            objEntidadAuditada.NombreEntidadAuditada = reader.GetString("NombreEntidadAuditada");
            objEntidadAuditada.ObjArea.codigo = reader.GetInt("codigoArea");
            objEntidadAuditada.ObjArea.descripcion = reader.GetString("descripcionArea");
            objEntidadAuditada.criticidad = reader.GetInt("criticidad");
            objEntidadAuditada.riesgo = reader.GetInt("riesgo");
            objEntidadAuditada.alcance = reader.GetInt("alcance");
            objEntidadAuditada.nroseguimiento = reader.GetInt("nroseguimiento");
            objEntidadAuditada.nroauditorias = reader.GetInt("nroauditorias");
            objEntidadAuditada.puntaje = reader.GetInt("puntaje");

            return objEntidadAuditada;
        }
    }
}
