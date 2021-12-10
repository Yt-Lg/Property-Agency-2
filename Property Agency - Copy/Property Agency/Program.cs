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
            List<Compiling> List_Of_Compiled_Items = new List<Compiling>();

            try
            {
                Console.WriteLine("How many employees?");
                int Employee_Amount = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < Employee_Amount; i++)
                {
                    try
                    {
                        Console.WriteLine("Enter Employee Name");
                        string Employee_Name = Console.ReadLine();
                        Console.WriteLine("Enter Employee ID");
                        int Employee_ID_Number = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Properties Sold By: " + Employee_Name);
                        int Employee_Sales = Convert.ToInt32(Console.ReadLine());
                        double Employee_Commission = 500 * Employee_Sales;

                        List_Of_Compiled_Items.Add(new Compiling(Employee_ID_Number, Employee_Name, Employee_Sales, Employee_Commission));
                    }
                    catch
                    {
                        Console.WriteLine("invalid input");
                    }
                }
            }

            catch
            {
                Console.WriteLine("Invalid Input");
            }

            List<Compiling> Sorted_Employees = List_Of_Compiled_Items.OrderByDescending(i => i.Compiled_Sales).ThenBy(x => x.Compiled_ID).ToList();
            List<double> Total_Commission_List = new List<double>();
            List<double> Total_Sales_List = new List<double>();

            foreach (Compiling i in Sorted_Employees)
            {
                counter = ++1;
                Total_Commission_List.Add(i.Compiled_Commissions);
                Total_Sales_List.Add(i.Compiled_Sales);

                
                Console.WriteLine("ID:" +  i.Compiled_ID + " || " + "Name: " + i.Compiled_Name + " || Sales: " + i.Compiled_Sales + "|| Total Comission: " + i.Compiled_Commissions);
            }



            double Total_Sales = Total_Sales_List.Sum();
            double Total_Commission = Total_Commission_List.Sum();

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
