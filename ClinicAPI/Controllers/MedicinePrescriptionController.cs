using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ClinicAPI.Repo;
using System.Threading.Tasks;
using ClinicAPI.Models;
using ClinicAPI.Request;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinePrescriptionController : ControllerBase
    {
        private RepositoryPrescription repositoryPrescription;
        public MedicinePrescriptionController()
        {
            repositoryPrescription = new RepositoryPrescription();
        }
        [HttpPost("create-Medicine")]
        public async Task<RepoResponse<Guid>> CreatePrescription(CreatePrescriptionRequest request)
        {
            return await repositoryPrescription.CreatePrescription(request);
        }
        [HttpPost("delete-presctiption-medicine")]
        public async Task<RepoResponse<string>> DeletePresctiption(Guid Id)
        {
            return await repositoryPrescription.DeletePresctiption(Id);
        }
    }
}
