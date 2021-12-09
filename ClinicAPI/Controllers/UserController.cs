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
    public class UserController : ControllerBase
    {
        private UserRepository userRepository;
        public UserController()
        {
            userRepository = new UserRepository();
        }
        [HttpPost("Creat-User")]
        public async Task<bool> Create(string name, string sex, int yearOfBirth, string phone, string address,string username,string password)
        {
            return await userRepository.Create(name, sex, yearOfBirth, phone, address, username, password);
        }
        [HttpPost("get-User")]
        public async Task<UserModels> GetUserInfo(Guid id)
        {
            return await userRepository.GetUserInfo(id);
        }
        [HttpPost("Update-User")]
        public async Task<bool> Update(Guid id ,string name, string sex, int yearOfBirth, string phone, string address, string username, string password)
        {
            return await userRepository.UpdateUser(id,name, sex, yearOfBirth, phone, address, username, password);
        }
        [HttpPost("Delete-User")]
        public async Task<bool> Delete(Guid id)
        {
            return await userRepository.DeleteUser(id);
        }
        [HttpPost("User-Role")]
        public async Task<bool> UserRole(Guid UserId, Guid RoleId)
        {
            return await userRepository.AddUserRole(UserId, RoleId);
        }
        [HttpPost("Get-User-Role")]
        public async Task <List<UserModels>> GetUserRole(Guid idRole)
        {
            return await userRepository.GetUserRole(idRole);
        }
        [HttpPost("add-service-to-doctor")]
        public async Task<bool> AddServiceToDotor(Guid DoctorId, Guid ServiceId)
        {
            return await userRepository.AddServiceToDoctor(DoctorId, ServiceId);
        }
    }
}
