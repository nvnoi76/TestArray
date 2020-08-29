using System;
using System.IO;

namespace TestArray
{
    class CThiSinhArray
    {
        public CThiSinh[] m_arrThiSinh;
        public int m_nSize;
        public CThiSinhArray(int n)
        {
            m_nSize = n;
            m_arrThiSinh = new TestArray.CThiSinh[n];
        }
        public void ReadFromCSVFile(string filename)
        {
            try
            {
                using (StreamReader file = new StreamReader(filename))
                {
                    file.ReadLine();
                    int i = 0;
                    while (!file.EndOfStream && (i < m_nSize))
                    {
                        string s = file.ReadLine();
                        m_arrThiSinh[i] = new CThiSinh();
                        m_arrThiSinh[i].FromString(s);
                        i++;
                    }
                    Console.WriteLine("Tong so {0}", i);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ShowThiSinhArray()
        {
            for (int i = 0; i < m_nSize; i++)
            {
                Console.WriteLine(m_arrThiSinh[i].ToString());
            }
        }
        public void WriteToCSVFile(string filename)
        {
            try
            {
                StreamWriter file = new StreamWriter(filename);
                file.WriteLine("MAHS,Toan,Van,NgoaiNgu,Tong,Hang");
                for (int i = 0; i < m_nSize; i++)
                {
                    file.WriteLine(m_arrThiSinh[i].ToString());
                }
                file.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SortByThiSinhID()
        {
            CSapXep.Sort<CThiSinh>(m_arrThiSinh, CThiSinh.CompareID);
        }
        public void SortByDiemTong()
        {
            CSapXep.Sort<CThiSinh>(m_arrThiSinh, CThiSinh.CompareDiemTong);
        }
        public void XepHang()
        {
            SortByDiemTong();
            m_arrThiSinh[0].m_nHang = 1;
            for (int i = 1; i < m_nSize; i++)
            {
                if (m_arrThiSinh[i].m_dDiemTong == m_arrThiSinh[i - 1].m_dDiemTong)
                    m_arrThiSinh[i].m_nHang = m_arrThiSinh[i - 1].m_nHang;
                else
                    m_arrThiSinh[i].m_nHang = i + 1;
            }
        }
        public void WriteTopToCSVFile(string filename, int n)
        {
            try
            {
                StreamWriter file = new StreamWriter(filename);
                file.WriteLine("MAHS,Toan,Van,NgoaiNgu,Tong,Hang");
                int top = (n < m_nSize) ? n : m_nSize;
                int i = 0;
                while ((i<m_nSize) && (m_arrThiSinh[i].m_nHang<=top))
                { 
                    file.WriteLine(m_arrThiSinh[i].ToString());
                    i++;
                }
                file.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
