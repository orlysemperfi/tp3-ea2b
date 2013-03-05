using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TMD.SD.LogicaNegocio_Atencion.Contrato;
using TMD.Entidades;
using TMD.SD.AccesoDatos_Atencion.Contrato;

namespace TMD.SD.LogicaNegocio_Atencion.Implementacion
{
  

    public class UsuarioClienteLogica: IUsuarioClienteLogica
    {
        private readonly IUsuarioClienteData _UsuarioClienteData;
        public UsuarioClienteLogica(IUsuarioClienteData UsuarioClienteData)
        {
            _UsuarioClienteData = UsuarioClienteData;
        }
       
        public UsuarioCliente datosUsuarioCliente(int codigoUsuarioCliente)
        {
            return _UsuarioClienteData.datosUsuarioCliente(codigoUsuarioCliente);
        }

        /// <summary>
        /// Lista todos los analistas de un proyecto.
        /// </summary>
        /// <param name="codigoProyecto">Codigo del Proyecto</param>
        /// <returns>Lista Analista</returns>
        public List<UsuarioCliente> listaUsuarioCliente(string AliasIntegrante)
        {
            return _UsuarioClienteData.listaUsuarioCliente(AliasIntegrante);
        }


    }

}
