using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;
namespace TMD.DBO.AccesoDatos_Atencion.Contrato
{
  
    public interface IUsuarioClienteData
    {

        /// <summary>
        /// Lista usuarios cliente por integrante
        /// </summary>
        /// /// <param name="aliasIntegrante">Codigo del Proyecto</param>
        /// <returns>Lista Integrante</returns>
        List<UsuarioCliente> listaUsuarioCliente(string aliasIntegrante);


        UsuarioCliente datosUsuarioCliente(int codigoUsuarioCliente);


    }
}
