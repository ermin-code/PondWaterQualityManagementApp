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
    class ExpAnalysis
    {
        public static void ExpAnalysisApp()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("*********************** Experimental Analysis ***********************");
            Console.WriteLine("");
            Console.WriteLine("     Option 1. Temperature Experiment");
            Console.WriteLine("     Option 2. ");
            Console.WriteLine("     Option 3. ");
            Console.WriteLine("     Option 4. ");
            Console.WriteLine("     Option 5. ");
            Console.WriteLine("");
            Console.WriteLine("     Option 6. ");
            Console.WriteLine("");
            Console.WriteLine("     Please type which option you would like to choose:");

            string myoptions;
            myoptions = Console.ReadLine();
            switch (myoptions)
            {
                case "1":
                    TExpAnalysis();
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

        static void TExpAnalysis()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("*********************** Temperature Experiment Analysis ***********************");
            Console.WriteLine("");
            Console.WriteLine("     Option 1. Temperature Data Chart");
            Console.WriteLine("     Option 2. Exit to Main Menu");
            Console.WriteLine("");
            Console.WriteLine("     Please type which option you would like to choose:");

            string myoptions;
            myoptions = Console.ReadLine();
            switch (myoptions)
            {
                case "1":
                    TempExpDataChart.TExpDataChart();
                    break;


                case "2":
                    Program.MainMenu();
                    break;
            }

            Program.MainMenu();


        }
        } 

    }






    









    






































  

























    


    

