using Microsoft.Data.Sqlite;
using System;

namespace AccessLayer.Sqlite
{
    public static class SqliteFunctions
    {
        public static SqliteParameter AddWithNullableValue(this SqliteParameterCollection collection, string parameterName, object value)
        {
            if (value == null)
                return collection.AddWithValue(parameterName, DBNull.Value);
            else
                return collection.AddWithValue(parameterName, value);
        }

        public static string GetWithNullableString(this SqliteDataReader sqliteDataReader, int ordinal)
        {
            return !sqliteDataReader.IsDBNull(ordinal) ? sqliteDataReader.GetString(ordinal) : null;
        }

        public static bool GetWithNullableBool(this SqliteDataReader sqliteDataReader, int ordinal)
        {
            return !sqliteDataReader.IsDBNull(ordinal) && sqliteDataReader.GetBoolean(ordinal);
        }

        public static int? GetWithNullableInt(this SqliteDataReader sqliteDataReader, int ordinal)
        {
            return !sqliteDataReader.IsDBNull(ordinal) ? sqliteDataReader.GetInt32(ordinal) : (int?)null;
        }
    }
}
