using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetworkNET.APIs;
using NeuralNetworkNET.APIs.Enums;
using NeuralNetworkNET.APIs.Interfaces;
using NeuralNetworkNET.APIs.Interfaces.Data;
using NeuralNetworkNET.APIs.Results;
using NeuralNetworkNET.APIs.Structs;

namespace ClinicSystem.NeuralNetwork
{
    public class NNetwork : INNetwork
    {
        public INeuralNetwork Network { get; set; }
        private float[] minValues, maxValues;
        private bool didTrain = false;
        public NNetwork()
        {
            Network = NetworkManager.NewSequential(TensorInfo.Linear(8),
                NetworkLayers.FullyConnected(12, ActivationType.Tanh),
                NetworkLayers.FullyConnected(16, ActivationType.Tanh),
                NetworkLayers.Softmax(2));
        }

        public Task<TrainingSessionResult> Train(ITrainingDataset dataset, int epochs = 1000)
        {
            didTrain = true;
            return  NetworkManager.TrainNetworkAsync(
                Network,
                dataset,
                TrainingAlgorithms.AdaDelta(),
                epochs, //epochs
                0.5f,
                null,
                null,
                null,
                null,
                new System.Threading.CancellationToken());
        }

        public (bool, float) Decide(float[] input)
        {
            float[] output = Network.Forward(input);
            bool decision = output[0] > 0.5;
            return (decision, output[0]);
        }

        public async Task<(bool, float)> CheckPatient(float[] input)
        {
            if (!didTrain)
            {
                await Train();
            }

            float[] check = input;
            for (int i = 0; i < check.Length; i++)
            {
                check[i] = (check[i] - minValues[i]) / (maxValues[i] - minValues[i]);
            }
            var decision = Decide(check);

            return decision;
        }

        public async Task<NNetworkTrainingResult> Train(int epochs = 1000)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(),"NeuralNetwork", "diabetes.csv");
            var inputData = Utilities.LoadFile(path);
            var preparedData = Utilities.PrepareData(inputData);
            var (min, max) = Utilities.NormalizeValues(preparedData);
            minValues = min;
            maxValues = max;
            var data = Utilities.FormatData(preparedData);

            var sets = Utilities.CreateSets(data);
            var trainingData = sets.Item2;
            var trainingDataLen = trainingData.ToArray().Length;

            ITrainingDataset dataset = DatasetLoader.Training(trainingData, trainingDataLen);

            var result = await Train(dataset,epochs);
            return new NNetworkTrainingResult
            {
                SessionResult = result,
                TestDatasetScore = Score(sets.Item1),
                TrainingDatasetScore = Score(trainingData)
            };
        }

        private float Score(IEnumerable<(float[] x, float[] y)> data)
        {
            (float[] x, float[] u)[] dataAsArray = data.ToArray();
            int validResults = 0;
            for (int i = 0; i < dataAsArray.Length; i++)
            {
                var (input, output) = dataAsArray[i];
                bool decision = Decide(input).Item1;
                bool RealOutcome = output[0] > 0.5;
                if (decision == RealOutcome)
                {
                    validResults++;
                }
            }
            return validResults / (float)dataAsArray.Length;
        }
    }
}
