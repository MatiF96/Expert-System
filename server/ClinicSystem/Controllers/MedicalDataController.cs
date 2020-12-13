using ClinicSystem.DTO;
using ClinicSystem.Services;
using ClinicSystem.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Doctor")]
    public class MedicalDataController : ControllerBase
    {
        private readonly INeuralNetworkService _neuralNetworkService;

        public MedicalDataController(INeuralNetworkService neuralNetworkService)
        {
            _neuralNetworkService = neuralNetworkService;
        }

        [HttpPost("train")]
        [ProducesResponseType(typeof(TrainingResult), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        public async Task<ActionResult> TrainModel([FromBody] TrainingRequest request)
        {
            if(request.Epochs == 0)
            {
                return BadRequest(new Error("Provide positive number of epochs"));
            }

            var result = request.Epochs != null ? await _neuralNetworkService.Train((int)request.Epochs) : await _neuralNetworkService.Train();
            return Ok(result);
        }

        [HttpPost("result")]
        [ProducesResponseType(typeof(DecisionResult), 200)]
        public async Task<ActionResult> GetResult([FromBody] NeuralNetworkInput input)
        {
            var result = await _neuralNetworkService.GetDecisionAsync(input);
            return Ok(result);
        }
    }
}
