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
        public async Task<RepoResponse<Guid>> Create([FromBody] CreatUserRequest request)
        {
            return await userRepository.Create(request);
        }
        [HttpPost("get-User")]
        public async Task<RepoResponse<UserModels>> GetUserInfo(Guid id)
        {
            return await userRepository.GetUserInfo(id);
        }
        [HttpPost("Update-User")]
        public async Task<RepoResponse<string>> Update([FromBody] UpdateUserRequest request)
        {
            return await userRepository.UpdateUser(request);
        }
        [HttpPost("Delete-User")]
        public async Task<RepoResponse<string>> Delete(Guid id)
        {
            return await userRepository.DeleteUser(id);
        }
        [HttpPost("User-Role")]
        public async Task<RepoResponse<string>> UserRole([FromBody] UserRoleReq userRoleReq)
        {
            return await userRepository.AddUserRole(userRoleReq);
        }
        [HttpPost("Get-User-Role")]
        public async Task <RepoResponse<List<UserModels>>> GetUserRole(Guid idRole)
        {
            return await userRepository.GetUserRole(idRole);
        }
        [HttpPost("add-service-to-doctor")]
        public async Task<RepoResponse<string>> AddServiceToDotor(Guid DoctorId, Guid ServiceId)
        {
            return await userRepository.AddServiceToDoctor(DoctorId, ServiceId);
        }
        [HttpPost("get-list-doctor-service")]
        public async Task<RepoResponse<List<DoctorModels>>> GetListDoctorService(Service ServiceId)
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
