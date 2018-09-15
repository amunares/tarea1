using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BigONotationPartial
{
    class Lineal
    {
        long[] fibonacciCache = null;

        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Lineal lineal = new Lineal();
            LinealExampleType linealExampleType = LinealExampleType.Fibonacci;
            int nFibonacciCache = 80; //8 40 80
            lineal.fibonacciCache = new long[nFibonacciCache + 1];
            switch (linealExampleType)
            {
                case LinealExampleType.Loop:
                    int n = 50;
                    lineal.Loop(n);
                    break;
                case LinealExampleType.ContainsNeedle:
                    List<int> numberList = new List<int>() { 10, 18, 29, 1, 0, 75, 79 };
                    int needle = 76;
                    bool found = lineal.ContainsNeedle(needle, numberList);
                    Console.WriteLine("Number {0} found? {1}", needle, found);
                    break;
                case LinealExampleType.Factorial:
                    int nFactorial = 10;
                    long factorial = lineal.Factorial(nFactorial);
                    Console.WriteLine("Factorial of {0} equal to {1}", nFactorial, factorial);
                    break;
                case LinealExampleType.Fibonacci:
                    int nFibonacci = 80; //8 40 80
                    for (int i = 1; i <= nFibonacci; i++)
                    {
                        long fibonacci = lineal.Fibonacci(i);
                        Console.WriteLine("fibonacci {0} = {1}", i, fibonacci);
                    }
                    break;
                case LinealExampleType.FibonacciCache:
                    for (int i = 1; i <= nFibonacciCache; i++)
                    {
                        long fibonacci = lineal.FibonacciCache(i);
                        Console.WriteLine("fibonacci {0} = {1}", i, fibonacci);
                    }
                    break;
            }
            Console.WriteLine("Time elapsed: {0:0.00} seconds", Math.Round(stopWatch.ElapsedMilliseconds / 1000.0, 2));
            Console.ReadLine();
        }

        /// Complexity: O(N)
        internal void Loop(long n)
        {
            var counter = 1;
            while (counter <= n)
            {
                Console.WriteLine(counter);
                counter++;
            }
        }

        /// Complexity: O(N)
        internal bool ContainsNeedle(int needle, List<int> numberList)
        {
            foreach (var item in numberList)
            {
                if (item == needle)
                {
                    return true;
                }
            }
            return false;
        }

        /// Complexity: O(N)
        internal long Factorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }

        /// Complexity: O(N)
        internal long Fibonacci(long n)
        {
            if (n < 0)
            {
                throw new Exception("n can not be less than zero");
            }
            if (n <= 2)
            {
                return 1;
            }
            long fibonacci = 0;
            long previous = 1;
            long penultimate = 0;
            for (int i = 1; i <= n; i++)
            {
                penultimate = fibonacci;
                fibonacci = previous + fibonacci;
                previous = penultimate;
            }
            return fibonacci;
        }

        /// Complexity: O(N)
        public long FibonacciCache(long n)
        {
            if (n < 0)
            {
                throw new Exception("n can not be less than zero");
            }
            if (n <= 2)
            {
                fibonacciCache[n] = 1;
            }
            if (fibonacciCache[n] == 0)
            {
                fibonacciCache[n] = FibonacciCache(n - 1) + FibonacciCache(n - 2);
            }
            return fibonacciCache[n];
        }

    }
}
