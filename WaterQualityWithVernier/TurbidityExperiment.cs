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

            Console.WriteLine("*********************** Turbidity Experiment ***********************");

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


        // Temperature Data Entry Section
        public static void TurbidityExperimentDataEntry()
        {
            Console.Clear();

            Console.WriteLine("*********************** Turbidity Experiment Data Entry ***********************");

            Console.WriteLine("");

            Console.WriteLine("");

            Console.WriteLine("");

            Console.WriteLine("");

            Console.WriteLine("");

            Console.WriteLine("");

            Console.WriteLine("");

            Console.WriteLine("");

            Console.WriteLine("");

            Console.WriteLine(" Please enter the date of the experiment (Example: 06/01/2017):");

            Console.WriteLine("");

            string turbExpDate = Console.ReadLine();

            Console.Clear();

            Console.WriteLine(" Please enter turbidity recorded (in NTU):");

            Console.WriteLine("");

            string turbExpTurb = Console.ReadLine();

            Console.Clear();


            // Stores date and temperature data in CSV file following [date, temperature] format 

            List<string> dateAndTurb = new List<string>();

            List<string> dateAndTurbInit = new List<string>();

            string path = Path.GetFullPath(Program._config["TurbExpDataFile"]);

            if (File.Exists(path))
            {
                dateAndTurb.Add($"{turbExpDate},{turbExpTurb}");

                File.AppendAllLines(Program._config["TurbExpDataFile"], dateAndTurb);

                int turbExpTurbInt = Int32.Parse(turbExpTurb);


                // Notifies user if water temperature that was entered is safe to feed their Koi fish

                if (turbExpTurbInt < 50)
                {
                    Console.WriteLine("This turbidity is TOO HIGH for your pond! Press ENTER to continue..");

                    Console.ReadLine();

                    Console.Clear();

                    TurbidityExperiment.TurbidityExperimentMainMenu();
                }

                else if (turbExpTurbInt >= 50)
                {
                    Console.WriteLine("This turbidity is PERFECT for your pond! Press ENTER to continue..");

                    Console.ReadLine();

                    Console.Clear();

                    TurbidityExperiment.TurbidityExperimentMainMenu();
                }
            }

            else
            {
                dateAndTurbInit.Add("Date,Turbidity (NTU)");

                File.AppendAllLines(Program._config["TurbExpDataFile"], dateAndTurbInit);

                Console.WriteLine("Initialized File. Please press ENTER to go back and re-enter data..");

                Console.ReadLine();

                TurbidityExperimentDataEntry();
            }
        }


        //Turbidity Experiment Data Search Section
        public static void TurbidityExperimentDataSearch()
        {
            using (FileStream f = File.Open(Program._config["TurbExpDataFile"], FileMode.Open, FileAccess.ReadWrite, FileShare.Inheritable)) // Here I need to enter if statement that tests for presence of CSV data file...
            {
                Console.Clear();

                Console.WriteLine("*********************** Turbidity Experiment Data Search ***********************");

                Console.WriteLine("");

                Console.WriteLine("What date would you like to search turbidity data for? (Example: 06/01/2017)");

                Console.WriteLine("");

                string turbExpCSV = Program._config["TurbExpDataFile"];

                string turbExpDate = Console.ReadLine();

                Console.Clear();

                char csvSeparator = ',';


                // 'For Loop' that searches each entry in TurbExpData.csv file. If user entry matches with data entry in csv file the console displays: Turbidity on <entered date> date was ...
                // this loop also has an additional feature which is to display if water turbidity is at optimal level for your pond.

                using (var reader = new StreamReader(f))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        foreach (string value in line.Replace("\"", "").Split('\r', '\n', csvSeparator))
                        {
                            if (value.Trim() == turbExpDate.Trim() && (Int32.Parse(line.Split(',')[1]) < 50)) // case sensitive
                            {
                                Console.Clear();

                                Console.WriteLine("Turbidity on " + value + " was " + line.Split(',')[1] + " NTU.");

                                Console.WriteLine("");

                                Console.WriteLine("This turbidity is TOO HIGH for your pond!");

                                Console.WriteLine("");

                                Console.WriteLine("Press ENTER to go back..");

                                Console.ReadLine();

                                f.Close();

                                Console.Clear();

                                TurbidityExperimentMainMenu();

                                break;
                            }

                            if (value.Trim() == turbExpDate.Trim() && (Int32.Parse(line.Split(',')[1]) >= 50)) // case sensitive
                            {
                                Console.Clear();

                                Console.WriteLine("Turbidity on " + value + " was " + line.Split(',')[1] + " NTU.");

                                Console.WriteLine("");

                                Console.WriteLine("This turbidity is PERFECT for your Koi pond!");

                                Console.WriteLine("");

                                Console.WriteLine("Press ENTER to go back.");

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

                Console.WriteLine("There is no turbidity data for that date!");

                Console.WriteLine("");

                Console.WriteLine("");

                Console.WriteLine("Press ENTER to go back");

                Console.ReadLine();

                f.Close();

                Console.Clear();

                TurbidityExperimentMainMenu();
            }
        }

        public static void TurbidityExperimentDeleteALL()
        {
            Console.Clear();

            Console.WriteLine("*********************** Delete ALL Turbidity Experiment Data ***********************");

            Console.WriteLine("");

            Console.WriteLine("Do you wish to delete ALL data? (Y/N)");

            string answer = Console.ReadLine();

            string turbExpDataFile = Path.GetFullPath(Program._config["TurbExpDataFile"]);

            if (answer == "Y")
            {
                if (File.Exists(Program._config["TurbExpDataFile"]))
                {
                    File.Delete(turbExpDataFile);

                    Console.WriteLine(turbExpDataFile);

                    Console.Clear();

                    Console.WriteLine("File was deleted. Press ENTER to go back to the main menu..");

                    Console.ReadLine();

                    Console.Clear();

                    TurbidityExperimentMainMenu();
                }

                else

                Console.Clear();

                Console.WriteLine("File not found..");

                Console.WriteLine("");

                Console.WriteLine("Press ENTER to go back to the main menu..");

                Console.ReadLine();

                Console.Clear();

                TurbidityExperimentMainMenu();
            }

            else if (answer == "N")
            {
                Console.Clear();

                Console.WriteLine("Data file was NOT deleted. Please press ENTER to go back to the main menu..");

                Console.ReadLine();

                Console.Clear();

                TurbidityExperimentMainMenu();
            }
        }
    }
}