using ClinicSystem.DTO;
using ClinicSystem.Services;
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

        [HttpGet("train")]
        [ProducesResponseType(typeof(TrainingResult), 200)]
        public ActionResult TrainModel()
        {
            return Ok();
        }

        [HttpPost("result")]
        [ProducesResponseType(typeof(DecisionResult), 200)]
        public ActionResult GetResult([FromBody] NeuralNetworkInput input)
        {
            var result = _neuralNetworkService.GetDecision(input);
            return Ok(result);
        }
    }
}
