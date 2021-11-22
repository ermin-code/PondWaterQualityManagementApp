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

            Console.WriteLine(" *********************** pH Experiment ***********************");

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

            Console.WriteLine(" *********************** pH Experiment Data Entry ***********************");

            Console.WriteLine("");

            Console.WriteLine("  Maintaining a safe pH level is essential for health of your koi fish. ");

            Console.WriteLine("  Koi fish can survive within a reasonable range, but extreme changes in ");

            Console.WriteLine("  pH can cause stress and in some cases death of your fish. pH scale is  ");

            Console.WriteLine("  used to measure acidity in water. Certain chemicals and environmental ");

            Console.WriteLine("  changes can cause suddan raise or drop in pH levels. ");

            Console.WriteLine("");

            Console.WriteLine("  Safe pH for Koi fish is between 5 and 8.5 pH. pH between 2 and 5 is ");

            Console.WriteLine("  considered low while pH under 2 is extremely dangerous for Koi fish ");

            Console.WriteLine("  and chemicals need to be added immediately to bring pH to safe levels.  ");

            Console.WriteLine(" ");

            Console.WriteLine("  Regular testing and monitoring daily changes in pH is essential to");

            Console.WriteLine("  to keep your fish healthy and safe. In this experiment, we will collect ");

            Console.WriteLine("  pH data on your pond water using Vernier pH probe, Texas Instruments");

            Console.WriteLine("  Graphing Calculator with attached CBL2 Calculator-Based Laboratory.");

            Console.WriteLine("");

            Console.WriteLine("");

            Console.WriteLine("  Please enter date for experiment (Example: 06/01/2017):");

            Console.WriteLine("");

            string pHExpDate = Console.ReadLine();

            Console.Clear();

            Console.WriteLine(" *********************** pH Experiment Data Entry ***********************");

            Console.WriteLine("");

            Console.WriteLine("  Please enter pH observed :");

            string pHExppH = Console.ReadLine();

            Console.Clear();


            // Stores date and pH data in CSV file following [date, pH] format 

            List<string> dateAndpH = new List<string>();

            List<string> dateAndpHInit = new List<string>();

            string path = Path.GetFullPath(Program._config["pHExpDataFile"]);


            /** If statement checks if CSV data file is present. If it is present, the program continues..
             If CSV data file is not present, it initializes or creates an empty CSV data file **/

            if (File.Exists(path))
            {
                dateAndpH.Add($"{pHExpDate},{pHExppH}");


                // Stores date and pH data in CSV file following [date, pH] format

                File.AppendAllLines(Program._config["pHExpDataFile"], dateAndpH);

                float pHExppHInt = float.Parse(pHExppH);


                // If pH is less than 6.5, it notifies user that water pH is too low for Koi fish

                if (pHExppHInt < 6.5)
                {
                    Console.Clear();

                    Console.WriteLine(" *********************** pH Experiment Data Entry ***********************");

                    Console.WriteLine("");

                    Console.WriteLine("  This pH is TOO LOW for your Koi fish! Press ENTER to continue..");

                    Console.ReadLine();

                    Console.Clear();

                    pHExperiment.pHExperimentMainMenu();
                }


                // If pH is in between 6.5 and 8.5, it notifies user that water pH is in ideal range for Koi fish

                else if (pHExppHInt >= 6.5 && pHExppHInt <= 8.5)
                {
                    Console.Clear();
                    
                    Console.WriteLine(" *********************** pH Experiment Data Entry ***********************");

                    Console.WriteLine("");

                    Console.WriteLine("  This pH is IDEAL for your Koi fish! Press ENTER to continue..");

                    Console.ReadLine();

                    Console.Clear();

                    pHExperiment.pHExperimentMainMenu();
                }


                // If pH is greater than 8.5, it notifies user that water pH is too high for Koi fish

                else if (pHExppHInt > 8.5)
                {
                    Console.Clear();

                    Console.WriteLine(" *********************** pH Experiment Data Entry ***********************");

                    Console.WriteLine("");

                    Console.WriteLine("  This pH is TOO HIGH for your Koi fish! Press ENTER to continue..");

                    Console.ReadLine();

                    Console.Clear();

                    pHExperiment.pHExperimentMainMenu();
                }
            }


            // Initializes/creates an empty CSV data file
            
            else
            {

                dateAndpHInit.Add("Date, pH");

                File.AppendAllLines(Program._config["pHExpDataFile"], dateAndpHInit);


                Console.Clear();

                Console.WriteLine(" *********************** pH Experiment Data Entry ***********************");

                Console.WriteLine("");

                Console.WriteLine("  Initialized File. Please press ENTER to go back and re-enter data..");

                Console.ReadLine();

                pHExperimentDataEntry();
            }
        }


        //pH Experiment Data Search Section
        public static void pHExperimentDataSearch()
        {
            string path = Program._config["pHExpDataFile"];


            // If statement checks if CSV data file exists. If it does exist, it then proceeds with searching the file

            // If CSV file does not exist, it notifies user and gives direction to enter data


            if (File.Exists(path))
            { 
                using (FileStream f = File.Open(Program._config["pHExpDataFile"], FileMode.Open, FileAccess.ReadWrite, FileShare.Inheritable)) 
                {
                Console.Clear();

                Console.WriteLine(" *********************** pH Experiment Data Search ***********************");

                Console.WriteLine("");

                Console.WriteLine("  Enter date that you would like to search: (Example: 06/01/2017)");

                Console.WriteLine("");

                string pHExpCSV = Program._config["pHExpDataFile"];

                string pHExpDate = Console.ReadLine();

                Console.Clear();

                char csvSeparator = ',';


                    // 'While loop' that searches pHExpData.csv file for user input

                    // This loop also has an additional feature that tests if water pH is safe for Koi fish

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

                                    Console.WriteLine(" *********************** pH Experiment Data Search ***********************");

                                    Console.WriteLine("");

                                    Console.WriteLine("  pH on " + value + " was " + line.Split(',')[1] + ".");

                                    Console.WriteLine("");

                                    Console.WriteLine("  This pH is TOO LOW for your Koi fish!");

                                    Console.WriteLine("");

                                    Console.WriteLine("  Press ENTER to go back..");

                                    Console.ReadLine();

                                    f.Close();

                                    Console.Clear();

                                    pHExperimentMainMenu();

                                    break;
                                }

                                if (value.Trim() == pHExpDate.Trim() && (float.Parse(line.Split(',')[1]) >= 6.5) && (float.Parse(line.Split(',')[1]) <= 8.5)) // case sensitive
                                {
                                    Console.Clear();

                                    Console.WriteLine(" *********************** pH Experiment Data Search ***********************");

                                    Console.WriteLine("");

                                    Console.WriteLine("  pH on " + value + " was " + line.Split(',')[1] + ".");

                                    Console.WriteLine("");

                                    Console.WriteLine("  This pH is IDEAL for your Koi fish!");

                                    Console.WriteLine("");

                                    Console.WriteLine("  Press ENTER to go back.");

                                    Console.ReadLine();

                                    f.Close();

                                    Console.Clear();

                                    pHExperimentMainMenu();

                                    break;
                                }

                                if (value.Trim() == pHExpDate.Trim() && (float.Parse(line.Split(',')[1]) > 8.5)) // case sensitive
                                {
                                    Console.Clear();

                                    Console.WriteLine(" *********************** pH Experiment Data Search ***********************");

                                    Console.WriteLine("");

                                    Console.WriteLine("  pH on " + value + " was " + line.Split(',')[1] + ".");

                                    Console.WriteLine("");

                                    Console.WriteLine("  This pH is TOO HIGH for your Koi fish!");

                                    Console.WriteLine("");

                                    Console.WriteLine("  Press ENTER to go back.");

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
                }


                // If user entry does not match with data entry in csv file, for loop breaks and the console displays: There is no pH data for that date!

                Console.Clear();

                Console.WriteLine(" *********************** pH Experiment Data Search ***********************");

                Console.WriteLine("");

                Console.WriteLine("  There is no pH data for that date!");

                Console.WriteLine("");

                Console.WriteLine("");

                Console.WriteLine("  Press ENTER to go back");

                Console.ReadLine();
 
                Console.Clear();

                pHExperimentMainMenu();
            }


            // Notifies user that CSV dat afile does not exist and gives direction to enter data 

            else
            {
                Console.Clear();

                Console.WriteLine(" *********************** pH Experiment Data Search ***********************");

                Console.WriteLine("");

                Console.WriteLine("  pH Experiment data file does not exist. ");

                Console.WriteLine("");

                Console.WriteLine("  You need to first enter data to create the data file. ");

                Console.WriteLine("");

                Console.WriteLine("  Press ENTER to go back..");

                Console.ReadLine();

                pHExperimentMainMenu();
            }
        }


        // Delete ALL data section (It deletes CSV data file)

        public static void pHExperimentDeleteALL()
        {
            Console.Clear();

            Console.WriteLine(" *********************** Delete ALL pH Experiment Data ***********************");

            Console.WriteLine("");

            Console.WriteLine("Do you wish to delete ALL data? (Y/N)");

            string answer = Console.ReadLine();

            // Above section checks if user wants to delete all input data. If yes, CSV data file gets deleted

            string pHExpDataFile = Path.GetFullPath(Program._config["pHExpDataFile"]);

            /** If statement first checks if CSV file is present. If it is, then it proceeds with the program.
             If CSV file is not present then it notifies user that CSV data file is missing and cannot be deleted **/

            if (answer == "Y")
            {
                if (File.Exists(Program._config["pHExpDataFile"]))
                {
                    File.Delete(pHExpDataFile);

                    Console.WriteLine(pHExpDataFile);

                    Console.Clear();

                    Console.WriteLine(" *********************** Delete ALL pH Experiment Data ***********************");

                    Console.WriteLine("");

                    Console.WriteLine("  File was deleted. Press ENTER to go back to the main menu..");

                    Console.ReadLine();

                    Console.Clear();

                    pHExperimentMainMenu();
                }

                // Notifies user that data file is missing and cannot be deleted

                else

                    Console.Clear();

                    Console.WriteLine(" *********************** Delete ALL pH Experiment Data ***********************");

                    Console.WriteLine("");

                    Console.WriteLine("  pH Experiment data file was not found.");

                    Console.WriteLine("");

                    Console.WriteLine("  Press ENTER to go back to the main menu..");

                    Console.ReadLine();

                    Console.Clear();

                    pHExperimentMainMenu();
            }

            else if (answer == "N")
            {
                Console.Clear();

                Console.WriteLine(" *********************** Delete ALL pH Experiment Data ***********************");

                Console.WriteLine("");

                Console.WriteLine("  Data file was NOT deleted. Please press ENTER to go back to the main menu..");

                Console.ReadLine();

                Console.Clear();

                pHExperimentMainMenu();
            }
        }
    }
}