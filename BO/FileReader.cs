using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Models
{
    public static class FileReader
    {
        public static DataTable GetTableFromCSVFile(string fName)
        {
            char splitChar = '\t';
            return GetTableFromCSVFile(fName, splitChar);
        }

        public static DataTable GetTableFromCSVFile(string fName, char splitChar)
        {
            DataTable dt = new DataTable();
            FileInfo fi = new FileInfo(fName);
            if (fi.Exists)
            {
                StreamReader streamReader = new StreamReader(fName);
                while (!streamReader.EndOfStream)
                {
                    string[] words = streamReader.ReadLine().Split(splitChar);
                    while (dt.Columns.Count < words.Count()) dt.Columns.Add();
                    dt.Rows.Add(words);
                }
            }
            return dt;
        }
    }
}
