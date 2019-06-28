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
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Direction { get; set; }
    }
}
