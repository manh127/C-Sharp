using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAPI.Repo;
using ClinicAPI.Entity;
using ClinicAPI.Models;
using ClinicAPI.Request;

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
        public async Task<bool> Create([FromBody] CreatUserRequest request)
        {
            return await userRepository.Create(request.Name,request.Sex,request.YearOfBirth,request.Phone,request.Address,request.Username,request.Password);
        }
        [HttpPost("get-User")]
        public async Task<UserModels> GetUserInfo(Guid id)
        {
            return await userRepository.GetUserInfo(id);
        }
        [HttpPost("Update-User")]
        public async Task<bool> Update([FromBody] UpdateUserRequest request)
        {
            return await userRepository.UpdateUser(request.Id, request.Name, request.Sex,request.YearOfBirth,request.Address,request.Phone);
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
        [HttpPost("get-list-doctor-service")]
        public async Task<List<DoctorModels>> GetListDoctorService(Guid ServiceId)
        {
            return await userRepository.GetDoctorOfServices(ServiceId);
        }
        [HttpPost("get-list-user-by-role")]
        public async Task<RepoResponse<List<UserInfomation>>> GetUserByRole(GetUserByRoleRequest Request)
        {
            return await userRepository.GetUser(Request);
        }
    }
}
