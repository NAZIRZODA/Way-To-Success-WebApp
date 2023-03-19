﻿using Microsoft.AspNetCore.Mvc;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.RequestModels;
using WTSuccess.Application.RequestModels.StudentRequestModels;
using WTSuccess.Application.ResponseModels.StudentResponseModels.cs;
using WTSuccess.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WayToSuccess.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public StudentResponseModel Get(ulong id)
        {
            return _studentService.GetById(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] CreateStudentRequestModel student)
        {
            _studentService.Add(student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] UpdateStudentRequestModel student, ulong id)
        {
            _studentService.Update(student, id);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(ulong id)
        {
            _studentService.Delete(id);
        }
    }
}