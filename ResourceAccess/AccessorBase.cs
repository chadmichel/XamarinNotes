using System;
using SQLite;

namespace ResourceAccess
{
    public class AccessorBase
    {
        static string basePathStatic = null;

        protected AccessorBase()
        {
        }

        public static void SetPath(string path)
        {
            basePathStatic = path;
        }

        protected SQLiteConnection NewConnection()
        {
            if (string.IsNullOrWhiteSpace(basePathStatic))
                throw new InvalidOperationException("You must call SetPath on AccessorBase before using any database calls.");

            // Create our connection
            var db = new SQLiteConnection (System.IO.Path.Combine (basePathStatic, "notes.db"));
            return db;
        }
    }
}

