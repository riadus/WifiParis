using System;
using SQLite.Net;
using SQLite.Net.Interop;
using WifiParisComplete.Data;

namespace WifiParisComplete.SqLite
{
    public class SQLiteDatabase
    {
        static readonly object _locker = new object ();
        static SQLiteConnection _connection;
        static ISQLitePlatform _platform;
		public static void DropAllTables ()
		{
			var connection = GetConnection ();
			connection.DropTable<Address> ();
			connection.DropTable<Coordinates> ();
            connection.DropTable<WifiHotspot> ();
		}

		public static void Initialize (ISQLitePlatform platform)
		{
            _platform = platform;
			lock (_locker) {
				var connection = GetConnection ();
				connection.CreateTable<Address> ();
				connection.CreateTable<Coordinates> ();
				connection.CreateTable<WifiHotspot> ();
			}
		}

		public static SQLiteConnection GetConnection ()
		{
			lock (_locker) {
                return _connection ??
                    (_connection = new SQLiteConnection (_platform, FilePath));
			}
		}

		public static string FilePath { get; set; }
	}
}

