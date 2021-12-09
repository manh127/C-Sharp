using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAPI.Models;
using ClinicAPI.Repo;
using ClinicAPI.Request;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private ScheduleRepository scheduleRepository;
        public ScheduleController()
        {
            scheduleRepository = new ScheduleRepository();
        }

        [HttpPost("creat-shedule")]
        public async Task<bool> CreateSchedule([FromQuery] CreateScheduleRequest request)
        {
            return await scheduleRepository.CreateSchedule(request.DoctorId, request.PatientId, request.DateTimeStamp, request.Status, request.ServiceIds);
        }
    }
}
