using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OrionCalcApi.BLL;
using OrionCalcShared.DataObjects;

namespace OrionCalcApi.Controllers
{


    public interface IAddController
    {
        Task<IActionResult> PostAddItems(SubmittedItems items);
    }
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AddController : ControllerBase, IAddController
    {
        private readonly ILogger<AddController> _logger;
        private IAddMathService _mathService;
        public AddController(ILogger<AddController> logger)
        {
            _mathService = new AddMathService();
            _logger = logger;
        }

        [HttpPost(Name = "PostAddItems")]
        public Task<IActionResult> PostAddItems(SubmittedItems items )
        {
            MathResult results = _mathService.AddItems(items);


            return Task.FromResult<IActionResult>(Ok(results));
        }
    }
}
