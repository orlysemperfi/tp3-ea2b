using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TMD.GM.AccesoDatos.Util
{
    internal static class DataReaderExtensions
    {
        public static bool? GetBoolNull(this IDataReader reader, String nombreColumna)
        {
            int ordinal = reader.GetOrdinal(nombreColumna);
            if (!reader.IsDBNull(ordinal))
            {
                return reader.GetBoolean(ordinal);
            }

            return null;
        }

        public static DateTime GetDateTime(this IDataReader reader, String nombreColumna)
        {
            int ordinal = reader.GetOrdinal(nombreColumna);
            if (!reader.IsDBNull(ordinal))
            {
                return reader.GetDateTime(ordinal);
            }

            return default(DateTime);
        }

        public static Guid GetGuid(this IDataReader reader, String nombreColumna)
        {
            int ordinal = reader.GetOrdinal(nombreColumna);
            if (!reader.IsDBNull(ordinal))
            {
                return reader.GetGuid(ordinal);
            }

            return default(Guid);
        }

        public static Byte GetByte(this IDataReader reader, String nombreColumna)
        {
            int ordinal = reader.GetOrdinal(nombreColumna);
            if (!reader.IsDBNull(ordinal))
            {
                return reader.GetByte(ordinal);
            }

            return 0;
        }

        public static Byte? GetByteNul(this IDataReader reader, String nombreColumna)
        {
            int ordinal = reader.GetOrdinal(nombreColumna);
            if (!reader.IsDBNull(ordinal))
            {
                return reader.GetByte(ordinal);
            }

            return null;
        }


        public static Int16 GetSmallInt(this IDataReader reader, String nombreColumna)
        {
            int ordinal = reader.GetOrdinal(nombreColumna);
            if (!reader.IsDBNull(ordinal))
            {
                return reader.GetInt16(ordinal);
            }

            return 0;
        }

        public static Int16? GetSmallIntNul(this IDataReader reader, String nombreColumna)
        {
            int ordinal = reader.GetOrdinal(nombreColumna);
            if (!reader.IsDBNull(ordinal))
            {
                return reader.GetInt16(ordinal);
            }

            return null;
        }

        public static Decimal GetDecimal(this IDataReader reader, String nombreColumna)
        {
            int ordinal = reader.GetOrdinal(nombreColumna);
            if (!reader.IsDBNull(ordinal))
            {
                return reader.GetDecimal(ordinal);
            }

            return 0;
        }

        public static Decimal? GetDecimalNul(this IDataReader reader, String nombreColumna)
        {
            int ordinal = reader.GetOrdinal(nombreColumna);
            if (!reader.IsDBNull(ordinal))
            {
                return reader.GetDecimal(ordinal);
            }

            return null;
        }

        public static int GetInt(this IDataReader reader, String nombreColumna)
        {
            int ordinal = reader.GetOrdinal(nombreColumna);
            if (!reader.IsDBNull(ordinal))
            {
                return reader.GetInt32(ordinal);
            }

            return 0;
        }

        public static int? GetIntNull(this IDataReader reader, String nombreColumna)
        {
            int ordinal = reader.GetOrdinal(nombreColumna);
            if (!reader.IsDBNull(ordinal))
            {
                return reader.GetInt32(ordinal);
            }

            return null;
        }

        public static String GetString(this IDataReader reader, String nombreColumna)
        {
            int ordinal = reader.GetOrdinal(nombreColumna);
            if (!reader.IsDBNull(ordinal))
            {
                return reader.GetString(ordinal);
            }

            return null;
        }
    }
}
