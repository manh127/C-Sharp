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
    
    public class ClassStudentController : ControllerBase
    {
        Models.RepositoryStudent studentRepository;
        public ClassStudentController()
        {
            studentRepository = new RepositoryStudent();
        }


        [HttpPost("add-student-to-class")]
        public async Task<bool> AddStudentToClass(Guid studentId, Guid classId)
        {
            return await studentRepository.AddStudentToClass(studentId, classId);
        }

        [HttpPost("get-student-of-class")]
        public List<StudentModels> GetStudentOfClass(Guid idClass)
        {
            return studentRepository.GetStudentOfClass(idClass);
        }

        [HttpPost("get-student-of-class2")]
        public List<StudentModels> GetStudentOfClassJoin(Guid idClass)
        {
            return studentRepository.GetStudenOfClassJoin(idClass);
        }
    }
}
