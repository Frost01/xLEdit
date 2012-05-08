using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace xLEdit
{
    public class CsvLoader
    {
        private char _splitChar;
        private DataTable _dataTable;

        public DataTable DataTable
        {
            get { return _dataTable; }
        }

        public CsvLoader(string fName, char splitChar)
        {
            _dataTable = new DataTable();
            this.Load(fName,splitChar);
        }

        private void Load(string fName, char splitChar)
        {
            _splitChar = splitChar;
            FileInfo fi = new FileInfo(fName);
            if (fi.Exists)
            {
                StreamReader streamReader = new StreamReader(fName);
                while (!streamReader.EndOfStream)
                {
                    string[] data = streamReader.ReadLine().Split(_splitChar);
                    while (_dataTable.Columns.Count < data.Count()) _dataTable.Columns.Add();
                    _dataTable.Rows.Add(data);
                }
            }
            else throw new FileNotFoundException(fName+ " not found!");
        }
    }
}
