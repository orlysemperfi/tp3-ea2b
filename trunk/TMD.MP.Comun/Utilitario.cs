using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.MP.Comun
{
    public class Utilitario
    {
        public static int getDefaultOrIntDBValue(Object obj) {
            if (obj != null && !Convert.IsDBNull(obj))
                return Convert.ToInt32(obj);
            else 
                return 0;
        }
        public static double getDefaultOrDoubleDBValue(Object obj)
        {
            if (obj != null || Convert.IsDBNull(obj))
                return Convert.ToDouble(obj);
            else
                return 0d;
        }
        public static String getDefaultOrStringDBValue(Object obj)
        {
            if (obj != null || Convert.IsDBNull(obj))
                return Convert.ToString(obj);
            else
                return "";
        }
        public static DateTime getDefaultOrDatetimeDBValue(Object obj)
        {
            if (obj != null || Convert.IsDBNull(obj))
                return Convert.ToDateTime(obj);
            else
                return DateTime.Now;
        }
        public static String ObtenerDescTipoIndicador(String tipo){
            if (tipo.Equals("0"))
                return "Cualitativo";
            if (tipo.Equals("1"))
                return "Cuantitativo";

            return "No existe";
        }
    }
}
