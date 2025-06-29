using Domain_BLL.DTOs.Employee;
using Domain_BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("All",Name ="GetAllEmployeesAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<IEnumerable<ReadEmployeeDTO>>> GetAllEmployeesAsync()
        {
            var Employees= await _employeeService.GetAllEmployeesAsync();
            if (!Employees.Any() || Employees is null) return NotFound();
            return Ok(Employees);
        }

        [HttpGet("Get{employeeID}", Name ="GetEmployeeByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ReadEmployeeDTO>> GetEmployeeByIDAsync(int employeeID)
        {
            if (employeeID <= 0) return BadRequest();
            var employee=await _employeeService.FindByIDAsync(employeeID);
            if( employee is null) return NotFound();
            return Ok(employee);
        }

        [HttpPost("Create", Name = "CreateEmployeeAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<int>> CreateEmployeeAsync
            (EmployeeDTO employee)
        {
            if( employee is null) return BadRequest();
            var insertedID = await _employeeService.CreateEmployeeAsync(employee);
            if (insertedID <= 0) return BadRequest();

            return CreatedAtRoute("GetEmployeeByIDAsync"
                , new { employeeID = insertedID }, null);
        }

        [HttpPut("{employeeID}", Name = "UpdateEmployeeAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> UpdateEmployeeAsync(int employeeID
            ,EmployeeDTO employee)
        {
            if (employee is null || employeeID <= 0) return BadRequest();
            bool isUpdated = await _employeeService.UpdateEmployeeAsync(employeeID, employee);
            if (isUpdated)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{employeeID}", Name = "DeleteEmployeeAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeleteEmployeeAsync(int employeeID)
        {
            if (employeeID <= 0) return BadRequest();

            bool isDeleted = await _employeeService.DeleteEmployeeAsync(employeeID);
            if(isDeleted)
            {
               return NoContent();
            }
            return NotFound();
        }

        [HttpGet("{personID}", Name = "CanCreateEmployeeAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<bool>> CanCreateEmployeeAsync(int personID)
        {
            if (personID <= 0) return BadRequest();

            bool canCreate = await _employeeService.CanCreateEmployeeAsync(personID);
            return Ok(canCreate);
            
        }


    }
}
