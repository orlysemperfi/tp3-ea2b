using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace TMD.Core.Logger
{
       
    public class Log
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void RegistrarError(Exception ex) {
            log.Debug("Mensaje de Error: "+ex.Message);
            log.Debug("Origen: "+ex.StackTrace);
        }

       
    }
}
