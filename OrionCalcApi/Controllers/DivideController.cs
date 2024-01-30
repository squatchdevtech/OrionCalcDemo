using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrionCalcApi.BAL;
using OrionCalcApi.BLL;

namespace OrionCalcApi.Controllers
{
    public interface IDivideController
    {
        Task<IActionResult> PostDivideItems(SubmittedItems items);
    }

    [Route("api/[controller]")]
    [ApiController]
    public class DivideController : ControllerBase, IDivideController
    {

        private readonly ILogger<DivideController> _logger;
        private IDivideMathService _mathService;
        public DivideController(ILogger<DivideController> logger)
        {
            _mathService = new DivideMathService();
            _logger = logger;
        }

        [HttpPost(Name = "PostDivideItems")]
        public Task<IActionResult> PostDivideItems(SubmittedItems items)
        {
            MathResult results = _mathService.DivideItems(items);

            return Task.FromResult<IActionResult>(Ok(results));
        }
    }
}
