﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TMD.DBO.LogicaNegocio_Atencion.Contrato;
using TMD.Entidades;
using TMD.DBO.AccesoDatos_Atencion.Contrato;

namespace TMD.DBO.LogicaNegocio_Atencion.Implementacion
{
  
    public class CMDBLogica : ICMDBLogica
    {
        private readonly ICMDBData _cMDBData;
        public CMDBLogica(ICMDBData cMDBData)
        {
            _cMDBData = cMDBData;
        }


        /// <summary>
        /// Lista todos los analistas de un proyecto.
        /// </summary>
        /// <param name="codigoProyecto">Codigo del Proyecto</param>
        /// <returns>Lista Analista</returns>
        public List<CMDB> listaCMDBProyecto(int codigoProyecto)
        {
            return _cMDBData.listaCMDBProyecto(codigoProyecto);
        }

        

    }
}
