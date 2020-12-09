using NeuralNetworkNET.APIs;
using NeuralNetworkNET.APIs.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputData = Utilities.LoadFile(@"diabetes.csv");
            var preparedData = Utilities.PrepareData(inputData);
            Utilities.NormalizeValues(preparedData);
            var data = Utilities.FormatData(preparedData);

            var sets = Utilities.CreateSets(data);
            var validationData = sets.Item1;
            var trainingData = sets.Item2;
            var trainingDataLen = trainingData.ToArray().Length;

            ITrainingDataset dataset = DatasetLoader.Training(trainingData, trainingDataLen);

            var net = new NNetwork();
            net.Train(dataset).Wait();

            Console.WriteLine("Zbiór uczący - uzyskany wynik: ");
            Console.WriteLine(Score(trainingData, net));
            Console.WriteLine("Zbiór testowy - uzyskany wynik: ");
            Console.WriteLine(Score(validationData, net));

        }

        private static float Score(IEnumerable<(float[] x, float[] y)> data, NNetwork net)
        {
            (float[] x, float[] u)[] dataAsArray = data.ToArray();
            int validResults = 0;
            for (int i = 0; i < dataAsArray.Length; i++)
            {
                var (input, output) = dataAsArray[i];
                bool decision = net.Decide(input);
                bool RealOutcome = output[0] > 0.5;
                if (decision == RealOutcome)
                {
                    validResults++;
                }
            }
            return validResults/(float)dataAsArray.Length;
        }
    }
}
