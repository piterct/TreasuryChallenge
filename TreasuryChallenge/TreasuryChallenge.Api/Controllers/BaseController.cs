using Microsoft.AspNetCore.Mvc;
using TreasuryChallenge.Domain.Commands.Result;

namespace TreasuryChallenge.Api.Controllers
{
    public class BaseController : Controller
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetResult(GetLinesAmountToWriteCommandResult result) => StatusCode(result.StatusCode, result);
    }
}
