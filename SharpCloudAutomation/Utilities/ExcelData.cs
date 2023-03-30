﻿using System.Data;
using ExcelDataReader;


namespace SharpCloudAutomation.Utilities
{
    public class ExcelData
    {
        private static List<DataCollection> dataCollection = new List<DataCollection>();

        public static void PopulateInCollection(string Excelfilename)
        {
            DataTable table = ExcelToDataTable(Excelfilename);
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    DataCollection dtTable = new DataCollection()
                    {
                        RowNumber = row,
                        ColumnName = table.Columns[col].ColumnName,
                        ColumnValue = table.Rows[row - 1][col].ToString()
                    };

                    dataCollection.Add(dtTable);
                }
            }
        }

        public static DataTable ExcelToDataTable(string Excelfilename)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);       

            using var stream = File.Open(Excelfilename, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateReader(stream);

            var dataTable = new DataTable();
            dataTable.Columns.Add("Username", typeof(string));
            dataTable.Columns.Add("Password", typeof(string));

            var rowIndex = 0;

            while (reader.Read())
            {
                if (rowIndex != 0)
                {
                    var row = dataTable.NewRow();
                    row[0] = reader.GetString(0);
                    row[1] = reader.GetString(1);

                    dataTable.Rows.Add(row);
                }
                rowIndex++;
            }
            return dataTable;
        }

        public static string ReadData(int rowNumber, string ColumnName)
        {
            try
            {
                string data = (from colData in dataCollection
                               where colData.ColumnName == ColumnName && colData.RowNumber == rowNumber
                               select colData.ColumnValue).SingleOrDefault();

                return data.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }
 
        public class DataCollection
        {
            public int RowNumber { get; set; }
            public string ColumnName { get; set; }
            public string ColumnValue { get; set; }
        }
    }
}
