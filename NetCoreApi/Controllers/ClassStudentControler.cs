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
    public class ClassStudentControler : ControllerBase
    {
        Models.RepositoryStudent studentRepository;
        public ClassStudentControler()
        {
            studentRepository = new RepositoryStudent();
        }

        [HttpPost("creat-student")]
        public bool Create(string name, string sex, int yearOfBirth)
        {
           
            return studentRepository.Create(name, sex, yearOfBirth);
        }
        [HttpPost("creat-student")]
        public StudentModels GetInfo(Guid id)
            
        {
            return studentRepository.GetStudentInfor(id);
        }
    }
}
