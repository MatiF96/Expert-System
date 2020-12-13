using NeuralNetworkNET.APIs.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.NeuralNetwork
{
    public class NNetworkTrainingResult
    {
        public TrainingSessionResult SessionResult { get; set; }
        public float TrainingDatasetScore { get; set; }
        public float TestDatasetScore { get; set; }
    }
}
