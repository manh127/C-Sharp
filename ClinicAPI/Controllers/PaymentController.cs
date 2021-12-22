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
    public class PaymentController : ControllerBase
    {

        private RepositoryPrice repositoryPrice;
        public PaymentController()
        {
            repositoryPrice = new RepositoryPrice();
        }
        [HttpPost("shedule-payment")]
        public async Task<RepoResponse<string>> SchedulePayment(CreatPayment request)
        {
            return await repositoryPrice.SchedulePayment(request);
        }
    }
}
