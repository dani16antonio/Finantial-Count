using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fcount.models
{
    class Provider
    {
        [AutoIncrement,PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Fcontact { get; set; }
        public int Scontact { get; set; }
        public string Email { get; set; }

        public static int Insert(Provider provider)
        {
            using(SQLiteConnection conn=new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<Provider>();
                return conn.Insert(provider);

            }
        }

        public static List<Provider> SelectAll()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<Provider>();
                return conn.Table<Provider>().ToList();

            }
        }

        public static int Remove(Provider provider)
        {
            using(SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<Provider>();
                return conn.Delete(provider);
            }
        }

        public static int Update(Provider provider)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<Provider>();
                return conn.Update(provider);
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
