using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAPI.Models;
using ClinicAPI.Repo;

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
        public async Task<bool> CreateSchedule(Guid DoctorId, Guid PatientId, long DateTimeStamp, int Status, List<Guid> serviceIds)
        {
            return await scheduleRepository.CreateSchedule(DoctorId, PatientId, DateTimeStamp, Status,serviceIds);
        }
    }
}
