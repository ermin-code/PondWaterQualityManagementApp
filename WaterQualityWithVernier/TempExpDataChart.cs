using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterQualityWithVernier
{
    class TempExpDataChart
    {
        public static void TExpDataChart()
        {
            CsvToDataTable obj = new CsvToDataTable();
            DataTable dtData = obj.ConvertCsvToDataTable(Program._config["TExpData"]);
            obj.ShowData(dtData);
        }

        class CsvToDataTable
        {
            public DataTable ConvertCsvToDataTable(string filePath)
            {
                //reading all the lines(rows) from the file.
                string[] rows = File.ReadAllLines(filePath);

                DataTable dtData = new DataTable();
                string[] rowValues = null;
                DataRow dr = dtData.NewRow();

                //Creating columns
                if (rows.Length > 0)
                {
                    foreach (string columnName in rows[0].Split(','))
                        dtData.Columns.Add(columnName);
                }

                //Creating row for each line.(except the first line, which contain column names)
                for (int row = 1; row < rows.Length; row++)
                {
                    rowValues = rows[row].Split(',');
                    dr = dtData.NewRow();
                    dr.ItemArray = rowValues;
                    dtData.Rows.Add(dr);
                }

                return dtData;
            }

            public void ShowData(DataTable dtData)
            {
                Console.Clear();

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    Console.WriteLine("\n    TEMPERATURE EXPERIMENT DATA");
                    Console.WriteLine(" _________________________________");
                    Console.WriteLine("");
                    foreach (DataColumn dc in dtData.Columns)
                    {


                        Console.Write(" " + dc.ColumnName + "          ");
                    }

                    Console.WriteLine("\n");

                    foreach (DataRow dr in dtData.Rows)
                    {
                        foreach (var item in dr.ItemArray)
                        {
                            Console.Write(" " + item.ToString() + "          ");
                        }
                        Console.WriteLine("\n");
                        
                    }
                    Console.WriteLine("");

                    Console.WriteLine("Please press ENTER to go back to the Temperature Experiment menu..");
                    Console.ReadLine();
                    TExp.TempExpMenu();
                    
                }
            }

        }
    }
}



        

