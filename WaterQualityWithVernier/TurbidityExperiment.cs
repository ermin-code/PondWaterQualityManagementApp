using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using CsvReader;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;

namespace WaterQualityWithVernier
{
    class TurbidityExperiment
    {
        // Turbidity Experiment Menu
        public static void TurbidityExperimentMainMenu()
        {
            Console.Clear();

            Console.WriteLine(" *********************** Turbidity Experiment ***********************");

            Console.WriteLine("");

            Console.WriteLine("     Option 1. Enter Turbidity Data");

            Console.WriteLine("     Option 2. Search Turbidity Data");

            Console.WriteLine("     Option 3. Delete ALL Data");

            Console.WriteLine("");

            Console.WriteLine("     Option 4. Exit to Main Menu");

            string myOptions;
            myOptions = Console.ReadLine();

            switch (myOptions)
            {
                case "1":
                    TurbidityExperimentDataEntry();
                    break;

                case "2":
                    TurbidityExperimentDataSearch();
                    break;

                case "3":
                    TurbidityExperimentDeleteALL();
                    break;

                case "4":
                    Program.MainMenu();
                    break;
            }
        }


        // Turbidity Data Entry Section
        public static void TurbidityExperimentDataEntry()
        {
            Console.Clear();

            Console.WriteLine(" *********************** Turbidity Experiment Data Entry ***********************");

            Console.WriteLine("");

            Console.WriteLine("  Turbidity is caused by particles suspended or dissolved in water that scatter");

            Console.WriteLine("  light making the water appear cloudy or murky. In a Koi fish pond, high");

            Console.WriteLine("  turbidity of water usually happens during warm summer months when green algea");

            Console.WriteLine("  experience most growth. We can correctly assume that the rate by which water");

            Console.WriteLine("  turbidity changes can directly be used to measure growth of green algea in ");

            Console.WriteLine("  in your fish pond.");

            Console.WriteLine("");

            Console.WriteLine("  High turbidity because of algea affects Koi fish because when large amounts");

            Console.WriteLine("  of algea die, oxygen is used up to decompose them, leaving less oxygen for ");

            Console.WriteLine("  the fish. Large amounts of suspended soils or clay may clog the gills and kill");

            Console.WriteLine("  them directly.");

            Console.WriteLine("");

            Console.WriteLine("  In this experiment you will collect temperature data on your pond water using ");

            Console.WriteLine("  Vernier turbidity probe, Texas Instruments Graphing Calculator with attached ");

            Console.WriteLine("  CBL2 Calculator-Based Laboratory.");

            Console.WriteLine("");

            Console.WriteLine("");

            Console.WriteLine("  Please enter date of experiment (Example: 06/01/2017):");

            Console.WriteLine("");

            string turbExpDate = Console.ReadLine();

            Console.Clear();

            Console.WriteLine(" *********************** Turbidity Experiment Data Entry ***********************");

            Console.WriteLine("");

            Console.WriteLine("  Please enter turbidity observed (in NTU):");

            Console.WriteLine("");

            string turbExpTurb = Console.ReadLine();

            Console.Clear();


            List<string> dateAndTurb = new List<string>();

            List<string> dateAndTurbInit = new List<string>();

            string path = Path.GetFullPath(Program._config["TurbExpDataFile"]);


            /** If statement checks if CSV data file is present. If it is present, the program continues..
             If CSV data file is not present, it initializes or creates an empty CSV data file **/

            if (File.Exists(path))
            {
                dateAndTurb.Add($"{turbExpDate},{turbExpTurb}");

                
                // Stores date and turbidity data in CSV file following [date, turbidity] format 
                
                File.AppendAllLines(Program._config["TurbExpDataFile"], dateAndTurb);

                int turbExpTurbInt = Int32.Parse(turbExpTurb);

                Console.Clear();

                Console.WriteLine(" *********************** Turbidity Experiment Data Entry ***********************");

                Console.WriteLine("");

                Console.WriteLine("  Turbidity data was entered. Please press ENTER to go back to the experiment menu..");

                Console.ReadLine();

                TurbidityExperimentMainMenu();
            }
             
           
            //Initializes/creates an empty CSV data file

            else
            {
                dateAndTurbInit.Add("Date,Turbidity (NTU)");

                File.AppendAllLines(Program._config["TurbExpDataFile"], dateAndTurbInit);

                Console.Clear();

                Console.WriteLine(" *********************** Turbidity Experiment Data Entry ***********************");

                Console.WriteLine("");

                Console.WriteLine("  Initialized File. Please press ENTER to go back and re-enter data..");

                Console.ReadLine();

                TurbidityExperimentDataEntry();
            }
        }


        //Turbidity Experiment Data Search Section
        public static void TurbidityExperimentDataSearch()
        {
            string path = Program._config["TurbExpDataFile"];


            //If statement checks if CSV data file exists. If it does exist, it then proceeds with searching the file

            // If CSV file does not exist, it notifies user and gives direction to enter data

            if (File.Exists(path))
            {
                using (FileStream f = File.Open(Program._config["TurbExpDataFile"], FileMode.Open, FileAccess.ReadWrite, FileShare.Inheritable)) 
                {
                    Console.Clear();

                    Console.WriteLine(" *********************** Turbidity Experiment Data Search ***********************");

                    Console.WriteLine("");

                    Console.WriteLine("  Enter date that you would like to search: (Example: 06/01/2017)");

                    Console.WriteLine("");

                    string turbExpCSV = Program._config["TurbExpDataFile"];

                    string turbExpDate = Console.ReadLine();

                    Console.Clear();

                    char csvSeparator = ',';


                    // 'While loop' that searches TurbExpData.csv file for user input

                    using (var reader = new StreamReader(f))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();

                            foreach (string value in line.Replace("\"", "").Split('\r', '\n', csvSeparator))
                            {
                                if (value.Trim() == turbExpDate.Trim()) // case sensitive
                                {
                                    Console.Clear();

                                    Console.WriteLine(" *********************** Turbidity Experiment Data Search ***********************");

                                    Console.WriteLine("");

                                    Console.WriteLine("  Turbidity on " + value + " was " + line.Split(',')[1] + " NTU.");

                                    Console.WriteLine("");

                                    Console.WriteLine("  Press ENTER to go back..");

                                    Console.ReadLine();

                                    f.Close();

                                    Console.Clear();

                                    TurbidityExperimentMainMenu();

                                    break;
                                }

                                else if (value.Trim() != turbExpDate.Trim())
                                {
                                    break;
                                }
                            }
                        }
                    }


                    // If user entry does not match with data entry in csv file, for loop breaks and the console displays: There is no turbidity data for that date!

                    Console.Clear();

                    Console.WriteLine(" *********************** Turbidity Experiment Data Search ***********************");

                    Console.WriteLine("");

                    Console.WriteLine("  There is no turbidity data for that date!");

                    Console.WriteLine("");

                    Console.WriteLine("");

                    Console.WriteLine("  Press ENTER to go back");

                    Console.ReadLine();

                    f.Close();

                    Console.Clear();

                    TurbidityExperimentMainMenu();
                }
            }


            // Notifies user that CSV data file does not exist and gives direction to enter data

            else
            {
                Console.Clear();

                Console.WriteLine(" *********************** Turbidity Experiment Data Search ***********************");

                Console.WriteLine("");

                Console.WriteLine("  Turbidity Experiment data file does not exist. ");

                Console.WriteLine("");

                Console.WriteLine("  You need to first enter data to create the data file. ");

                Console.WriteLine("");

                Console.WriteLine("  Press ENTER to go back..");

                Console.ReadLine();

                TurbidityExperimentMainMenu();

            }
        }


        // Delete ALL data section (It deletes CSV data file)

        public static void TurbidityExperimentDeleteALL()
        {
            Console.Clear();

            Console.WriteLine(" *********************** Delete ALL Turbidity Experiment Data ***********************");

            Console.WriteLine("");

            Console.WriteLine("  Do you wish to delete ALL data? (Y/N)");

            string answer = Console.ReadLine();

            // Above section checks if user wants to delete all input date. If yes, CSV data file gets deleted

            string turbExpDataFile = Path.GetFullPath(Program._config["TurbExpDataFile"]);


            /** If statement first checks if CSV file is present. If it is, then it proceeds with the program.
             If CSV file is not present then it notifies user that CSV data file is missing and cannot be deleted **/

            if (answer == "Y")
            {
                if (File.Exists(Program._config["TurbExpDataFile"]))
                {
                    File.Delete(turbExpDataFile);

                    Console.WriteLine(turbExpDataFile);

                    Console.Clear();

                    Console.WriteLine(" *********************** Delete ALL Turbidity Experiment Data ***********************");

                    Console.WriteLine("");

                    Console.WriteLine("  File was deleted. Press ENTER to go back to the main menu..");

                    Console.ReadLine();

                    Console.Clear();

                    TurbidityExperimentMainMenu();
                }


                // Notifies user that data file is missing and cannot be deleted

                else

                Console.Clear();

                Console.WriteLine(" *********************** Delete ALL Turbidity Experiment Data ***********************");

                Console.WriteLine("");

                Console.WriteLine("  Turbidity Experiment data file was not found.");

                Console.WriteLine("");

                Console.WriteLine("  Press ENTER to go back to the main menu..");

                Console.ReadLine();

                Console.Clear();

                TurbidityExperimentMainMenu();
            }

            else if (answer == "N")
            {
                Console.Clear();

                Console.WriteLine(" *********************** Delete ALL Turbidity Experiment Data ***********************");

                Console.WriteLine("");

                Console.WriteLine("  Data file was NOT deleted. Please press ENTER to go back to the main menu..");

                Console.ReadLine();

                Console.Clear();

                TurbidityExperimentMainMenu();
            }
        }
    }
}