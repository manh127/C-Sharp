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
        public async Task<RepoResponse<string>> CreateSchedule([FromQuery] CreateScheduleRequest request)
        {
            return await scheduleRepository.CreateSchedule(request);
        }
        [HttpPost("get-schedule-of-doctor")]
        public async Task<RepoResponse<List<ScheduleOfDoctorModel>>> GetScheduleOfDoctor(Guid idDoctor,int? status)
        {
            return await scheduleRepository.GetScheduleOfDoctor(idDoctor,status);
        }
        [HttpPost("get-schedule-of-patient")]
        public async Task<RepoResponse<List<ScheduleOfPatientModel>>> GetScheduleOfPatient(Guid idPatient, int? status)
        {
            return await scheduleRepository.GetScheduleOfPatient(idPatient, status);
        }

        [HttpPost("get-detail-patient-schedule")]
        public async Task<RepoResponse<ScheduleOfPatientModel>> DetailSchedulePatient(Guid IdShcedule, Guid IdPatient)
        {
            return await scheduleRepository.DetailSchedulePatient(IdShcedule,IdPatient);
        }
        [HttpPost("get-detail-doctor-schedule")]
        public async Task<RepoResponse<ScheduleOfDoctorModel>> DetailScheduleDoctor(Guid IdShcedule, Guid IdDoctor)
        {
            return await scheduleRepository.DetailScheduleDoctor(IdShcedule, IdDoctor);
        }
        [HttpPost("update-schedule")]
        public async Task<RepoResponse<string>> UpdateSchedule([FromQuery] UpdateScheduleRequest request)
        {
            return await scheduleRepository.UpdateSchedule(request);
        }
        [HttpPost("delete-schedule")]
        public async Task<RepoResponse<string>> DeleteSchedule(Guid Id)
        {
            return await scheduleRepository.DeleteSchedule(Id);
        }

        [HttpPost("cancel-schedule-patient")]
        public async Task<RepoResponse<string>> CancelSchedulePatient(CancelSchedulePatient request)
        {
            return await scheduleRepository.CancelSchedulePatient(request);
        }

        [HttpPost("confirm-schedule-doctor")]
        public async Task<RepoResponse<string>> ConfirmScheduleDoctor(ConfirmScheduleRequestDoctor request)
        {
            return await scheduleRepository.ConfirmScheduleDoctor(request);
        }
    }
}
