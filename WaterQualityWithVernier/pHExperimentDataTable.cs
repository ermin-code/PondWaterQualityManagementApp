using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterQualityWithVernier
{
    class pHExperimentDataTable
    {
        public static void pHExperimentTable()
        {
            CsvToDataTable obj = new CsvToDataTable();

            DataTable dtData = obj.ConvertCsvToDataTable(Program._config["pHExpDataFile"]);

            obj.pHExperimentShowTable(dtData);
        }

        class CsvToDataTable
        {
            public DataTable ConvertCsvToDataTable(string filePath)
            {

                string path = Path.GetFullPath(Program._config["pHExpDataFile"]);


                //Here write if statement if file is missing

                DataTable dtDatapH = new DataTable();

                if (File.Exists(path))
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

                else
                {
                    Console.Clear();

                    Console.WriteLine("Data file for the pH Experiment does not exist!");

                    Console.WriteLine("");

                    Console.WriteLine("Press ENTER to go back to the Main Menu..");

                    Console.ReadLine();

                    Program.MainMenu();

                    return dtDatapH;
                }
            }

            public void pHExperimentShowTable(DataTable dtData)
            {
                Console.Clear();

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    Console.WriteLine("\n    pH EXPERIMENT DATA TABLE");

                    Console.WriteLine(" ______________________________");

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
                            Console.Write(" " + item.ToString() + "     ");
                        }

                        Console.WriteLine("\n");
                    }

                    Console.WriteLine("");

                    Console.WriteLine("Please press ENTER to go back to the pH Experiment menu..");

                    Console.ReadLine();

                    pHExperiment.pHExperimentMainMenu();
                }
            }
        }
    }
}
