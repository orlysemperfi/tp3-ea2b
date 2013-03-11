﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.CF.LogicaNegocios.Contrato
{
    /// <summary>
    /// Contrato  de la Logica de Negocios de la entidad Usuario.
    /// </summary>
    public interface IUsuarioLogica
    {
        /// <summary>
        /// Lista los usuario de un proyecto.
        /// </summary>
        /// <param name="proyecto">Proyecto</param>
        /// <returns>Lista Usuario</returns>
        List<Usuario> ListaPorProyecto(Proyecto proyecto);
    }
}