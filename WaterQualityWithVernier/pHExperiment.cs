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
    class pHExperiment
    {
        // pH Experiment Menu
        public static void pHExperimentMainMenu()
        {
            Console.Clear();

            Console.WriteLine("*********************** pH Experiment ***********************");

            Console.WriteLine("");

            Console.WriteLine("     Option 1. Enter pH Data");

            Console.WriteLine("     Option 2. Search pH Data");

            Console.WriteLine("     Option 3. Delete ALL Data");

            Console.WriteLine("");

            Console.WriteLine("     Option 4. Exit to Main Menu");

            string myOptions;
            myOptions = Console.ReadLine();

            switch (myOptions)
            {
                case "1":
                    pHExperimentDataEntry();
                    break;

                case "2":
                    pHExperimentDataSearch();
                    break;

                case "3":
                    pHExperimentDeleteALL();
                    break;

                case "4":
                    Program.MainMenu();
                    break;
            }
        }


        // pH Data Entry Section
        public static void pHExperimentDataEntry()
        {
            Console.Clear();

            Console.WriteLine("*********************** pH Experiment Data Entry ***********************");

            Console.WriteLine("");

            Console.WriteLine(" ");

            Console.WriteLine(" ");

            Console.WriteLine(" ");

            Console.WriteLine(" ");

            Console.WriteLine(" ");

            Console.WriteLine(" ");

            Console.WriteLine(" ");

            Console.WriteLine(" ");

            Console.WriteLine(" Please enter the date of the experiment (Example: 06/01/2017):");

            Console.WriteLine("");

            string pHExpDate = Console.ReadLine();

            Console.Clear();

            Console.WriteLine(" Please enter pH recorded :");

            Console.WriteLine("");

            string pHExppH = Console.ReadLine();

            Console.Clear();


            // Stores date and pH data in CSV file following [date, pH] format 

            List<string> dateAndpH = new List<string>();

            List<string> dateAndpHInit = new List<string>();

            string path = Path.GetFullPath(Program._config["pHExpDataFile"]);

            if (File.Exists(path))
            {
                dateAndpH.Add($"{pHExpDate},{pHExppH}");

                File.AppendAllLines(Program._config["pHExpDataFile"], dateAndpH);

                float pHExppHInt = float.Parse(pHExppH);


                // Notifies user if pH is safe or not safe for your Koi fish

                if (pHExppHInt < 6.5)
                {
                    Console.WriteLine("This pH is TOO LOW for your Koi fish! Press ENTER to continue..");

                    Console.ReadLine();

                    Console.Clear();

                    pHExperiment.pHExperimentMainMenu();
                }

                else if (pHExppHInt >= 6.5 && pHExppHInt <= 8.5)
                {
                    Console.WriteLine("This pH is IDEAL for your Koi fish! Press ENTER to continue..");

                    Console.ReadLine();

                    Console.Clear();

                    pHExperiment.pHExperimentMainMenu();
                }

                else if (pHExppHInt > 8.5)
                {
                    Console.WriteLine("This pH is TOO HIGH for your Koi fish! Press ENTER to continue..");

                    Console.ReadLine();

                    Console.Clear();

                    pHExperiment.pHExperimentMainMenu();
                }

            }

            else
            {
                dateAndpHInit.Add("Date, pH");

                File.AppendAllLines(Program._config["pHExpDataFile"], dateAndpHInit);

                Console.WriteLine("Initialized File. Please press ENTER to go back and re-enter data..");

                Console.ReadLine();

                pHExperimentDataEntry();
            }
        }


        //pH Experiment Data Search Section
        public static void pHExperimentDataSearch()
        {
            using (FileStream f = File.Open(Program._config["pHExpDataFile"], FileMode.Open, FileAccess.ReadWrite, FileShare.Inheritable)) // Here I need to enter if statement that tests for presence of CSV data file...
            {
                Console.Clear();

                Console.WriteLine("*********************** pH Experiment Data Search ***********************");

                Console.WriteLine("");

                Console.WriteLine("What date would you like to search pH data for? (Example: 06/01/2017)");

                Console.WriteLine("");

                string pHExpCSV = Program._config["pHExpDataFile"];

                string pHExpDate = Console.ReadLine();

                Console.Clear();

                char csvSeparator = ',';


                // 'For Loop' that searches each entry in TExpData.csv file. If user entry matches with data entry in csv file the console displays: pH on <entered date> date was ...
                // this loop also has an additional feature which is to display if pH on searched date is safe for Koi fish

                using (var reader = new StreamReader(f))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        foreach (string value in line.Replace("\"", "").Split('\r', '\n', csvSeparator))
                        {
                            if (value.Trim() == pHExpDate.Trim() && (float.Parse(line.Split(',')[1]) < 6.5)) // case sensitive
                            {
                                Console.Clear();

                                Console.WriteLine("pH on " + value + " was " + line.Split(',')[1] + ".");

                                Console.WriteLine("");

                                Console.WriteLine("This pH is TOO LOW for your Koi fish!");

                                Console.WriteLine("");

                                Console.WriteLine("Press ENTER to go back..");

                                Console.ReadLine();

                                f.Close();

                                Console.Clear();

                                pHExperimentMainMenu();

                                break;
                            }

                            if (value.Trim() == pHExpDate.Trim() && (float.Parse(line.Split(',')[1]) >= 6.5) && (float.Parse(line.Split(',')[1]) <= 8.5)) // case sensitive
                            {
                                Console.Clear();

                                Console.WriteLine("pH on " + value + " was " + line.Split(',')[1] + ".");

                                Console.WriteLine("");

                                Console.WriteLine("This pH is IDEAL for your Koi fish!");

                                Console.WriteLine("");

                                Console.WriteLine("Press ENTER to go back.");

                                Console.ReadLine();

                                f.Close();

                                Console.Clear();

                                pHExperimentMainMenu();

                                break;
                            }

                            if (value.Trim() == pHExpDate.Trim() && (float.Parse(line.Split(',')[1]) > 8.5)) // case sensitive
                            {
                                Console.Clear();

                                Console.WriteLine("pH on " + value + " was " + line.Split(',')[1] + ".");

                                Console.WriteLine("");

                                Console.WriteLine("This pH is TOO HIGH for your Koi fish!");

                                Console.WriteLine("");

                                Console.WriteLine("Press ENTER to go back.");

                                Console.ReadLine();

                                f.Close();

                                Console.Clear();

                                pHExperimentMainMenu();

                                break;
                            }






                            else if (value.Trim() != pHExpDate.Trim())
                            {
                                break;
                            }
                        }
                    }
                }


                // If user entry does not match with data entry in csv file, for loop breaks and the console displays: There is no pH data for that date!

                Console.Clear();

                Console.WriteLine("There is no pH data for that date!");

                Console.WriteLine("");

                Console.WriteLine("");

                Console.WriteLine("Press ENTER to go back");

                Console.ReadLine();

                f.Close();

                Console.Clear();

                pHExperimentMainMenu();
            }
        }

        public static void pHExperimentDeleteALL()
        {
            Console.Clear();

            Console.WriteLine("*********************** Delete ALL pH Experiment Data ***********************");

            Console.WriteLine("");

            Console.WriteLine("Do you wish to delete ALL data? (Y/N)");

            string answer = Console.ReadLine();

            string pHExpDataFile = Path.GetFullPath(Program._config["pHExpDataFile"]);

            if (answer == "Y")
            {
                if (File.Exists(Program._config["pHExpDataFile"]))
                {
                    File.Delete(pHExpDataFile);

                    Console.WriteLine(pHExpDataFile);

                    Console.Clear();

                    Console.WriteLine("File was deleted. Press ENTER to go back to the main menu..");

                    Console.ReadLine();

                    Console.Clear();

                    pHExperimentMainMenu();
                }

                else

                    Console.Clear();

                Console.WriteLine("File not found..");

                Console.WriteLine("");

                Console.WriteLine("Press ENTER to go back to the main menu..");

                Console.ReadLine();

                Console.Clear();

                pHExperimentMainMenu();
            }

            else if (answer == "N")
            {
                Console.Clear();

                Console.WriteLine("Data file was NOT deleted. Please press ENTER to go back to the main menu..");

                Console.ReadLine();

                Console.Clear();

                pHExperimentMainMenu();
            }
        }
    }
}