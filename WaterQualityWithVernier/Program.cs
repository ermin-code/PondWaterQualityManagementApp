using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using CsvReader;
using Microsoft.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;


namespace WaterQualityWithVernier
{
    class Program
    {

        public static IConfigurationRoot _config;

        static void Main(string[] args)
        {

            // Initializing AppSettings.json to target a specific file path
           
            _config = new ConfigurationBuilder()
                
                .SetBasePath(Directory.GetCurrentDirectory())
                
                .AddJsonFile("D:/My Documents/Code Louisville/september2021/WaterQualityWithVernier/WaterQualityWithVernier/AppSettings.json")
                
                .Build();
            

            // Changes font color in the console to green

            Console.ForegroundColor = ConsoleColor.Green;
            
            MainMenu();
        }


        //Main Menu Section 
        public static void MainMenu()
        {
            Console.Clear();
            
            Console.WriteLine("");
            
            Console.WriteLine("*********************** Welcome to Pond Water Quality Testing ***********************");
            
            Console.WriteLine("");
            
            Console.WriteLine("     Option 1. Temperature Experiment");
            
            Console.WriteLine("     Option 2. pH Experiment");
            
            Console.WriteLine("     Option 3. Turbidity Experiment");
            
            Console.WriteLine("     Option 4. Dissolved Oxygen Experiment");
            
            Console.WriteLine("     Option 5. Experimental Analysis");
            
            Console.WriteLine("");
            
            Console.WriteLine("     Option 6. Exit The Program");
            
            Console.WriteLine("");
            
            Console.WriteLine("     Please type in which option you would like to choose:");

            string myOptions;
            
            myOptions = Console.ReadLine();
            
            switch (myOptions)
            {
                case "1":
                     TemperatureExperiment.TemperatureExperimentMainMenu();
                    break;

                case "2":
                    pHExperiment.pHExperimentMainMenu();
                    break;

                case "3":
                    TurbidityExperiment.TurbidityExperimentMainMenu();
                    break;

                case "4":
                    DissolvedOxygenExperiment.DissolvedOxygenExperimentMainMenu();
                    break;

                case "5":
                    ExperimentalAnalysis.ExperimentalAnalysisMainMenu();
                    break;

                case "6":
                    ExitProgram();
                    break;
            }

            MainMenu();
        }


        // Exit Program Section
        static void ExitProgram()
        {
            Console.Clear();
            
            Console.WriteLine("Are you sure you would like to exit the program?");
            
            Console.WriteLine("");
            
            Console.WriteLine("Press ENTER on the Keyboard to Confirm!");
            
            Console.ReadLine();
            
            System.Environment.Exit(1);
        }
    }
}
