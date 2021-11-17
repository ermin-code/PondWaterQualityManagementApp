using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ConsoleTables;


namespace WaterQualityWithVernier
{
    class ExperimentalAnalysis
    {
        public static void ExperimentalAnalysisMainMenu()
        {
            Console.Clear();

            Console.WriteLine("");

            Console.WriteLine("*********************** Experimental Analysis ***********************");

            Console.WriteLine("");

            Console.WriteLine("     Option 1. Temperature Experiment Analysis");

            Console.WriteLine("     Option 2. pH Experiment Analysis");

            Console.WriteLine("     Option 3. Turbidity Experiment Analysis");

            Console.WriteLine("     Option 4. Dissolved Oxygen Experiment Analysis");

            Console.WriteLine("");

            Console.WriteLine("     Option 5. Exit to Main Menu");

            Console.WriteLine("");

            Console.WriteLine("     Please type which option you would like to choose:");

            string myOptions;

            myOptions = Console.ReadLine();

            switch (myOptions)
            {
                case "1":
                    TemperatureExperimentAnalysisMenu();
                    break;

                case "2":
                    pHExperimentAnalysisMenu();
                    break;

                case "3":
                    TurbidityExperimentAnalysisMenu();
                    break;

                case "4":
                    DissolvedOxygenExperimentAnalysisMenu();
                    break;

                case "5":
                    Program.MainMenu();

                    break;
            }

            Program.MainMenu();
        }

        static void TemperatureExperimentAnalysisMenu()
        {
            Console.Clear();

            Console.WriteLine("");

            Console.WriteLine("*********************** Temperature Experiment Analysis ***********************");

            Console.WriteLine("");

            Console.WriteLine("     Option 1. Temperature Data Table");

            Console.WriteLine("     Option 2. Exit to Main Menu");

            Console.WriteLine("");

            Console.WriteLine("     Please type which option you would like to choose:");

            string myOptions;

            myOptions = Console.ReadLine();

            switch (myOptions)
            {
                case "1":
                    TemperatureExperimentDataTable.TemperatureExperimentTable();
                    break;


                case "2":
                    Program.MainMenu();
                    break;
            }

        }
        static void pHExperimentAnalysisMenu()
        {
            Console.Clear();

            Console.WriteLine("");

            Console.WriteLine("*********************** pH Experiment Analysis ***********************");

            Console.WriteLine("");

            Console.WriteLine("     Option 1. pH Data Table");

            Console.WriteLine("     Option 2. Exit to Main Menu");

            Console.WriteLine("");

            Console.WriteLine("     Please type which option you would like to choose:");

            string myOptions;

            myOptions = Console.ReadLine();

            switch (myOptions)
            {
                case "1":
                    pHExperimentDataTable.pHExperimentTable();
                    break;

                case "2":
                    Program.MainMenu();
                    break;
            }

        }

        static void TurbidityExperimentAnalysisMenu()
        {
            Console.Clear();

            Console.WriteLine("");

            Console.WriteLine("*********************** Turbidity Experiment Analysis ***********************");

            Console.WriteLine("");

            Console.WriteLine("     Option 1. Turbidity Data Table");

            Console.WriteLine("     Option 2. Exit to Main Menu");

            Console.WriteLine("");

            Console.WriteLine("     Please type which option you would like to choose:");

            string myOptions;

            myOptions = Console.ReadLine();

            switch (myOptions)
            {
                case "1":
                    TurbidityExperimentDataTable.TurbidityExperimentTable();
                    break;


                case "2":
                    Program.MainMenu();
                    break;
            }

            Program.MainMenu();
        }


        static void DissolvedOxygenExperimentAnalysisMenu()
        {
            Console.Clear();

            Console.WriteLine("");

            Console.WriteLine("*********************** Dissolved Oxygen Experiment Analysis ***********************");

            Console.WriteLine("");

            Console.WriteLine("     Option 1. Dissolved Oxygen Data Table");

            Console.WriteLine("     Option 2. Exit to Main Menu");

            Console.WriteLine("");

            Console.WriteLine("     Please type which option you would like to choose:");

            string myOptions;

            myOptions = Console.ReadLine();

            switch (myOptions)
            {
                case "1":
                    DissolvedOxygenExperimentDataTable.DissolvedOxygenExperimentTable();
                    break;


                case "2":
                    Program.MainMenu();
                    break;
            }

            Program.MainMenu();
        }
    }
}







    









    






































  

























    


    

