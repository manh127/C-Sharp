using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAPI.Repo;
using ClinicAPI.Models;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private RoleRepository roleRepository;
        public  RoleController()
        {
            roleRepository = new RoleRepository();
        }

        [HttpPost("Creat-Role")]
        public async Task<bool> CreateRole(string name, string code)
        {
            return await roleRepository.CreateRole(name, code);
        }
        [HttpPost("get-Role")]
        public async Task<RoleModels> GetRoleInfo(Guid id)
        {
            return await roleRepository.GetRoleInfo(id);
        }
        [HttpPost("Update-Role")]
        public async Task<bool> UpdateRole(Guid id, string name, string code)
        {
            return await roleRepository.UpdateRole(id, name, code);
        }
        [HttpPost("Delete-Role")]
        public async Task<bool> DeleteRole(Guid id)
        {
            return await roleRepository.DeleteRole(id);
        }

    }
}
