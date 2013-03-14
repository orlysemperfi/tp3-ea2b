﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.GM.Util
{
    public class DataUT
    {
        public static Int64 ObjectToInt64(object obj)
        {
            try
            {
                return ((obj == null) || (obj == DBNull.Value)) ? 0 : Convert.ToInt64(obj);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static Int16 ObjectToInt16(object obj)
        {
            return ((obj == null) || (obj == DBNull.Value)) ? Int16.MinValue : Convert.ToInt16(obj);
        }
        public static int ObjectToInt32(object obj)
        {
            try
            {
                return ((obj == null) || (obj == DBNull.Value)) ? 0 : Convert.ToInt32(obj);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static char ObjectToChar(object obj)
        {
            try
            {
                return ((obj == null) || (obj == DBNull.Value)) ? ' ' : Convert.ToChar(obj);
            }
            catch (Exception ex)
            {
                return ' ';
            }
        }
        public static decimal ObjectToDecimal(object obj)
        {
            try
            {
                return ((obj == null) || (obj == DBNull.Value)) ? 0.00M : Convert.ToDecimal(obj);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static int ObjectToInt(object obj)
        {
            return ObjectToInt32(obj);
        }
        public static double ObjectToDouble(object obj)
        {
            try
            {
                return ((obj == null) || (obj == DBNull.Value)) ? 0 : Convert.ToDouble(obj);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static string ObjectToString(object obj)
        {
            try
            {
                return ((obj == null) || (obj == DBNull.Value)) ? string.Empty : Convert.ToString(obj);

            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }

        public static string ObjectToStringNota(object obj)
        {
            try
            {
                return ((obj == null) || (obj == DBNull.Value)) ? string.Empty : ((Convert.ToString(obj).ToUpper() == "NULL") ? string.Empty : Convert.ToString(obj));

            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }

        public static DateTime ObjectToDateTime(object obj)
        {
            return ((obj == null) || (obj == DBNull.Value)) ? DateTime.MinValue : Convert.ToDateTime(obj);
        }
        //public static DateTime ObjectToDateTimeSistema(object obj)
        //{
        //    return ((obj == null) || (obj == DBNull.Value)) ? ParametroDateUtil.DateTimeMinValueSQL : Convert.ToDateTime(obj);
        //}


        public static DateTime? ObjectToDateTimeNull(object obj)
        {
            if (obj == null || obj == DBNull.Value) return null; else return Convert.ToDateTime(obj);
        }
        public static Decimal? ObjectToDecimalNull(object obj)
        {
            if (obj == null || obj == DBNull.Value) return null; else return Convert.ToDecimal(obj);
        }
        public static Int32? ObjectToInt32Null(object obj)
        {
            if (obj == null || obj == DBNull.Value) return null; else return Convert.ToInt32(obj);
        }
        public static string ObjectToDateTimeStringNull(object obj)
        {
            if (obj == null || obj == DBNull.Value) return ""; else return Convert.ToDateTime(obj).ToString("yyyyMMdd");
        }
        public static DateTime StringToDateTime(string str)
        {
            return (string.IsNullOrEmpty(str)) ? DateTime.MinValue : Convert.ToDateTime(str);
        }
        public static byte ObjectToByte(object obj)
        {
            try
            {
                return ((obj == null) || (obj == DBNull.Value)) ? byte.MinValue : Convert.ToByte(obj);
            }
            catch (Exception ex)
            {
                return byte.MinValue;
            }
        }
        public static byte[] ObjectToByteArray(object obj)
        {
            try
            {
                return ((obj == null) || (obj == DBNull.Value)) ? null : (byte[])obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static int StringToInt(string str)
        {
            return (string.IsNullOrEmpty(str)) ? 0 : Convert.ToInt32(str);
        }
        public static string IntToString(int int1)
        {
            return ((int1 == 0)) ? "" : Convert.ToString(int1);
        }
        public static string ObjectDecimalToStringFormatMiles(object obj)
        {
            return ObjectToDecimal(obj).ToString("#,#0.00");
        }
        public static string BoolToString(bool flag)
        {
            return flag ? "1" : "0";
        }
        public static bool StringToBool(string flag)
        {
            return flag == "1";
        }
        public static string ObjectNullToString(object obj)
        {
            return (string.IsNullOrEmpty(ObjectToString(obj))) ? "1" : obj.ToString();
        }
        public static string ObjectToStringTime(object obj)
        {
            return ((obj == null) || (obj == DBNull.Value)) ? "" : Convert.ToString(obj);
        }
        public static string ObjectToDTStringNull(object obj)
        {
            if (obj == null || obj == DBNull.Value) return null; else return Convert.ToDateTime(obj).ToString("hh:MM:ss");
        }

        public static string ObjectToDTString(object obj)
        {
            if (obj == null || obj == DBNull.Value) return ""; else return Convert.ToDateTime(obj).ToString("hh:MM:ss");
        }

        public static string ObjectToDTimeString(object obj)
        {
            if (obj == null || obj == DBNull.Value) return ""; else return Convert.ToDateTime(obj).ToLongTimeString().Substring(0, 8);
        }

        public static string ObjectToDateTimeStringNullGeneral(object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return "";
            else
            {
                if (Convert.ToDateTime(obj).ToShortDateString().Substring(0, 10) == "01/01/1900")
                    return "";
                else
                    return Convert.ToDateTime(obj).ToString("yyyyMMdd");
            }
        }
        #region TryParse
        public static DateTime StringObjectToDateTime(string obj)
        {
            DateTime Temp;
            if (obj == null)
                Temp = DateTime.MinValue;
            else
                try { Temp = Convert.ToDateTime(obj); }
                catch { Temp = DateTime.MinValue; }
            return Temp;
        }
        public static bool ObjectToBoolean(object obj)
        {
            bool Temp;
            if (obj == null)
                Temp = false;
            else
                try { Temp = Convert.ToBoolean(obj); }
                catch { Temp = false; }
            return Temp;
        }
        public static DateTime ObjectToDateTimeTryParse(object obj)
        {
            DateTime Temp;
            if (obj == null)
                Temp = DateTime.MinValue;
            else
                try { Temp = Convert.ToDateTime(obj); }
                catch { Temp = DateTime.MinValue; }
            return Temp;
        }
        //public static DateTime? ObjectToDateTimeSQLTryParse(object obj)
        //{
        //    DateTime? Temp;
        //    if (obj == null)
        //        Temp = null;
        //    else
        //        try
        //        {
        //            Temp = Convert.ToDateTime(obj);
        //            if (ParametroDateUtil.DateTimeMinValueSQL >= Temp && Temp >= ParametroDateUtil.DateTimeMaxValueSQL)
        //            {
        //            }
        //            else
        //            {
        //                Temp = null;
        //            }
        //        }
        //        catch { Temp = null; }
        //    return Temp;
        //}
        public static int ObjectToIntTryParse(object obj)
        {
            int Temp;
            if (obj == null)
                Temp = int.MinValue;
            else
                try { Temp = Convert.ToInt32(obj); }
                catch { Temp = int.MinValue; }
            return Temp;
        }
        public static Int64 ObjectToInt64TryParse(object obj)
        {
            Int64 Temp;
            if (obj == null)
                Temp = 0;
            else
                try { Temp = Convert.ToInt64(obj); }
                catch { Temp = 0; }
            return Temp;
        }
        public static decimal ObjectToDecimalTryParse(object obj)
        {
            decimal Temp;
            if (obj == null)
                Temp = decimal.MinValue;
            else
                try { Temp = Convert.ToDecimal(obj); }
                catch { Temp = decimal.MinValue; }
            return Temp;
        }
        public static string ObjectToStringTryParse(object obj)
        {
            string Temp;
            if (obj == null)
                Temp = string.Empty;
            else
                try { Temp = obj.ToString(); }
                catch { Temp = string.Empty; }
            return Temp;
        }
        //public static Nullable<DateTime> DateTimeToDateTimeSQL(DateTime obj)
        //{
        //    if (ParametroDateUtil.DateTimeMinValueSQL <= obj && obj <= ParametroDateUtil.DateTimeMaxValueSQL)
        //    {
        //        return obj;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        public static DateTime DateMorTime(DateTime obj, DateTime oTime)
        {
            try
            {
                TimeSpan oNewTime = new TimeSpan();
                if (TimeSpan.TryParse(oTime.ToShortTimeString(), out oNewTime))
                {
                    obj = (Convert.ToDateTime(obj.ToShortDateString())).Add(oNewTime);
                }
                return obj;
            }
            catch
            {
                return obj;
            }
        }
        #endregion TryParse

        public static string GetString8FromDateTime(DateTime dt)
        {
            return string.Concat(dt.Year, dt.Month.ToString().PadLeft(2, '0'), dt.Day.ToString().PadLeft(2, '0'));
        }


        public static string StringReturnNotNull(string Value)
        {
            return string.IsNullOrEmpty(Value) ? "" : Value;
        }
        public static string StringReturnNotCero(string Value)
        {
            return (Value != null && Value != "0") ? Value : "";
        }

    }

}
