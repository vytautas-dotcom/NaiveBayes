using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiveBayes
{
    class Data
    {
        string[][] rawData = new string[30][];
        public Data()
        {
            rawData[0] = new string[] { "analyst", "male", "high", "conservative" };
            rawData[1] = new string[] { "barista", "female", "low", "liberal" };
            rawData[2] = new string[] { "cook", "male", "medium", "conservative" };
            rawData[3] = new string[] { "doctor", "female", "medium", "conservative" };
            rawData[4] = new string[] { "analyst", "female", "low", "liberal" };
            rawData[5] = new string[] { "doctor", "male", "medium", "conservative" };
            rawData[6] = new string[] { "analyst", "male", "medium", "conservative" };
            rawData[7] = new string[] { "cook", "female", "low", "liberal" };
            rawData[8] = new string[] { "doctor", "female", "medium", "liberal" };
            rawData[9] = new string[] { "cook", "female", "low", "liberal" };
            rawData[10] = new string[] { "doctor", "male", "medium", "conservative" };
            rawData[11] = new string[] { "cook", "female", "high", "liberal" };
            rawData[12] = new string[] { "barista", "female", "medium", "liberal" };
            rawData[13] = new string[] { "analyst", "male", "low", "liberal" };
            rawData[14] = new string[] { "doctor", "female", "high", "conservative" };
            rawData[15] = new string[] { "barista", "female", "medium", "conservative" };
            rawData[16] = new string[] { "doctor", "male", "medium", "conservative" };
            rawData[17] = new string[] { "barista", "male", "high", "conservative" };
            rawData[18] = new string[] { "doctor", "female", "medium", "liberal" };
            rawData[19] = new string[] { "analyst", "male", "low", "liberal" };
            rawData[20] = new string[] { "doctor", "male", "medium", "conservative" };
            rawData[21] = new string[] { "cook", "male", "medium", "conservative" };
            rawData[22] = new string[] { "doctor", "female", "high", "conservative" };
            rawData[23] = new string[] { "analyst", "male", "high", "conservative" };
            rawData[24] = new string[] { "barista", "female", "medium", "liberal" };
            rawData[25] = new string[] { "doctor", "male", "medium", "conservative" };
            rawData[26] = new string[] { "analyst", "female", "medium", "conservative" };
            rawData[27] = new string[] { "analyst", "male", "medium", "conservative" };
            rawData[28] = new string[] { "doctor", "female", "medium", "liberal" };
            rawData[29] = new string[] { "barista", "male", "medium", "conservative" };
        }
    }
}
