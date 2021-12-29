using ClinicAPI.Models;
using ClinicAPI.Repo;
using ClinicAPI.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private RepositoryMedicine repositoryMedicine;
        public MedicineController()
        {
            repositoryMedicine = new RepositoryMedicine();
        }
        [HttpPost("create-Medicine")]
        public async Task<RepoResponse<Guid>> CreateMedicine(CreateMedicineRequest request)
        {
            return await repositoryMedicine.CreateMedicine(request);
        }
        [HttpPost("get-Medicine")]
        public async Task<RepoResponse<MedicineModels>> GetMedicineInfo(Guid id)
        {
            return await repositoryMedicine.GetMedicineInfo(id);
        }
        [HttpPost("get-List-Medicine")]
        public async Task<RepoResponse<List<MedicineModels>>> GetListMedicine()
        {
            return await repositoryMedicine.GetListMedicine();
        }
        [HttpPost("update-Medicine")]
        public async Task<RepoResponse<string>> UpdateMedicine(UpdateMedicineRequest request)
        {
            return await repositoryMedicine.UpdateMedicine(request);
        }
        [HttpPost("delete-Medicine")]
        public async Task<RepoResponse<string>> DeleteMedicine(Guid id)
        {
            return await repositoryMedicine.DeleteMedicine(id);
        }
    }
}
