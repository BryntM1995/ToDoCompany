using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoCompany.Service.DTOs;
using ToDoCompany.Service;

namespace ToDoCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTaskController : ControllerBase
    {
        private readonly IBaseService<EmployeeTaskDto> _employeeTaskServices;

        public EmployeeTaskController(IBaseService<EmployeeTaskDto> service)
        {
            _employeeTaskServices = service;
        }
        [HttpGet]
        public IEnumerable<EmployeeTaskDto> GetAll()
        {
            return _employeeTaskServices.GetAll();
        }
        [HttpGet("{id}")]
        public EmployeeTaskDto GetById([FromRoute] int id)
        {
            return _employeeTaskServices.GetById(id);
        }
        [HttpPost]
        public IActionResult Add([FromBody] EmployeeTaskDto value)
        {
            _employeeTaskServices.Add(value);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] EmployeeTaskDto value)
        {
            if (id != value.Id)
                return BadRequest();

            _employeeTaskServices.Update(value);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            _employeeTaskServices.Remove(id);
            return Ok();
        }
    }
}
