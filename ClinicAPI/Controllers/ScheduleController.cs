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
            return await scheduleRepository.CreateSchedule(request);
        }
        [HttpPost("get-schedule-of-doctor")]
        public async Task<List<ScheduleOfDoctorModel>> GetScheduleOfDoctor(Guid idDoctor,int? status)
        {
            return await scheduleRepository.GetScheduleOfDoctor(idDoctor,status);
        }
        [HttpPost("get-schedule-of-patient")]
        public async Task<List<ScheduleOfPatientModel>> GetScheduleOfPatient(Guid idPatient, int? status)
        {
            return await scheduleRepository.GetScheduleOfPatient(idPatient, status);
        }

        [HttpPost("get-detail-patient-shedule")]
        public async Task<ScheduleOfPatientModel> DetailSchedulePatient(Guid IdShcedule, Guid IdPatient)
        {
            return await scheduleRepository.DetailSchedulePatient(IdShcedule,IdPatient);
        }
        [HttpPost("get-detail-doctor-shedule")]
        public async Task<ScheduleOfDoctorModel> DetailScheduleDoctor(Guid IdShcedule, Guid IdDoctor)
        {
            return await scheduleRepository.DetailScheduleDoctor(IdShcedule, IdDoctor);
        }
        [HttpPost("update-shedule")]
        public async Task<bool> UpdateSchedule([FromQuery] UpdateScheduleRequest request)
        {
            return await scheduleRepository.UpdateSchedule(request);
        }
        [HttpPost("delete-shedule")]
        public async Task<bool> DeleteSchedule(Guid Id)
        {
            return await scheduleRepository.DeleteSchedule(Id);
        }
    }
}
