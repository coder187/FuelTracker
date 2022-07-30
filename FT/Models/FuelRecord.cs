using System;
using SQLite;

namespace FT.Models
{
    public class FuelRecord
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int userId { get; set; }
        public string Reg { get; set; }
        public int FuelType { get; set; }
        public double Litres { get; set; }
        public double OdoStart { get; set; }
        public double OdoEnd { get; set; }
        public DateTime Date { get; set; }
        public string userNote { get; set; }
    }
}