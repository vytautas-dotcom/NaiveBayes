using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiveBayes
{
    class BayesClassifier
    {
        private Dictionary<string, int>[] stringToInt;
        private int[][][] jointCounts;
        private int[] dependentCounts;
        private string[][] trainData;
        public BayesClassifier(string[][] data)
        {
            trainData = data;
        }
        public void Train()
        {
            int rows = trainData.Length;
            int cols = trainData[0].Length;
            stringToInt = new Dictionary<string, int>[cols];

            for (int i = 0; i < cols; i++)
            {
                stringToInt[i] = new Dictionary<string, int>();

                int index = 0;
                for (int j = 0; j < rows; j++) //one dictionary per column
                {
                    string s = trainData[j][i];
                    if (stringToInt[i].ContainsKey(s) == false)
                    {
                        stringToInt[i].Add(s, index);
                        index++;
                    }
                }
            }
            //------
            jointCounts = new int[cols - 1][][];

            for (int i = 0; i < cols - 1; i++)
            {
                int count = stringToInt[i].Count;
                jointCounts[i] = new int[count][];
            }

            for (int i = 0; i < jointCounts.Length; i++)
                for (int j = 0; j < jointCounts[i].Length; j++)
                    jointCounts[i][j] = new int[stringToInt[cols - 1].Count];

            for (int i = 0; i < jointCounts.Length; i++) //Laplacian smoothing
                for (int j = 0; j < jointCounts[i].Length; j++)
                    for (int k = 0; k < jointCounts[i][j].Length; k++)
                        jointCounts[i][j][k] = 1;

            for (int i = 0; i < rows; i++) //count(j/s/i|conservative) & count(j/s/i|liberal)
            {
                string y = trainData[i][cols - 1];
                int yIndex = stringToInt[cols - 1][y];
                for (int j = 0; j < cols - 1; j++)
                {
                    int rowIndex = j;
                    string x = trainData[i][j];
                    int xIndex = stringToInt[j][x];
                    ++jointCounts[rowIndex][xIndex][yIndex];
                }
            }
            //------
            dependentCounts = new int[stringToInt[cols - 1].Count];

            for (int i = 0; i < dependentCounts.Length; i++) //Laplacian smoothing
                dependentCounts[i] = cols - 1;

            for (int i = 0; i < trainData.Length; i++)
            {
                string y = trainData[i][cols - 1];
                int yIndex = stringToInt[cols - 1][y];
                ++dependentCounts[yIndex];
            }
        }

        public double Probability(string[] xVal, string yVal)
        {
            int numOfFeatures = xVal.Length;
            int numOfDifUnconditionals = stringToInt[trainData[0].Length - 1].Count;

            double[][] conditionals = new double[numOfDifUnconditionals][];

            for (int i = 0; i < conditionals.Length; i++)
                conditionals[i] = new double[numOfFeatures];

            double[] unconditionals = new double[numOfDifUnconditionals];

            int y = stringToInt[numOfFeatures][yVal];
            int[] x = new int[numOfFeatures];

            for (int i = 0; i < numOfFeatures; i++)
            {
                string s = xVal[i];
                x[i] = stringToInt[i][s];
            }

            for (int i = 0; i < numOfDifUnconditionals; i++)
            {
                for (int j = 0; j < numOfFeatures; j++)
                {
                    int xCol = j;
                    int xRow = x[j];
                    int yIndex = i;

                    conditionals[i][j] = (jointCounts[xCol][xRow][yIndex] * 1.0) / (dependentCounts[yIndex]);
                }
            }

            int totalDependent = 0;
            for (int i = 0; i < numOfDifUnconditionals; i++)
                totalDependent += dependentCounts[i];

            for (int i = 0; i < numOfDifUnconditionals; i++)
                unconditionals[i] = (dependentCounts[i] * 1.0) / totalDependent;

            double[] partials = new double[2];

            for (int i = 0; i < numOfDifUnconditionals; i++)
            {
                partials[i] = 1.0;
                for (int j = 0; j < numOfFeatures; j++)
                    partials[i] *= conditionals[i][j];
                partials[i] *= unconditionals[i];
            }

            double evidence = 0.0;
            for (int i = 0; i < numOfDifUnconditionals; i++)
                evidence += partials[i];

            return partials[y] / evidence;
        }
    }
}
