using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetworkNET.APIs;
using NeuralNetworkNET.APIs.Enums;
using NeuralNetworkNET.APIs.Interfaces;
using NeuralNetworkNET.APIs.Interfaces.Data;
using NeuralNetworkNET.APIs.Results;
using NeuralNetworkNET.APIs.Structs;

namespace NeuralNet
{
    class NNetwork : INNetwork
    {
        public INeuralNetwork Network { get; set; }
        public NNetwork()
        {
            Network = NetworkManager.NewSequential(TensorInfo.Linear(8),
                NetworkLayers.FullyConnected(12, ActivationType.Tanh),
                NetworkLayers.FullyConnected(16, ActivationType.Tanh),
                NetworkLayers.Softmax(2));
        }

        public async Task<TrainingSessionResult> Train(ITrainingDataset dataset)
        {
            return await NetworkManager.TrainNetworkAsync(
                Network,
                dataset,
                TrainingAlgorithms.AdaDelta(),
                1000, //epochs
                0.5f,
                null,
                null,
                null,
                null,
                new System.Threading.CancellationToken());
        }

        public bool Decide(float[] input)
        {
            float[] output = Network.Forward(input);
            bool decision = output[0] > 0.5;
            return decision;
        }
        public bool CheckPatient(float[] input)
        {
            var inputData = Utilities.LoadFile(@"diabetes.csv");
            var preparedData = Utilities.PrepareData(inputData);
            var values = Utilities.NormalizeValues(preparedData);
            var min = values.min;
            var max = values.max;
            var data = Utilities.FormatData(preparedData);

            var sets = Utilities.CreateSets(data);
            var trainingData = sets.Item2;
            var trainingDataLen = trainingData.ToArray().Length;

            ITrainingDataset dataset = DatasetLoader.Training(trainingData, trainingDataLen);

            var net = new NNetwork();
            net.Train(dataset).Wait();

            float[] check = input;
            for (int i = 0; i < check.Length; i++)
            {
                check[i] = (check[i] - min[i]) / (max[i] - min[i]);
            }
            var decision = net.Decide(check);

            return decision;
        }
    }
}
