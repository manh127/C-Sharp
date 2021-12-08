using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        Models.RepositoryStudent studentRepository;
        public StudentController()
        {
            studentRepository = new RepositoryStudent();
        }

        [HttpPost("creat-student")]
        public bool Create(string name, string sex, int yearOfBirth)
        {
            return studentRepository.Create(name, sex, yearOfBirth);
        }
        [HttpPost("get-student")]
        public StudentModels GetInfo(Guid id)

        {
            return studentRepository.GetStudentInfor(id);
        }
        [HttpPost("update-student")]
        public bool UpdateStudent(Guid id , string name, string sex, int yearOfBirth)
        {
            return studentRepository.UpdateStudent(id, name, sex, yearOfBirth);
        }
        [HttpPost("delete-student")]
        public bool DeleteStudent(Guid id)
        {
            return studentRepository.DeleteStudent(id);
        }
        
    }
}
