using System;
/*
 * Author: Ozan Özbirecikli
 */
namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            printAsc();

            printDesc();

            Console.WriteLine("Sum of N numbers: " + Sum(100));
            Console.WriteLine("Sum of N numbers with A method: " + Sum_A(100));
            Console.WriteLine("Sum of N numbers with B method: " + Sum_B(100));

        }

        public static void printAsc()
        {
            Console.WriteLine("++ Printing in Ascending Order ++ ");
            for (int i = 1; i<101; ++i)
            {
                Console.Write(i + " ");

            }
            Console.WriteLine();
        }
        public static void printDesc()
        {
            Console.WriteLine("-- Printing in Descending Order -- ");
            for (int i = 100; i > 0; --i)
            {
                Console.Write(i + " ");

            }
            Console.WriteLine();
        }

        public static int Sum(int n)
        {
            if (n != 0)
            {
                return n + Sum(n - 1);
            }
            else
            {
                return 0;
            }
        }

        public static int Sum_A(int n)
        {
            return (n * (n + 1)) / 2;

        }
        public static int Sum_B(int n)
        {
            int sum = 0;
            while(n != 0)
            {
                sum += n;
                n--;
            }
            return sum;
        }


    }
}
