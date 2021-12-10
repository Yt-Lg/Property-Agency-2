using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property_Agency
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creates list for the 4 variables: Name, ID, Sales and commission
            List<Compiling> List_Of_Compiled_Items = new List<Compiling>();

            // try loop to make sure that invalid inputs won't crash the program.
            try
            {
                // User input to get the number of employees that they will have to input information and calculate for.
                Console.WriteLine("How many employees?");
                int Employee_Amount = Convert.ToInt32(Console.ReadLine());

                // for loop that loops as many times as the user inputted the amount of employees, this is so it will loop exactly enough times
                // to input the employee data of the number of employees specified by the user.
                for (int i = 0; i < Employee_Amount; i++)
                {
                    //another try loop to prevent program crashing.
                    try
                    {
                        // lets the user input name, ID, and property sold.
                        Console.WriteLine("Enter Employee Name");
                        string Employee_Name = Console.ReadLine();
                        Console.WriteLine("Enter Employee ID");
                        int Employee_ID_Number = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Properties Sold By: " + Employee_Name);
                        int Employee_Sales = Convert.ToInt32(Console.ReadLine());

                        // calculates the employee's commission by doing that employee's sales * 500
                        double Employee_Commission = 500 * Employee_Sales;


                        // { Compiled_Sales = Employee_sales , etc} didn't work so replaced with this to make it work.
                        // forgot to add List_Of_Compiled_Items.add so it didn't work

                        // adds all the inputs and calculations made above into the list.
                        List_Of_Compiled_Items.Add(new Compiling(Employee_ID_Number, Employee_Name, Employee_Sales, Employee_Commission));
                    }
                    // Writes this line when user inputs something invalid
                    catch
                    {
                        Console.WriteLine("invalid input");                       
                    }
                }
            }
            // writes this line when user inputs an invalid input.
            catch
            {
                Console.WriteLine("Invalid Input");
            }
            // Creates a second list where the employees are sorted by sales number, THEN ID number
            List<Compiling> Sorted_Employees = List_Of_Compiled_Items.OrderByDescending(i => i.Compiled_Sales).ThenBy(x => x.Compiled_ID).ToList();
            
            //Creates a list to transfer the sales and commissions in the sorted employees list to.
            List<double> Total_Commission_List = new List<double>();
            List<double> Total_Sales_List = new List<double>();

            // creates a counter
            int counter = 0;
            // will loop as many times as there are items in the list.
            foreach (Compiling i in Sorted_Employees)
            {
                // adds 1 to the counter
                counter++;
                // if the counter is 1, changes the compiled commissions it is currently on to 1.15* of itself
                if (counter == 1)
                {
                    // creates a temp variable for compiledcommissions*1.15 to be in
                    double temp = i.Compiled_Commissions * 1.15;
                    // moves the temp variable back into i.compiled_Commissions after the calculation.
                    i.Compiled_Commissions = temp;
                }
                // Prints out the ID, Name, Sales and Total commissions of each employee
                Console.WriteLine("ID:" +  i.Compiled_ID + " || " + "Name: " + i.Compiled_Name + " || Sales: " + i.Compiled_Sales + "|| Total Comission: " + i.Compiled_Commissions);
                
               // adds the current commissions and sales the iteration is on to the seperate list.
                Total_Commission_List.Add(i.Compiled_Commissions);
                Total_Sales_List.Add(i.Compiled_Sales);
            }
            // was put above the counter loop so it didn't add the bonus at the end calculation display so isntead of 1750 it would display 1500

            // adds up all the sales and commisions in the list and moves it to the variables, total_sales and total_commissions.
            double Total_Sales = Total_Sales_List.Sum();
            double Total_Commission = Total_Commission_List.Sum();

            // prints out the total commisions the company has to pay and the total amount of sales the company has made.
            Console.WriteLine("Total Sales By Company: " + Total_Sales);
            Console.WriteLine("Total Payout: " + Total_Commission);
            Console.ReadKey();

        }


            class Compiling
        {
            public int Compiled_ID { get; set;}
            public string Compiled_Name { get; set;}
            public double Compiled_Sales { get; set;}
            public double Compiled_Commissions { get; set;}
            //added this so it works on Main
            public Compiling(int id, string name, double sales, double commission)
            {
                Compiled_ID = id;
                Compiled_Name = name;
                Compiled_Sales = sales;
                Compiled_Commissions = commission;
            }
        }
    }
}
