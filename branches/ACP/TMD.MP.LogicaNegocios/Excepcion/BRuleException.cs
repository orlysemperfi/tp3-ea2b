using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.MP.LogicaNegocios.Excepcion
{
    public class BRuleException : Exception
    {
        public BRuleException() : base() 
        { 
        
        }
        public BRuleException(string message) : base (message)
        {
           
        }


    }
}
