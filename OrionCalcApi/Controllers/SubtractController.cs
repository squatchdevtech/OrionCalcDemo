using Microsoft.AspNetCore.Mvc;
using OrionCalcApi.BAL;
using OrionCalcApi.BLL;

namespace OrionCalcApi.Controllers
{
    public interface ISubtractController 
    {
        Task<IActionResult>PostSubtractItems(SubmittedItems items);
    }

    [Route("api/[controller]")]
    [ApiController]
    public class SubtractController : ControllerBase, ISubtractController
    {
        private readonly ILogger<SubtractController> _logger;
        private ISubtractMathService _mathService;
        //public SubtractController(ILogger<SubtractController> logger, ISubtractMathService<SubtractMathService> subtractMathService)
        public SubtractController(ILogger<SubtractController> logger)
        {
            //i have to do this because not injecting right?
            _mathService = new SubtractMathService();
            _logger = logger;
        }

        [HttpPost(Name = "PostSubtractItems")]
        public Task<IActionResult> PostSubtractItems(SubmittedItems items)
        {
            MathResult results = _mathService.SubtractItems(items);


            return Task.FromResult<IActionResult>(Ok(results));
        }
    }
}
