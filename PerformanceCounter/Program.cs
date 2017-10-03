using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {

            string categoryName = "Football";

            if (!PerformanceCounterCategory.Exists(categoryName))
            {
                string firstCounterName = "Goals scored";
                string firstCounterHelp = "Goals scored live update";
                string categoryHelp = "Football related real time statistics";

                PerformanceCounterCategory customCategory = new PerformanceCounterCategory(categoryName);
                CounterCreationData counterCreationData = new CounterCreationData(firstCounterName, firstCounterHelp, PerformanceCounterType.NumberOfItems32);
                CounterCreationDataCollection collection = new CounterCreationDataCollection();
                collection.Add(counterCreationData);
                PerformanceCounterCategory.Create(categoryName, categoryHelp, collection);
            }

            //string categoryName = "Football";
            string counterName = "Goals scored";
            PerformanceCounter footballScoreCounter = new PerformanceCounter(categoryName, counterName);
            footballScoreCounter.ReadOnly = false;
            while (true)
            {
                footballScoreCounter.Increment();
                Thread.Sleep(1000);
                Random random = new Random();
                int goals = random.Next(-5, 6);
                footballScoreCounter.IncrementBy(goals);
                Thread.Sleep(1000);
            }


            Console.ReadLine();
        }
    }
}
