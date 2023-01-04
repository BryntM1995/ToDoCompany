using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoCompany.Service;
using ToDoCompany.Service.DTOs;

namespace ToDoCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IBaseService<EmployeeDto> _employeeServices;

        public EmployeeController(IBaseService<EmployeeDto> service)
        {
            _employeeServices = service;
        }
        [HttpGet]
        public IEnumerable<EmployeeDto> GetAll()
        {
            return _employeeServices.GetAll();
        }
        [HttpGet("{id}")]
        public EmployeeDto GetById([FromRoute] int id)
        {
            return _employeeServices.GetById(id);
        }
        [HttpPost]
        public IActionResult Add([FromBody] EmployeeDto value)
        {
            _employeeServices.Add(value);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] EmployeeDto value)
        {
            if (id != value.Id)
                return BadRequest();

            _employeeServices.Update(value);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            _employeeServices.Remove(id);
            return Ok();
        }
    }
}
