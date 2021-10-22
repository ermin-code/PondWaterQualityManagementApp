using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WaterQualityWithVernier
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World");
            //Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            MainMenu();
        }

        //Main Menu Section 
        static void MainMenu()
        {

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("*********************** Welcome to Pond Water Quality with Vernier V.1.0 ***********************");
            Console.WriteLine("");
            Console.WriteLine("     Option 1. Temperature Experiment (Stainless Steel Temperature Probe Required)");
            Console.WriteLine("     Option 2. pH Experiment (pH Sensor Required)");
            Console.WriteLine("     Option 3. Turbidity Experiment (Turbidity Sensor Required)");
            Console.WriteLine("     Option 4. Dissolved Oxygen Experiment (Dissolved Oxygen Sensor Required)");
            Console.WriteLine("     Option 5. Experimental Analysis");
            Console.WriteLine("");
            Console.WriteLine("     Option 6. Exit The Program");
            Console.WriteLine("");
            Console.WriteLine("     Please type which option you would like to choose:");

            string myoptions;
            myoptions = Console.ReadLine();
            switch (myoptions)
            {
                case "1":
                    TempExp();
                    break;

                case "2":
                    pHExp();
                    break;

                case "3":
                    TurbExp();
                    break;

                case "4":
                    DOExp();
                    break;

                case "5":
                    ExpAnalysis();
                    break;

                case "6":
                    Exit();
                    break;
            }

            MainMenu();
        }

        //Temperature Experiment Section
        public static void TempExp()
        {
            Console.Clear();
            Console.WriteLine("*********************** Temperature Experiment ***********************");
            Console.WriteLine("");
            Console.WriteLine(" In this experiment you will collect temperature data on your pond water using Vernier temperature probe, Texas Instruments Graphing Calculator with attached CBL2 Calculator-Based Laboratory.");
            Console.WriteLine(" Outdoor water temperatures can range from 32 degrees Celsius to above 86 degrees Celsius in the summer. In general, cooler water in pond is generally considered healthier than warmer water.");
            Console.WriteLine(" Pond water temperature plays a vital role in the overal health of the eco-system and the health of pond fish. The perfect pond water should be in the range of 68 to 74 degrees Fahrenheit.");
            Console.WriteLine(" During summer, water loses much of its ability to hold oxygen when the temperature is above 85 degrees. In winter, when the temperature goes below 39 degrees Fahrenheit fish do not have to eat.");
            Console.WriteLine("");
            Console.WriteLine(" This experiment will collect temperature data, store it in a database for later retreaval, and let you know if you should contine or stop feeding your fish based on last 7-day water temperature average.");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(" Please enter the date of the experiment (date/day/year format):");
            
            string TExpDate = Console.ReadLine();
         
            Console.Clear();

            Console.WriteLine(" Please enter temperature recorded (in degrees Fahrenheit):");

            string TExpTemp = Console.ReadLine();

            List<string> DateAndTemp = new List<string>();

            DateAndTemp.Add($"{TExpDate},{TExpTemp}");

            File.AppendAllLines("D:/My Documents/Code Louisville/september2021/WaterQualityWithVernier/WaterQualityWithVernier/Saved Data/TExpData.csv", DateAndTemp);

            MainMenu();
        }

  
        // pH Experiment Section
        static void pHExp()
        {
            Console.Clear();
            Console.WriteLine("This is pH Experiment!");
            Console.WriteLine("");
            Console.WriteLine("Press ENTER to go back to the Main Menu");
            Console.ReadLine();
        }

        // Turbidity Experiment Section
        static void TurbExp()
        {
            Console.Clear();
            Console.WriteLine("This is Turbidity Experiment!");
            Console.WriteLine("");
            Console.WriteLine("Press ENTER to go back to the Main Menu");
            Console.ReadLine();
        }

        // Dissolved Oxygen Section
        static void DOExp()
        {
            Console.Clear();
            Console.WriteLine("This is Dissolved Oxygen Experiment!");
            Console.WriteLine("");
            Console.WriteLine("Press ENTER to go back to the Main Menu");
            Console.ReadLine();
        }

        // Experimental Analysis Section
        static void ExpAnalysis()
        {
            Console.Clear();
            Console.WriteLine("This is Experimental Analysis!");
            Console.WriteLine("");
            Console.WriteLine("Press ENTER to go back to the Main Menu");
            Console.ReadLine();
        }

        // Exit Program Section
        static void Exit()
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
