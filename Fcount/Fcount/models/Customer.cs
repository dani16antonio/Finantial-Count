using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fcount.models
{
    class Customer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Document { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public static int Insert(Customer customer)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<Customer>();
                return conn.Insert(customer);

            }
        }
        public static Customer Select(string document)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<Customer>();
                var customer = conn.Table<Customer>().FirstOrDefault(x => x.Document == document);
                return customer;
            }
        }

        public static List<Customer> SelectAll()
        {
            using(SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<Customer>();
                var customers = conn.Table<Customer>().ToList();
                return customers;
            }
        }
        public static int Update(Customer customer)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<Customer>();
                var rows = conn.Update(customer);
                return rows;
            }
        }
        public static int Remove(Customer customer)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<Customer>();
                var rows = conn.Delete(customer);
                return rows;
            }
        }
        public override string ToString()
        {
            return Lastname+", "+Name+" # "+Document;
        }
    }
}
