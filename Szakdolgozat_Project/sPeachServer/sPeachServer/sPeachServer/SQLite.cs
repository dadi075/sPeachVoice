using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace sPeachServer
{
    class SQLite
    {
        private SQLiteConnection sqlConn;
        private SQLiteCommand sQLiteCommand;
        private SQLiteDataReader sQLiteDataReader;

        public SQLite()
        {
            sqlConn = new SQLiteConnection("Data Source=server.db;Version=3;");
            sqlConn.Open();
        }
        public void executeInsert(string cmd)
        {
            sQLiteCommand = new SQLiteCommand(cmd, sqlConn);
            sQLiteCommand.ExecuteNonQuery();
            sqlConn.Close();
        }
        public void executeSelect(string cmd)
        {
            sQLiteCommand = new SQLiteCommand(cmd, sqlConn);
             sQLiteDataReader = sQLiteCommand.ExecuteReader();
            sqlConn.Close();
        }
    }
}
