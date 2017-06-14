using System;
using SQLite.Net.Attributes;

namespace WifiParisComplete.Data
{
    public class SavableData
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
    }
}
