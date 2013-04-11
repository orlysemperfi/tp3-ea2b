using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.SD.AccesoDatos_Atencion.Contrato
{
  
    public interface ICMDBData
    {

        List<CMDB> listaCMDBProyecto(int codigoProyecto);
    }
}
