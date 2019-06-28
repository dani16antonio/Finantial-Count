using Fcount.viewmodels.utils;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fcount.models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get;
            set;
        }

        public string Username
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Lastname
        {
            get;
            set;
        }

        public string password
        {
            get;
            set;
        }
        public static int Insert(User user)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<User>();
                return conn.Insert(user);

            }
        }
        public static User Select(string username)
        {
            using(SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<User>();
                var user = conn.Table<User>().FirstOrDefault(x=> x.Username==username);
                return user;
            }
        }
    }
}
