using Microsoft.AspNetCore.Mvc;
using MonthlyReprimand.Models.Request;
using MonthlyReprimand.Models.Response;
using MonthlyReprimand.Services;

namespace MonthlyReprimand.Controllers
{

    /// <summary>
    /// Контроллер “отдела кадров”
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HRDepartmentController : Controller
    {
        private readonly EmployeeService _employeService;
        private readonly PositionService _positionService;

        public HRDepartmentController(EmployeeService employeService, PositionService positionService)
        {
            _employeService = employeService;
            _positionService = positionService;
        }

        /// <summary>
        /// Получить список всех сотрудников
        /// </summary>
        /// <param name="getEmployeesRequest"></param>
        [HttpGet("GetAllEmployees")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<GetEmployeesResponse>>> GetAllEmployeesAsync([FromQuery] GetEmployeesRequest getEmployeesRequest)
        {
            var result = await _employeService.GetAllEmployeesAsync(getEmployeesRequest);
            return Ok(result);
        }

        /// <summary>
        /// Добавление сотрудника
        /// </summary>
        /// <param name="createEmployeeRequest"></param>
        [HttpPost("CreateEmployee")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<CreateEmployeeResponse>> CreateEmployeeAsync([FromBody] CreateEmployeeRequest createEmployeeRequest)
        {
            var result = await _employeService.CreateEmployeeAsync(createEmployeeRequest);
            return Ok(result);
        }

        /// <summary>
        /// Обновление сотрудника
        /// </summary>
        /// <param name="updateEmployeeRequest"></param>
        [HttpPut("EditEmployee")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<UpdateEmployeeResponse>> UpdateEmployeeAsync([FromQuery] UpdateEmployeeRequest updateEmployeeRequest)
        {
            var result = await _employeService.UpdateEmployeeAsync(updateEmployeeRequest);

            return Ok(result);
        }

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        /// <param name="deleteEmployeeRequest"></param>
        [HttpDelete("DeleteEmployee")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteEmployeeAsync([FromQuery] DeleteEmployeeRequest deleteEmployeeRequest)
        {
            await _employeService.DeleteEmployeeAsync(deleteEmployeeRequest);

            return NoContent();
        }

        /// <summary>
        /// Получение всех должностей
        /// </summary>
        /// <param name="getPositionAsyncRequest"></param>
        [HttpGet("GetPosition")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<GetPositionsResponse>>> GetAllPositionsAsync()
        {
            var result = await _positionService.GetAllPositionsAsync();

            return Ok(result);
        }
    }
}
