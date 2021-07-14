using System.Threading.Tasks;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cox.Auto.Interview.Controllers
{
    [ApiController]
    [Route("api")]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerSubmissionService _service;
        private readonly ILogger<AnswerController> _logger;

        public AnswerController(IAnswerSubmissionService service, ILogger<AnswerController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost("answers")]
        public Task<IO.Swagger.Model.AnswerResponse> SubmitAnswerAsync()
        {
            return _service.SubmitAsync();
        }
    }
}
