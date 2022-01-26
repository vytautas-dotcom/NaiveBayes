using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiveBayes
{
    class Show
    {
        public void ShowData(string[][] rawData, int numOfFirstRows, int numOfLastRows, bool indices)
        {
            for (int i = 0; i < numOfFirstRows; i++)
            {
                if (indices)
                    Console.Write("[" + i.ToString().PadLeft(2) + "] ");
                for (int j = 0; j < rawData[i].Length; j++)
                    Console.Write(rawData[i][j].PadLeft(14) + " ");
            Console.WriteLine();
            }
            if(numOfFirstRows < rawData.Length - 1)
                Console.WriteLine(". . .");
            for (int i = rawData.Length - numOfLastRows; i < rawData.Length; i++)
            {
                if (indices)
                    Console.Write("[" + i.ToString().PadLeft(2) + "] ");
                for (int j = 0; j < rawData[i].Length; j++)
                    Console.Write(rawData[i][j].PadLeft(14) + " ");
                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }
    }
}
