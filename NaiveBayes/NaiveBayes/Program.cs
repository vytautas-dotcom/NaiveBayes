using System;

namespace NaiveBayes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prediction of person's political iniclination (liberal/conservative) from job, sex and income\n");

            Data data = new Data();
            Show show = new Show();

            show.ShowData(data.rawData, 5, 5, true);
        }
    }
}
