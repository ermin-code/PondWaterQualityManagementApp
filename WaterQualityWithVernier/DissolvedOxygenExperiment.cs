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
        // Dissolved Oxygen Experiment Menu
        public static void DissolvedOxygenExperimentMainMenu()
        {
            Console.Clear();

            Console.WriteLine(" *********************** Dissolved Oxygen Experiment ***********************");

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


        // Dissolved Oxygen Data Entry Section
        public static void DissolvedOxygenExperimentDataEntry()
        {
            Console.Clear();

            Console.WriteLine(" *********************** Dissolved Oxygen Experiment Data Entry ***********************");

            Console.WriteLine("");

            Console.WriteLine("  A lack of dissolved oxygen is the most common reason why pond fish die. Sometimes this ");

            Console.WriteLine("  occurs when aquatic plants and algea die in the summer or when aquatic herbacides are ");

            Console.WriteLine("  used to kill unwanted vegetation in the pond. Herbacides work by reducing dissolved ");

            Console.WriteLine("  oxygen in order to suffocate string alge and therefore reduce their growth.");

            Console.WriteLine("");

            Console.WriteLine("  If not careful, too much herbacide can lower dissolved oxygen below 5 mg/L making it ");

            Console.WriteLine("  unsafe for Koi fish. If dissolved oxygen concentration goes below 2 mg/L, you will");          
            
            Console.WriteLine("  notice fish swimming up to water surface trying to breath. This is very dangerous ");

            Console.WriteLine("  and supplemental aeration must be used immediately to increase dissolved oxygen, ");

            Console.WriteLine("  otherwise your fish will die soon. As you can see, measuring and monitoring  ");

            Console.WriteLine("  dissolved oxygen concentrations in Koi pond is essential.");

            Console.WriteLine("");

            Console.WriteLine("  In this experiment you will collect dissolved oxygen concentration data on your ");

            Console.WriteLine("  pond water using Vernier DO probe, Texas Instruments Graphing Calculator with ");

            Console.WriteLine("  attached CBL2 Calculator-Based Laboratory.");

            Console.WriteLine("");

            Console.WriteLine("");

            Console.WriteLine("  Please enter date of experiment (Example: 06/01/2017):");

            Console.WriteLine("");

            string dOExpDate = Console.ReadLine();

            Console.Clear();

            Console.WriteLine(" *********************** Dissolved Oxygen Experiment Data Entry ***********************");

            Console.WriteLine("");

            Console.WriteLine("  Please enter dissolved oxygen observed (in mg/L):");

            Console.WriteLine("");

            string dOExpDO = Console.ReadLine();

            Console.Clear();

            List<string> dateAndDO = new List<string>();

            List<string> dateAndDOInit = new List<string>();

            string path = Path.GetFullPath(Program._config["DOExpDataFile"]);


            /** If statement checks if CSV data file is present. If it is present, the program continues..
            If CSV data file is not present, it initializes or creates an emptu CSV data file **/

            if (File.Exists(path))
            {
                dateAndDO.Add($"{dOExpDate},{dOExpDO}");

                // Stores date and dissolved oxygen data in CSV file following [date, dissolved oxygen] format
                
                File.AppendAllLines(Program._config["DOExpDataFile"], dateAndDO);

                int dOExpDOInt = Int32.Parse(dOExpDO);


                // If dissolved oxygen in water is in between 2 and 5 mg/L it notifies user that dissolved oxygen concentration is too low for Koi fish

                if (dOExpDOInt < 5 && dOExpDOInt > 2)
                {
                    Console.Clear();
                    
                    Console.WriteLine(" *********************** Dissolved Oxygen Experiment Data Entry ***********************");

                    Console.WriteLine("");

                    Console.WriteLine("  This level of dissolved oxygen is LOW for your Koi fish! ");

                    Console.WriteLine("");
                        
                    Console.WriteLine("Press ENTER to go back..");

                    Console.ReadLine();

                    Console.Clear();

                    DissolvedOxygenExperiment.DissolvedOxygenExperimentMainMenu();
                }


                // If dissolved oxygen in water is less than or equal to 2 mg/L it notifies user that dissolved oxygen concentration is extremely low and to take action

                if (dOExpDOInt <= 2)
                {
                    Console.Clear();

                    Console.WriteLine(" *********************** Dissolved Oxygen Experiment Data Entry ***********************");

                    Console.WriteLine("");

                    Console.WriteLine("  This level of dissolved oxygen is DANGEROUSLY LOW for your Koi fish! Please supply emergency aeration immediately! ");

                    Console.WriteLine("");

                    Console.WriteLine("  Press ENTER to go back..");

                    Console.ReadLine();

                    Console.Clear();

                    DissolvedOxygenExperiment.DissolvedOxygenExperimentMainMenu();
                }


                // If dissolved oxygen in water is greater or equal to 5 mg/L it notifies user that dissolved oxygen cooncentration is adequate for Koi fish

                if (dOExpDOInt >= 5) 
                {
                    Console.Clear();

                    Console.WriteLine(" *********************** Dissolved Oxygen Experiment Data Entry ***********************");

                    Console.WriteLine("");

                    Console.WriteLine("  This level of dissolved oxygen is ADEQUATE for your Koi fish! ");

                    Console.WriteLine("");

                    Console.WriteLine("  Press ENTER to go back..");

                    Console.ReadLine();

                    Console.Clear();

                    DissolvedOxygenExperiment.DissolvedOxygenExperimentMainMenu();
                }
            }


            // Initializes/creates an empty CSV data file

            else
            {
                dateAndDOInit.Add("Date,Dissolved Oxygen (mg/L)");

                File.AppendAllLines(Program._config["DOExpDataFile"], dateAndDOInit);

                Console.Clear();

                Console.WriteLine(" *********************** Dissolved Oxygen Experiment Data Entry ***********************");

                Console.WriteLine("");

                Console.WriteLine("  Initialized File. Please press ENTER to go back and re-enter data..");

                Console.ReadLine();

                DissolvedOxygenExperimentDataEntry();
            }
        }


        //Dissolved Oxygen Experiment Data Search Section
        public static void DissolvedOxygenExperimentDataSearch()
        {
            string path = Program._config["DOExpDataFile"];


            // If statement checks if CSV data file exists. If it does exist, it then proceeds with searching the file

            // If CSV file does not exist, it notifies user and gives direction to enter data

            if (File.Exists(path))
            {

                using (FileStream f = File.Open(Program._config["DOExpDataFile"], FileMode.Open, FileAccess.ReadWrite, FileShare.Inheritable)) 
                {
                    Console.Clear();

                    Console.WriteLine(" *********************** Dissolved Oxygen Experiment Data Search ***********************");

                    Console.WriteLine("");

                    Console.WriteLine("  Enter date that you would like to search: (Example: 06/01/2017)");

                    Console.WriteLine("");

                    string dOExpCSV = Program._config["DOExpDataFile"];

                    string dOExpDate = Console.ReadLine();

                    Console.Clear();

                    char csvSeparator = ',';


                    // 'While loop' that searches DOExpData.csv file for user input

                    // This loop also has an additional feature which is to test if water dissolved oxygen on searched date is safe for Koi fish

                    using (var reader = new StreamReader(f))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();

                            foreach (string value in line.Replace("\"", "").Split('\r', '\n', csvSeparator))
                            {
                                if (value.Trim() == dOExpDate.Trim() && (Int32.Parse(line.Split(',')[1]) < 5) && (Int32.Parse(line.Split(',')[1]) > 2)) // case sensitive
                                {
                                    Console.Clear();

                                    Console.WriteLine(" *********************** Dissolved Oxygen Experiment Data Search ***********************");

                                    Console.WriteLine("");

                                    Console.WriteLine("  Dissolved oxygen on " + value + " was " + line.Split(',')[1] + " mg/L.");

                                    Console.WriteLine("");

                                    Console.WriteLine("  This level of dissolved oxygen is LOW for your Koi fish!");

                                    Console.WriteLine("");

                                    Console.WriteLine("  Press ENTER to go back..");

                                    Console.ReadLine();

                                    f.Close();

                                    Console.Clear();

                                    DissolvedOxygenExperimentMainMenu();

                                    break;
                                }

                                if (value.Trim() == dOExpDate.Trim() && (Int32.Parse(line.Split(',')[1]) <= 2)) // case sensitive
                                {
                                    Console.Clear();

                                    Console.WriteLine(" *********************** Dissolved Oxygen Experiment Data Search ***********************");

                                    Console.WriteLine("");

                                    Console.WriteLine("  Dissolved oxygen on " + value + " was " + line.Split(',')[1] + " mg/L.");

                                    Console.WriteLine("");

                                    Console.WriteLine("  This level of dissolved oxygen is DANGEROUSLY LOW for your Koi fish!");

                                    Console.WriteLine("");

                                    Console.WriteLine("  Press ENTER to go back.");

                                    Console.ReadLine();

                                    f.Close();

                                    Console.Clear();

                                    DissolvedOxygenExperimentMainMenu();

                                    break;
                                }

                                if (value.Trim() == dOExpDate.Trim() && (Int32.Parse(line.Split(',')[1]) >= 5)) // case sensitive
                                {
                                    Console.Clear();

                                    Console.WriteLine(" *********************** Dissolved Oxygen Experiment Data Search ***********************");

                                    Console.WriteLine("");

                                    Console.WriteLine("  Dissolved oxygen on " + value + " was " + line.Split(',')[1] + " mg/L.");

                                    Console.WriteLine("");

                                    Console.WriteLine("  This level of dissolved oxygen is ADEQUATE for your Koi fish!");

                                    Console.WriteLine("");

                                    Console.WriteLine("  Press ENTER to go back.");

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

                    Console.WriteLine(" *********************** Dissolved Oxygen Experiment Data Search ***********************");

                    Console.WriteLine("");

                    Console.WriteLine("  There is no dissolved oxygen data for that date!");

                    Console.WriteLine("");

                    Console.WriteLine("");

                    Console.WriteLine("  Press ENTER to go back");

                    Console.ReadLine();

                    f.Close();

                    Console.Clear();

                    DissolvedOxygenExperimentMainMenu();
                }
            }
            

            // Notifies user that CSV data file does not exist and gives direction to enter data

            else
            {
                Console.Clear();

                Console.WriteLine(" *********************** Dissolved Oxygen Experiment Data Search ***********************");

                Console.WriteLine("");

                Console.WriteLine("  Dissolved Oxygen Experiment data file does not exist. ");

                Console.WriteLine("");

                Console.WriteLine("  You need to first enter data to create the data file. ");

                Console.WriteLine("");

                Console.WriteLine("  Press ENTER to go back..");

                Console.ReadLine();

                DissolvedOxygenExperimentMainMenu();

            }
        }


        // Delete ALL data section (It deletes CSV data file)

        public static void DissolvedOxygenExperimentDeleteALL()
        {
            Console.Clear();

            Console.WriteLine(" *********************** Delete ALL Dissolved Oxygen Experiment Data ***********************");

            Console.WriteLine("");

            Console.WriteLine("  Do you wish to delete ALL data? (Y/N)");

            string answer = Console.ReadLine();

            // Above section checks if user wants to delete all input data. If yes, CSV data file gets deleted

            string dOExpDataFile = Path.GetFullPath(Program._config["DOExpDataFile"]);

            /** If statement first checks if CSV file is present. If it is, then it proceeds with the program.
             if CSV file is not present then it notifies user that CSV data file is missing and cannot be deleted **/

            if (answer == "Y")
            {
                if (File.Exists(Program._config["DOExpDataFile"]))
                {
                    File.Delete(dOExpDataFile);

                    Console.WriteLine(dOExpDataFile);

                    Console.Clear();

                    Console.WriteLine(" *********************** Delete ALL Dissolved Oxygen Experiment Data ***********************");

                    Console.WriteLine("");

                    Console.WriteLine("  File was deleted. Press ENTER to go back to the main menu..");

                    Console.ReadLine();

                    Console.Clear();

                    DissolvedOxygenExperimentMainMenu();
                }


                // Notifies user that data file is missing and cannot be deleted

                else

                    Console.Clear();

                    Console.WriteLine(" *********************** Delete ALL Dissolved Oxygen Experiment Data ***********************");

                    Console.WriteLine("");

                    Console.WriteLine("  Dissolved Oxygen Experiment data file was not found.");

                    Console.WriteLine("");

                    Console.WriteLine("  Press ENTER to go back to the main menu..");

                    Console.ReadLine();

                    Console.Clear();

                    DissolvedOxygenExperimentMainMenu();
            }

            else if (answer == "N")
            {
                Console.Clear();

                Console.WriteLine(" *********************** Delete ALL Dissolved Oxygen Experiment Data ***********************");

                Console.WriteLine("");

                Console.WriteLine("  Data file was NOT deleted. Please press ENTER to go back to the main menu..");

                Console.ReadLine();

                Console.Clear();

                DissolvedOxygenExperimentMainMenu();
            }
        }
    }
}