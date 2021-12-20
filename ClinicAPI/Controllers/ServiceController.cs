using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAPI.Repo;
using ClinicAPI.Entity;
using ClinicAPI.Models;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private ServiceRepository serviceRepository;
        public ServiceController()
        {
            serviceRepository = new ServiceRepository();
        }

        [HttpPost("Creat-Service")]
        public async Task<bool> CreateService(string name, string price)
        {
            return await serviceRepository.CreateService(name, price);
        }
        [HttpPost("get-Service")]
        public async Task<ServiceModels> GetRoleInfo(Guid id)
        {   
            var user = await serviceRepository.GetServiceInfo(id);
            return user;
        }

        [HttpPost("get-list-Service")]
        public async Task<List<ServiceModels>> GetListServiceInfo()
        {
            return await serviceRepository.GetListServiceInfo();
        }

        [HttpPost("Update-Service")]
        public async Task<bool> UpdateService(Guid id, string name, string price)
        {
            return await serviceRepository.UpdateService(id, name, price);
        }
        [HttpPost("Delete-Role")]
        public async Task<bool> DeleteService(Guid id)
        {
            return await serviceRepository.DeleteService(id);
        }
    }
}
