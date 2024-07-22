using Microsoft.AspNetCore.Mvc;
using MonthlyReprimand.Models.Request;
using MonthlyReprimand.Services;

namespace MonthlyReprimand.Controllers
{
    /// <summary>
    /// управляет входами и выходами сотрудников
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CheckPointController : Controller
    {
        private readonly ShiftService _shiftService;

        public CheckPointController(ShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        /// <summary>
        /// Приход на завод
        /// </summary>
        /// <param name="id"></param>
        /// <param name="StartShift"></param>
        /// <returns></returns>
        [HttpPost("start")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> StartShift(StartShiftRequest startShiftRequest)
        {
            await _shiftService.StartShiftAsync(startShiftRequest);

            return Ok();
        }

        /// <summary>
        /// Выход с завода
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("exit")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> EndShif(EndShiftRequest endShiftRequest)
        {
            await _shiftService.EndShiftAsync(endShiftRequest);

            return Ok();
        }
    }
}
