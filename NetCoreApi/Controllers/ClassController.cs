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
    public class ClassController : ControllerBase
    {
        Models.RepositoryClass classRepository;
        public  ClassController()
            {
            classRepository = new RepositoryClass();
            }

        [HttpPost("create-class")]
        public bool CreateClass(string name, int grade)
        {
            return classRepository.CreateClass(name, grade);
        }

        [HttpPost("get-class")]
        public ClassModels GetInformation(Guid id)
        {
            return classRepository.GetInformation(id);
        }

        [HttpPost("update-class")]
        public bool UpdateClass(Guid id, string name, int grade)
        {
            return classRepository.UpdateClass(id,name, grade);
        }

        [HttpPost("delete-class")]
        public bool DeleteClass(Guid id)
        {
            return classRepository.DeleteClass(id);
        }
    }
}
