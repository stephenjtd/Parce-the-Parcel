using System;

namespace TradeMeApp1
{
    /*We need you to implement a component that, when supplied the dimensions (length x breadth x height) and weight of a package, 
     * can advise on the cost and type of package required. 
     * If the package exceeds these dimensions - or is over 25kg - then the service should not return a packaging solution.*/

    class Parcel
    {
        private double weight;
        private double length;
        private double breadth;
        private double height;
        private String size;
        private double cost;

        public Parcel(double weight, double length, double breadth, double height)
        {
            this.weight = weight;
            this.length = length;
            this.breadth = breadth;
            this.height = height;
            setSize();
        }

        public void setSize()
        {
            if (weight > 25)
                size = "over limit";
            else
            {
                if ((length <= 200) || (breadth <= 300) || (height <= 150))
                    size = "small";
                if ((length > 200) || (breadth > 300) || (height > 150))
                    size = "medium";
                if ((length > 300) || (breadth > 400) || (height > 200))
                    size = "large";
                if ((length > 400) || (breadth > 600) || (height > 250))
                    size = "over limit";
            }

            setCost();
        }

        public void setCost()
        {
            if (size.Equals("small"))
                cost = 5.00;
            else if (size.Equals("medium"))
                cost = 7.50;
            else if (size.Equals("large"))
                cost = 8.50;

        }


        public String getSize()
        {
            return size;
        }

        public double getCost()
        {
            return cost;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Boolean keepGoing = true;
            Console.WriteLine("Parse the Parcel\n----------------");
            while (keepGoing)
            {
                Console.WriteLine("Calculate a parcel cost? y/n");
                String s = Console.ReadLine();
                if (s.Equals("y"))
                {
                    p.enterDetails();
                }
                else if (s.Equals("n"))
                {
                    Console.WriteLine("OK, program will now terminate");
                    break;
                }
                else
                    Console.WriteLine("Not a valid choice.  Try again.");
            }

        }

        void enterDetails()
        {
            Console.WriteLine("Enter weight in kg (max 25kg):");
            double weight = dataInput();
            Console.WriteLine("Enter length in mm (max 400mm):");
            double length = dataInput();
            Console.WriteLine("Enter breadth in mm (max 600mm):");
            double breadth = dataInput();
            Console.WriteLine("Enter height in mm (max 250mm):");
            double height = dataInput();

            Parcel par = new Parcel(weight, length, breadth, height);
            Console.WriteLine("Calculating size and cost...");
            String size = par.getSize();
            double cost = par.getCost();

            if(size.Equals("over limit"))
                Console.WriteLine("Package exceeds limits.  ");
            else
            {
                Console.WriteLine("Type of package: " + size);
                Console.WriteLine("Cost of package: $" + cost);
            }
        }

        double dataInput()
        {
            double value = 0;
            Boolean b = true;
            while (b)
            {
                if (double.TryParse(Console.ReadLine(), out value))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Not a valid entry.  Please enter a number.");
                }
            }
            return value;
        }
    }
}
