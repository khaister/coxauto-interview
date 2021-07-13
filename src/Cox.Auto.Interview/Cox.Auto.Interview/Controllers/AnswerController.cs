using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cox.Auto.Interview.Controllers
{
    [ApiController]
    [Route("api")]
    public class AnswerController : ControllerBase
    {
        private readonly ILogger<AnswerController> _logger;

        public AnswerController(ILogger<AnswerController> logger)
        {
            _logger = logger;
        }

        [HttpPost("answers")]
        public Task SubmitAnswerAsync()
        {
            return Task.CompletedTask;
        }
    }
}
