using AccessLayer.Sqlite;
using System;

namespace BusinessLayer
{
    public class CrtUptDatabase
    {
        AccessLayer.Sqlite.CrtUptDatabase crtUptDatabase = new AccessLayer.Sqlite.CrtUptDatabase();
        public void CrtUptDbLocal() => crtUptDatabase.CreateDatabase();
    }
}
