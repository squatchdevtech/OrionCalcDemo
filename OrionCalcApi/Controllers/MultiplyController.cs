using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrionCalcApi.BLL;
using OrionCalcShared.DataObjects;

namespace OrionCalcApi.Controllers
{
    public interface IMultiplyController
    {
        Task<IActionResult> PostMultiplyItems(SubmittedItems items);
    }
    [Route("api/[controller]")]
    [ApiController]
    public class MultiplyController : ControllerBase
    {
        private readonly ILogger<AddController> _logger;
        private IMultiplyMathService _mathService;
        public MultiplyController(ILogger<AddController> logger)
        {
            _mathService = new MultiplyMathService();
            _logger = logger;
        }

        [HttpPost(Name = "PostMultiplyItems")]
        public Task<IActionResult> PostMultiplyItems(SubmittedItems items)
        {
            MathResult results = _mathService.MultiplyItems(items);


            return Task.FromResult<IActionResult>(Ok(results));
        }
    }
}
