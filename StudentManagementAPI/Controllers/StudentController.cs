using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Models;
using StudentManagementAPI.Services;

namespace StudentManagementAPI.Controllers
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
        public ActionResult<List<Student>> Get()
        {
            return Ok(_studentService.Get());
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(string id)
        {
            var student = _studentService.Get(id);

            if (student == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }
            return Ok(student);
        }

        // POST api/<StudentController>
        [HttpPost]
        public ActionResult<Student> Post(Student student)
        {
            _studentService.Create(student);
            return Ok(student);
        }

        // PUT api/<StudentController>/5
        [HttpPut]
        public ActionResult Put([FromBody] Student student)
        {
            try
            {
                _studentService.Update(student);
                return Ok(student);
            } catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
           
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var student = _studentService.Get(id);

            if (student == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }

            _studentService.Remove(student.Id);

            return Ok($"Student with Id = {id} deleted");
        }
    }
}
