using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.CF.LogicaNegocios.Error
{
    /// <summary>
    /// Representa una excepcion de logica de negocio
    /// </summary>
    public class ReglaNegocioException : Exception
    {
        public ReglaNegocioException(String mensaje):base(mensaje)
        {
            
        }
    }
}
