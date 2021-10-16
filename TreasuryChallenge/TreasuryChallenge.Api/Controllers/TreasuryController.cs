using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

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

        [HttpGet]
        [AllowAnonymous]
        [Route("writeLines")]
        public async Task<IActionResult> WriteLines()
        {
            try
            {
                var customers = await _customerJsonRepository.SortCustomersByName();

                return GetResult(new SortCustomerByNameCommandResult(true, "Success", customers.OrderBy(x => x.Name).ToList(), StatusCodes.Status200OK, null));
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
