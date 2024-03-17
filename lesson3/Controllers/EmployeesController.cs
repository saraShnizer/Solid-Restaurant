using Restaurant.Core.Models;
using Restaurant.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Services;
using System.Collections.Generic;
using AutoMapper;
using Restaurant.Core.DTOs;
using lesson3.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lesson3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }


        // GET: api/<EmployeesController>
        [HttpGet]
        public ActionResult Get()
        {
            var employees= _employeeService.GetEmployees();
            var employeesDTO = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
            return Ok(employeesDTO);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var employee=_employeeService.GetById(id);
            var employeeDTO=_mapper.Map<EmployeeDTO>(employee);
            return Ok( employeeDTO);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public ActionResult Post([FromBody] EmployeePostModel employee)
        {
            var employeeToAdd = (new Employee
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                PhoneNumber = employee.PhoneNumber,

            });
           return Ok( _employeeService.AddEmployee(employeeToAdd));
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] EmployeeDTO employee)
        {
            var employeeToApdate = (new Employee
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                PhoneNumber = employee.PhoneNumber,
            });
            return Ok( _employeeService.UpdateEmployee(id, employeeToApdate));
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _employeeService.DeleteEmployee(id);
        }
    }
}
