﻿using System;
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
        public string username = "";
        public string password = "";

        public SQLite()
        {
            sqlConn = new SQLiteConnection("Data Source=server.db;Version=3;New=False;Compress=True;");
            sqlConn.Open();
        }
        public int executeInsert(string cmd)
        {
            sQLiteCommand = new SQLiteCommand(cmd, sqlConn);
            return sQLiteCommand.ExecuteNonQuery();
        }
        public void loginSelect(string cmd)
        {
            using (sQLiteCommand = new SQLiteCommand(cmd, sqlConn))
            {
                using (sQLiteDataReader = sQLiteCommand.ExecuteReader())
                {
                    if (sQLiteDataReader.Read())
                    {
                        username = sQLiteDataReader.GetString(0);
                        password = sQLiteDataReader.GetString(1);
                    }
                }
            }
        }
        public void closeDatabase()
        {
            sqlConn.Close();
        }
    }
}
