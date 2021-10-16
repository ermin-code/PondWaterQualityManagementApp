using System;

namespace WaterQualityWithVernier
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World");
            //Console.ReadLine();
            MainMenu();
        }

        //Main Menu Section 
        static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("*********************** Welcome to Water Quality with Vernier V.1.0 *********************** ");
            Console.WriteLine("");
            Console.WriteLine("Option 1. Temperature Experiment (Stainless Steel Temperature Probe Required)");
            Console.WriteLine("Option 2. pH Experiment (pH Sensor Required)");
            Console.WriteLine("Option 3. Turbidity Experiment (Turbidity Sensor Required)");
            Console.WriteLine("Option 4. Dissolved Oxygen Experiment (Dissolved Oxygen Sensor Required)");
            Console.WriteLine("Option 5. Experimental Analysis");
            Console.WriteLine("");
            Console.WriteLine("Option 6. Exit The Program");
            Console.WriteLine("");
            Console.WriteLine("Please type which option you would like to choose:");


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
        static void TempExp()
        {
            Console.Clear();
            Console.WriteLine("This is Temperature Experiment!");
            Console.WriteLine("");
            Console.WriteLine("Press ENTER to go back to the Main Menu");
            Console.ReadLine();
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
