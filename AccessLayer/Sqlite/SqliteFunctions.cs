using Microsoft.Data.Sqlite;

namespace AccessLayer.Sqlite
{
    public static class SqliteFunctions
    {
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
