using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fcount.models
{
    class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }

        public static int Insert(Item item)
        {
            using(SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<Item>();
                return conn.Insert(item);
            }
        }
        public static List<Item> SelectAll()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<Item>();
                return conn.Table<Item>().ToList();
            }
        }
        public static int Update(Item item)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<Item>();
                return conn.Update(item);
            }
        }

        public static int Remove(Item item)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<Item>();
                return conn.Delete(item);
            }
        }
    }
}
