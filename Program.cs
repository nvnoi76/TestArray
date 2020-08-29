using System;
using System.IO;

namespace TestArray
{
    class Program
    {
        static void Main(string[] args)
        {
            CThiSinhArray hs = new CThiSinhArray(13264);
            hs.ReadFromCSVFile("D:\\TG53NNNVT01.csv");
            hs.SortByThiSinhID();
            hs.WriteToCSVFile("D:\\testout.csv");
            hs.XepHang();
            hs.WriteToCSVFile("D:\\testoutXepHang.csv");
            hs.WriteTopToCSVFile("D:\\testoutXepHang675.csv", 675);
        }
    }
}
