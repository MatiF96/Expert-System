using ClinicSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Services
{
    public class NeuralNetworkService : INeuralNetworkService
    {
        //private readonly INNetwork _nNetwork;

        //public NeuralNetworkService(INNetwork nNetwork)
        //{
        //    _nNetwork = nNetwork;
        //}

        public DecisionResult GetDecision(NeuralNetworkInput input)
        {
            //var result = _nNetwork.Decide(input.ToInputData());
            return new DecisionResult
            {
                Decision = true,
                Propability = 0.7f
            };
        }

        public async Task<TrainingResult> Train()
        {
            //TrainingSessionResult trainingResult = await _nNetwork.Train();

            //var result = new TrainingResult
            //{
            //    CompletedEpochs = trainingResult.CompletedEpochs,
            //    TrainingTime = trainingResult.TrainingTime,
            //    TestReports = trainingResult.TestReports.Select(r => new EvaulationResult
            //    {
            //        Accuraty = r.Accuracy,
            //        Cost = r.Cost
            //    }).ToList(),
            //    ValidationReports = trainingResult.ValidationReports.Select(r => new EvaulationResult
            //    {
            //        Accuraty = r.Accuracy,
            //        Cost = r.Cost
            //    }).ToList(),
            //};



            return null;
        }

    }
}

/*
 * new EvaulationResult
                {
                    Accuraty = r.Accuracy,
                    Cost = r.Cost
                }
(r =>
                {
                    new EvaulationResult
                    {
                        Accuraty = r.Accuracy,
                        Cost = r.Cost
                    };
                })

 */