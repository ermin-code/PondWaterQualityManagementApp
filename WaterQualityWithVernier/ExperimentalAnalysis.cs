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
            
            Console.WriteLine("     Option 2. ");
            
            Console.WriteLine("     Option 3. ");
            
            Console.WriteLine("     Option 4. ");
            
            Console.WriteLine("     Option 5. ");
            
            Console.WriteLine("");
            
            Console.WriteLine("     Option 6. ");
            
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
 
                    break;

                case "3":

                    break;

                case "4":

                    break;

                case "5":

                    break;

                case "6":

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
            
            Console.WriteLine("     Option 1. Temperature Data Chart");
            
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

            Program.MainMenu();
        }
    } 
}






    









    






































  

























    


    

