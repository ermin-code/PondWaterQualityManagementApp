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
    class DissolvedOxygenExperiment
    {
        // Temperature Experiment Menu
        public static void DissolvedOxygenExperimentMainMenu()
        {
            Console.Clear();

            Console.WriteLine("*********************** Dissolved Oxygen Experiment ***********************");

            Console.WriteLine("");

            Console.WriteLine("     Option 1. Enter Dissolved Oxygen Data");

            Console.WriteLine("     Option 2. Search Dissolved Oxygen Data");

            Console.WriteLine("     Option 3. Delete ALL Data");

            Console.WriteLine("");

            Console.WriteLine("     Option 4. Exit to Main Menu");

            string myOptions;
            myOptions = Console.ReadLine();

            switch (myOptions)
            {
                case "1":
                    DissolvedOxygenExperimentDataEntry();
                    break;

                case "2":
                    DissolvedOxygenExperimentDataSearch();
                    break;

                case "3":
                    DissolvedOxygenExperimentDeleteALL();
                    break;

                case "4":
                    Program.MainMenu();
                    break;
            }
        }


        // Temperature Data Entry Section
        public static void DissolvedOxygenExperimentDataEntry()
        {
            Console.Clear();

            Console.WriteLine("*********************** Dissolved Oxygen Experiment Data Entry ***********************");

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

            string dOExpDate = Console.ReadLine();

            Console.Clear();

            Console.WriteLine(" Please enter dissolved oxygen recorded (in mg/L):");

            Console.WriteLine("");

            string dOExpDO = Console.ReadLine();

            Console.Clear();


            // Stores date and dissolved oxygen data in CSV file following [date, dissolved oxygen] format 

            List<string> dateAndDO = new List<string>();

            List<string> dateAndDOInit = new List<string>();

            string path = Path.GetFullPath(Program._config["DOExpDataFile"]);

            if (File.Exists(path))
            {
                dateAndDO.Add($"{dOExpDate},{dOExpDO}");

                File.AppendAllLines(Program._config["DOExpDataFile"], dateAndDO);

                int dOExpDOInt = Int32.Parse(dOExpDO);


                // Notifies user if dissolved oxygen that was entered is safe for Koi fish

                if (dOExpDOInt < 50)
                {
                    Console.WriteLine("This level of dissolved oxygen is TOO LOW for your Koi fish! Press ENTER to continue..");

                    Console.ReadLine();

                    Console.Clear();

                    DissolvedOxygenExperiment.DissolvedOxygenExperimentMainMenu();
                }

                else if (dOExpDOInt >= 50)
                {
                    Console.WriteLine("This level of dissolved oxygen is PERFECT for your Koi fish! Press ENTER to continue..");

                    Console.ReadLine();

                    Console.Clear();

                    DissolvedOxygenExperiment.DissolvedOxygenExperimentMainMenu();
                }
            }

            else
            {
                dateAndDOInit.Add("Date,Dissolved Oxygen (mg/L)");

                File.AppendAllLines(Program._config["DOExpDataFile"], dateAndDOInit);

                Console.WriteLine("Initialized File. Please press ENTER to go back and re-enter data..");

                Console.ReadLine();

                DissolvedOxygenExperimentDataEntry();
            }
        }


        //Dissolved Oxygen Experiment Data Search Section
        public static void DissolvedOxygenExperimentDataSearch()
        {
            using (FileStream f = File.Open(Program._config["DOExpDataFile"], FileMode.Open, FileAccess.ReadWrite, FileShare.Inheritable)) // Here I need to enter if statement that tests for presence of CSV data file...
            {
                Console.Clear();

                Console.WriteLine("*********************** Dissolved Oxygen Experiment Data Search ***********************");

                Console.WriteLine("");

                Console.WriteLine("What date would you like to search temperature data for? (Example: 06/01/2017)");

                Console.WriteLine("");

                string dOExpCSV = Program._config["DOExpDataFile"];

                string dOExpDate = Console.ReadLine();

                Console.Clear();

                char csvSeparator = ',';


                // 'For Loop' that searches each entry in DOExpData.csv file. If user entry matches with data entry in csv file the console displays: Dissolved Oxygen on <entered date> date was ...
                // this loop also has an additional feature which is to display if dissolved oxygen on searched date is safe for Koi fish

                using (var reader = new StreamReader(f))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        foreach (string value in line.Replace("\"", "").Split('\r', '\n', csvSeparator))
                        {
                            if (value.Trim() == dOExpDate.Trim() && (Int32.Parse(line.Split(',')[1]) < 50)) // case sensitive
                            {
                                Console.Clear();

                                Console.WriteLine("Dissolved oxygen on " + value + " was " + line.Split(',')[1] + " mg/L.");

                                Console.WriteLine("");

                                Console.WriteLine("This level of dissolved oxygen is NOT SAFE for your Koi fish!");

                                Console.WriteLine("");

                                Console.WriteLine("Press ENTER to go back..");

                                Console.ReadLine();

                                f.Close();

                                Console.Clear();

                                DissolvedOxygenExperimentMainMenu();

                                break;
                            }

                            if (value.Trim() == dOExpDate.Trim() && (Int32.Parse(line.Split(',')[1]) >= 50)) // case sensitive
                            {
                                Console.Clear();

                                Console.WriteLine("Dissolved oxygen on " + value + " was " + line.Split(',')[1] + " mg/L.");

                                Console.WriteLine("");

                                Console.WriteLine("This level of dissolved oxygen is PERFECT for your Koi fish!");

                                Console.WriteLine("");

                                Console.WriteLine("Press ENTER to go back.");

                                Console.ReadLine();

                                f.Close();

                                Console.Clear();

                                DissolvedOxygenExperimentMainMenu();

                                break;
                            }

                            else if (value.Trim() != dOExpDate.Trim())
                            {
                                break;
                            }
                        }
                    }
                }


                // If user entry does not match with data entry in csv file, for loop breaks and the console displays: There is no dissolved oxygen data for that date!

                Console.Clear();

                Console.WriteLine("There is no dissolved oxygen data for that date!");

                Console.WriteLine("");

                Console.WriteLine("");

                Console.WriteLine("Press ENTER to go back");

                Console.ReadLine();

                f.Close();

                Console.Clear();

                DissolvedOxygenExperimentMainMenu();
            }
        }

        public static void DissolvedOxygenExperimentDeleteALL()
        {
            Console.Clear();

            Console.WriteLine("*********************** Delete ALL Dissolved Oxygen Experiment Data ***********************");

            Console.WriteLine("");

            Console.WriteLine("Do you wish to delete ALL data? (Y/N)");

            string answer = Console.ReadLine();

            string dOExpDataFile = Path.GetFullPath(Program._config["DOExpDataFile"]);

            if (answer == "Y")
            {
                if (File.Exists(Program._config["DOExpDataFile"]))
                {
                    File.Delete(dOExpDataFile);

                    Console.WriteLine(dOExpDataFile);

                    Console.Clear();

                    Console.WriteLine("File was deleted. Press ENTER to go back to the main menu..");

                    Console.ReadLine();

                    Console.Clear();

                    DissolvedOxygenExperimentMainMenu();
                }

                else

                    Console.Clear();

                Console.WriteLine("File not found..");

                Console.WriteLine("");

                Console.WriteLine("Press ENTER to go back to the main menu..");

                Console.ReadLine();

                Console.Clear();

                DissolvedOxygenExperimentMainMenu();
            }

            else if (answer == "N")
            {
                Console.Clear();

                Console.WriteLine("Data file was NOT deleted. Please press ENTER to go back to the main menu..");

                Console.ReadLine();

                Console.Clear();

                DissolvedOxygenExperimentMainMenu();
            }
        }
    }
}