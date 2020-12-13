using ClinicSystem.DTO;
using ClinicSystem.NeuralNetwork;
using NeuralNetworkNET.APIs.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Services
{
    public class NeuralNetworkService : INeuralNetworkService
    {
        private readonly NNetwork _nNetwork;

        public NeuralNetworkService(NNetwork nNetwork)
        {
            _nNetwork = nNetwork;
        }

        public async Task<DecisionResult> GetDecisionAsync(NeuralNetworkInput input)
        {
            var result = await _nNetwork.CheckPatient(input.ToInputData());
            return new DecisionResult
            {
                Decision = result.Item1,
                Propability = result.Item2
            };
        }

        public async Task<TrainingResult> Train(int epochs)
        {
            var trainingResult = await _nNetwork.Train(epochs);

            var result = new TrainingResult
            {
                TestDatasetScore = trainingResult.TestDatasetScore,
                TrainingDatasetScore = trainingResult.TrainingDatasetScore,
                CompletedEpochs = trainingResult.SessionResult.CompletedEpochs,
                TrainingTime = trainingResult.SessionResult.TrainingTime.TotalSeconds,
                TestReports = trainingResult.SessionResult.TestReports.Select(r => new EvaulationResult
                {
                    Accuraty = r.Accuracy,
                    Cost = r.Cost
                }).ToList(),
                ValidationReports = trainingResult.SessionResult.ValidationReports.Select(r => new EvaulationResult
                {
                    Accuraty = r.Accuracy,
                    Cost = r.Cost
                }).ToList(),
            };

            return result;
        }

    }
}