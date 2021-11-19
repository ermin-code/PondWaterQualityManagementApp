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
    class TemperatureExperiment
    {
        // Temperature Experiment Main Menu
        public static void TemperatureExperimentMainMenu()
        { 
            Console.Clear();
            
            Console.WriteLine(" *********************** Temperature Experiment ***********************");
            
            Console.WriteLine("");
            
            Console.WriteLine("     Option 1. Enter Temperature Data");
            
            Console.WriteLine("     Option 2. Search Temperature Data");
            
            Console.WriteLine("     Option 3. Delete ALL Data");
            
            Console.WriteLine("");
            
            Console.WriteLine("     Option 4. Exit to Main Menu");

            string myOptions;
            myOptions = Console.ReadLine();
            
            switch (myOptions)
            {
                case "1":
                    TemperatureExperimentDataEntry();
                    break;

                case "2":
                    TemperatureExperimentDataSearch();
                    break;

                case "3":
                    TemperatureExperimentDeleteALL();
                    break;

                case "4":
                    Program.MainMenu();
                    break;
            }
        }


        // Temperature Data Entry Section
        public static void TemperatureExperimentDataEntry()
        {
                Console.Clear();
                
                Console.WriteLine(" *********************** Temperature Experiment Data Entry ***********************");
                
                Console.WriteLine("");

                Console.WriteLine("  In this experiment you will collect temperature data on your pond water using ");

                Console.WriteLine("  Vernier temperature probe, Texas Instruments Graphing Calculator with attached ");

                Console.WriteLine("  CBL2 Calculator-Based Laboratory.");

                Console.WriteLine("");

                Console.WriteLine("  Outdoor water temperatures can range from 32 degrees Celsius to above 86 degrees ");

                Console.WriteLine("  Celsius in the summer. In general, cooler water in the pond is generally considered ");

                Console.WriteLine("  healthier than warmer water.");

                Console.WriteLine();

                Console.WriteLine("  Pond water temperature plays a vital role in the overal health of the eco-system ");

                Console.WriteLine("  and the health of pond fish. The perfect pond water should be in the range of ");

                Console.WriteLine("  68 to 74 degrees Fahrenheit.");

                Console.WriteLine("");

                Console.WriteLine("  During summer, water loses much of its ability to hold oxygen when ");

                Console.WriteLine("  temperature is above 85 degrees. In winter, when temperature goes below 39 ");

                Console.WriteLine("  degrees Fahrenheit fish do not have to eat.");
                
                Console.WriteLine("");

                Console.WriteLine("  This experiment will collect temperature data, store it for later retreaval,");

                Console.WriteLine("  and let you know if you should continue or stop feeding your fish based on ");
                
                Console.WriteLine("  water temperature entered.");
                
                Console.WriteLine("");

                Console.WriteLine("");
            
                Console.WriteLine("  Please enter date for experiment (Example: 06/01/2017):");
                
                Console.WriteLine("");

                string tExpDate = Console.ReadLine();

                Console.Clear();

                Console.WriteLine(" *********************** Temperature Experiment Data Entry ***********************");

                Console.WriteLine("");

                Console.WriteLine("  Please enter temperature observed (in \x00B0F):");
                
                Console.WriteLine("");

                string tExpTemp = Console.ReadLine();

                Console.Clear();
                     
                List<string> dateAndTemp = new List<string>();
                
                List<string> dateAndTempInit = new List<string>();

                string path = Path.GetFullPath(Program._config["TempExpDataFile"]);


                /** If statement checks if CSV data file is present. If it is present, the program continues..
                 If CSV data file is not present, it initializes or creates an empty CSV data file**/

                if (File.Exists(path))
                {
                    dateAndTemp.Add($"{tExpDate},{tExpTemp}");

                    // Stores date and temperature data in CSV file following [date, temperature] format 
                
                    File.AppendAllLines(Program._config["TempExpDataFile"], dateAndTemp);

                    int tExpTempInt = Int32.Parse(tExpTemp);


                    // If temperature is less than 50 degrees Fahrenheit it notifies user that water temperature is not safe for feeding Koi fish
       
                    if (tExpTempInt < 50)
                    {
                        Console.Clear();
                    
                        Console.WriteLine(" *********************** Temperature Experiment Data Entry ***********************");

                        Console.WriteLine("");

                        Console.WriteLine("  This temperature is NOT SAFE to feed your Koi fish! Press ENTER to continue..");

                        Console.ReadLine();

                        Console.Clear();

                        TemperatureExperiment.TemperatureExperimentMainMenu();
                    }


                // If temperature is equal to or above 50 degrees Fahrenheit it notifies user that water temperature is safe for feeding Koi fish

                else if (tExpTempInt >= 50)
                    {
                        Console.Clear();
                    
                        Console.WriteLine(" *********************** Temperature Experiment Data Entry ***********************");

                        Console.WriteLine("");

                        Console.WriteLine("  This temperature is SAFE to feed your Koi fish! Press ENTER to continue..");

                        Console.ReadLine();

                        Console.Clear();

                        TemperatureExperiment.TemperatureExperimentMainMenu();
                    }
                }


                // Initializes/creates an empty CSV data file

                else
                {
                        dateAndTempInit.Add("Date,Temperature (\x00B0F)");

                        File.AppendAllLines(Program._config["TempExpDataFile"], dateAndTempInit);

                        Console.Clear();

                        Console.WriteLine(" *********************** Temperature Experiment Data Entry ***********************");

                        Console.WriteLine("");

                        Console.WriteLine("  Initialized File. Please press ENTER to go back and re-enter data..");

                        Console.ReadLine();

                        TemperatureExperimentDataEntry();
                }            
        }


        //Temperature Experiment Data Search Section
        public static void TemperatureExperimentDataSearch()
        {
            string path = Program._config["TempExpDataFile"];


            // If statement checks if CSV data file exists. If it does exist, it then proceeds with searching the file 
            
            // If CSV file does not exist, it notifies user and gives direction to enter data

            if (File.Exists(path))
            {
                using (FileStream f = File.Open(Program._config["TempExpDataFile"], FileMode.Open, FileAccess.ReadWrite, FileShare.Inheritable)) 
                {
                    Console.Clear();

                    Console.WriteLine(" *********************** Temperature Experiment Data Search ***********************");

                    Console.WriteLine("");

                    Console.WriteLine("  Enter date that you would like to search: (Example: 06/01/2017)");

                    Console.WriteLine("");

                    string tExpCSV = Program._config["TempExpDataFile"];

                    string tExpDate = Console.ReadLine();

                    Console.Clear();

                    char csvSeparator = ',';


                    // 'While Loop' that searches TExpData.csv file for user input
                    
                    // this loop also has an additional feature which is to test if water temperature on searched date is safe for Koi fish feeding

                    using (var reader = new StreamReader(f))



                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();

                            foreach (string value in line.Replace("\"", "").Split('\r', '\n', csvSeparator))
                            {
                                if (value.Trim() == tExpDate.Trim() && (Int32.Parse(line.Split(',')[1]) < 50)) // case sensitive
                                {
                                    Console.Clear();

                                    Console.WriteLine(" *********************** Temperature Experiment Data Search ***********************");

                                    Console.WriteLine("");

                                    Console.WriteLine("  Temperature on " + value + " was " + line.Split(',')[1] + " \x00B0F.");

                                    Console.WriteLine("");

                                    Console.WriteLine("  This temperature is NOT SAFE to feed your Koi fish!");

                                    Console.WriteLine("");

                                    Console.WriteLine("  Press ENTER to go back..");

                                    Console.ReadLine();

                                    f.Close();

                                    Console.Clear();

                                    TemperatureExperimentMainMenu();

                                    break;
                                }

                                if (value.Trim() == tExpDate.Trim() && (Int32.Parse(line.Split(',')[1]) >= 50)) // case sensitive
                                {
                                    Console.Clear();

                                    Console.WriteLine(" *********************** Temperature Experiment Data Search ***********************");

                                    Console.WriteLine("");

                                    Console.WriteLine("  Temperature on " + value + " was " + line.Split(',')[1] + " \x00B0F.");

                                    Console.WriteLine("");

                                    Console.WriteLine("  This temperature is SAFE to feed your Koi fish!");

                                    Console.WriteLine("");

                                    Console.WriteLine("  Press ENTER to go back.");

                                    Console.ReadLine();

                                    f.Close();

                                    Console.Clear();

                                    TemperatureExperimentMainMenu();

                                    break;
                                }

                                else if (value.Trim() != tExpDate.Trim())
                                {
                                    break;
                                }
                            }
                        }


                    /** If user entry does not match with data entry in csv file, 'while loop' breaks and the console notifies
                    user that there is no temperature data for that date **/

                    Console.Clear();

                    Console.WriteLine(" *********************** Temperature Experiment Data Search ***********************");

                    Console.WriteLine("");

                    Console.WriteLine("  There is no temperature data for that date!");

                    Console.WriteLine("");

                    Console.WriteLine("");

                    Console.WriteLine("  Press ENTER to go back");

                    Console.ReadLine();

                    f.Close();

                    Console.Clear();

                    TemperatureExperimentMainMenu();
                }
            }


            // Notifies user that CSV data file does not exist and gives direction to enter data

            else
            {
                Console.Clear();

                Console.WriteLine(" *********************** Temperature Experiment Data Search ***********************");

                Console.WriteLine("");

                Console.WriteLine("  Temperature Experiment data file does not exist. ");

                Console.WriteLine("");

                Console.WriteLine("  You need to first enter data to create the data file. ");

                Console.WriteLine("");

                Console.WriteLine("  Press ENTER to go back..");

                Console.ReadLine();

                TemperatureExperimentMainMenu();

            }
        }

        // Delete ALL data section (It deletes CSV data file)
    public static void TemperatureExperimentDeleteALL()
        {
            Console.Clear();
            
            Console.WriteLine(" *********************** Delete ALL Temperature Experiment Data ***********************");
            
            Console.WriteLine("");
            
            Console.WriteLine("  Do you wish to delete ALL data? (Y/N)");
           
            string answer = Console.ReadLine();

            // Above section checks if user wants to delete all input data. If yes, CSV data file gets deleted

            string TExpDataFile = Path.GetFullPath(Program._config["TempExpDataFile"]);

            /** If statement first checks if CSV file is present. If it is, then it proceeds with the program.
            if CSV file is not present then it notifies user that CSV data file is missing  and cannot be deleted **/

            if (answer == "Y")
            {
                    if (File.Exists(Program._config["TempExpDataFile"]))
                    {
                        File.Delete(TExpDataFile);
                        
                        Console.WriteLine(TExpDataFile);
                        
                        Console.Clear();

                        Console.WriteLine(" *********************** Delete ALL Temperature Experiment Data ***********************");

                        Console.WriteLine("");

                        Console.WriteLine("  File was deleted. Press ENTER to go back to the main menu..");
                        
                        Console.ReadLine();
                        
                        Console.Clear();
                        
                        TemperatureExperimentMainMenu();
                    }

                    // Notifies user that data file is missing and cannot be deleted

                    else

                        Console.Clear();

                        Console.WriteLine(" *********************** Delete ALL Temperature Experiment Data ***********************");

                        Console.WriteLine("");

                        Console.WriteLine("  Temperature Experiment data file was not found.");
                        
                        Console.WriteLine("");
                        
                        Console.WriteLine("  Press ENTER to go back to the main menu..");
                        
                        Console.ReadLine();
                        
                        Console.Clear();
                        
                        TemperatureExperimentMainMenu();
            }

            else if (answer == "N")
            {
                Console.Clear();

                Console.WriteLine(" *********************** Delete ALL Temperature Experiment Data ***********************");

                Console.WriteLine("");

                Console.WriteLine("  Data file was NOT deleted. Please press ENTER to go back to the main menu..");
                
                Console.ReadLine();
                
                Console.Clear();
                
                TemperatureExperimentMainMenu();
            }
        }
    }
}