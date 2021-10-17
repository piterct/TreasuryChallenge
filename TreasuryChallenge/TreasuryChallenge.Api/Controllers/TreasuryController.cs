using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TreasuryChallenge.Domain.Commands.Inputs;
using TreasuryChallenge.Domain.Commands.Result;
using TreasuryChallenge.Domain.Handlers;

namespace TreasuryChallenge.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TreasuryController : BaseController
    {
        private readonly ILogger<TreasuryController> _logger;
        public TreasuryController(ILogger<TreasuryController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("writeLines/{lines:int}")]
        [ProducesResponseType(typeof(GetLinesAmountToWriteCommandResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> WriteLines(int lines, [FromServices] TreasuryHandler handler)
        {
            try
            {
                var result = await handler.Handle(new GetLinesAmountToWriteCommandInput { LinesAmount = lines });

                return GetResult(result);
            }
            catch (Exception exception)
            {
                _logger.LogError("An exception has occurred at {dateTime}. " +
                 "Exception message: {message}." +
                 "Exception Trace: {trace}", DateTime.UtcNow, exception.Message, exception.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
