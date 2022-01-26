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
            if(numOfFirstRows + numOfLastRows < rawData.Length)
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

        public void SplitData(string[][] rawData, int seed, out string[][] trainData, out string[][] testData)
        {
            Random rand = new Random(seed);
            int totalRows = rawData.Length;
            int trainRows = (int)(totalRows * 0.80);
            int testRows = totalRows - trainRows;

            trainData = new string[trainRows][];
            testData = new string[testRows][];

            string[][] copy = new string[rawData.Length][];

            for (int i = 0; i < copy.Length; i++)
                copy[i] = rawData[i];

            for (int i = 0; i < copy.Length; i++)
            {
                int r = rand.Next(i, copy.Length);
                string[] tmp = copy[r];
                copy[r] = copy[i];
                copy[i] = tmp;
            }

            for (int i = 0; i < trainRows; i++)
                trainData[i] = copy[i];
            for (int i = 0; i < testRows; i++)
                testData[i] = copy[i + trainRows];
        }
    }
}
