using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonic_delivery_unsuccessful
{
    class Excelbook
    {
        public static DataTable ExcelToDataTable(String FileName1)
        {
            FileStream stream = File.Open(FileName1, FileMode.Open, FileAccess.Read);
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            DataSet result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });
            DataTableCollection table = result.Tables;
            DataTable resultTable = table[0];
            return resultTable;
        }

        public static List<Datacollection> dataCol = new List<Datacollection>();

        public static DataTable PopulateInCollection(String FileName)
        {
            DataTable table = ExcelToDataTable(FileName);

            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        RowNumber = row,
                        ColName = table.Columns[col].ColumnName,
                        ColValue = table.Rows[row - 1][col].ToString()
                    };
                    dataCol.Add(dtTable);
                }
            }
            return table;
        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {

                string data = (from colData in dataCol
                               where colData.ColName == columnName && colData.RowNumber == rowNumber
                               select colData.ColValue).SingleOrDefault();


                return data.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception is : " + ex.Message);
                return null;
            }
        }

        public class Datacollection

        {
            public int RowNumber { get; set; }
            public string ColName { get; set; }
            public string ColValue { get; set; }
        }
    }
}
