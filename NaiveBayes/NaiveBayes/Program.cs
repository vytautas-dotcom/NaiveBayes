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

            show.SplitData(data.rawData, 27, out string[][] train, out string[][] test);

            Console.WriteLine("Train data");
            Console.WriteLine(new string('-', 64));
            show.ShowData(train, 24, 0, true);

            Console.WriteLine("Test data");
            Console.WriteLine(new string('-', 64));
            show.ShowData(test, 6, 0, true);

            BayesClassifier bayes = new BayesClassifier(train);
            bayes.Train();
            double prob = bayes.Probability(new string[] { "barista", "female", "low"}, "liberal");

            Console.WriteLine("Probability: " + prob);
        }
    }
}
