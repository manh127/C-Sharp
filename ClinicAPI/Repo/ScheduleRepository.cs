using ClinicAPI.Entity;
using ClinicAPI.Models;
using ClinicAPI.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ClinicAPI.Constants;

namespace ClinicAPI.Repo
{
    public class ScheduleRepository
    {
        public async Task<RepoResponse<string>> CreateSchedule(CreateScheduleRequest scheduleRequest)
        {
            try
            {
                using (var db = new MyDbContext())
                {

                    var checkDoctor = await db.UserPeoples.Where(x => x.Id.ToString() == scheduleRequest.DoctorId).FirstOrDefaultAsync();
                    var checkPatient = await db.UserPeoples.Where(x => x.Id.ToString() == scheduleRequest.PatientId).FirstOrDefaultAsync();
                    var checkService = await db.Services.Where(x => x.Id.ToString() == scheduleRequest.ServiceId).FirstOrDefaultAsync();
                    var checkDoctorService = await db.DoctorServices.Where(x => x.UserId.ToString() == scheduleRequest.DoctorId && x.ServiceId.ToString() == scheduleRequest.ServiceId).FirstOrDefaultAsync();

                    if (checkDoctor == null)
                    {
                        return new RepoResponse<string> { Status = 0, Msg = "Không có bác sĩ này" };
                    }
                    if (checkPatient == null)
                    {
                        return new RepoResponse<string> { Status = 0, Msg = "Không có bệnh nhân này" };
                    }
                    if (checkService == null || checkDoctorService == null)
                    {
                        return new RepoResponse<string> { Status = 0, Msg = "Không có dịch vụ này" };
                    }
                    if (checkDoctorService == null)
                    {
                        return new RepoResponse<string> { Status = 0, Msg = "Không có bác sĩ nào khám dịch vụ này" };
                    }
                    var schedule = new Schedule
                    {
                        Id = Guid.NewGuid(),
                        DateTimeStamp = scheduleRequest.DateTimeStamp,
                        DoctorId = Guid.Parse(scheduleRequest.DoctorId),
                        PatientId = Guid.Parse(scheduleRequest.PatientId),
                        Status = (int)Constants.ScheduleStatus.NOT_CONFIRM,
                        ServiceId = Guid.Parse(scheduleRequest.ServiceId)
                    };
                    db.Schedules.Add(schedule);
                    await db.SaveChangesAsync();
                    return new RepoResponse<string> { Status = 1, Msg = "Tạo lịch hẹn thành công " };
                }
            }
            catch (Exception e)
            {

                return new RepoResponse<string> { Status = 0, Msg = "Lỗi" };
            }
        }
        public async Task<RepoResponse<List<ScheduleOfDoctorModel>>> GetScheduleOfDoctor(Guid idDoctor, int? status)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var getDoctor = await db.UserPeoples.Where(x => x.Id == idDoctor).FirstOrDefaultAsync();
                    if (getDoctor == null)
                    {
                        return new RepoResponse<List<ScheduleOfDoctorModel>> { Status = 0, Msg = "Không tìm thấy bác sĩ này" };
                    }
                    var listScheduleDoctorDb = db.Schedules.Where(x => x.DoctorId == idDoctor);
                    if (status != null)
                    {
                        listScheduleDoctorDb = listScheduleDoctorDb.Where(x => x.Status == status);
                    }

                    var listScheduleDoctor = await listScheduleDoctorDb
                        .Join(db.UserPeoples, s => s.PatientId, us => us.Id, (s, us) => new { s, us })
                        .Join(db.Services, sh => sh.s.ServiceId, service => service.Id, (sh, service) => new { sh, service })
                        .ToListAsync();

                    var data = new List<ScheduleOfDoctorModel>();
                    if (listScheduleDoctor.Count() > 0)
                    {
                        foreach (var item in listScheduleDoctor)
                        {

                            data.Add(new ScheduleOfDoctorModel
                            {
                                Id = item.sh.s.Id,
                                DateTimeStamp = item.sh.s.DateTimeStamp,
                                IdPatient = item.sh.s.PatientId,
                                NamePatient = item.sh.us.Name,
                                ServiceName = item.service.Name,
                                ServicePrice = item.service.Price
                            });
                        }
                    }
                    return new RepoResponse<List<ScheduleOfDoctorModel>> { Status = 1, Data = data };

                }
            }
            catch (Exception e)
            {
                return new RepoResponse<List<ScheduleOfDoctorModel>> { Status = 0, Msg = "Lỗi" };
            }
        }
        public async Task<RepoResponse<List<ScheduleOfPatientModel>>> GetScheduleOfPatient(Guid idPatient, int? status)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var getPatient = await db.UserPeoples.Where(x => x.Id == idPatient).FirstOrDefaultAsync();
                    if (getPatient == null)
                    {
                        return new RepoResponse<List<ScheduleOfPatientModel>> { Status = 0, Msg = "Không tìm thấy bệnh nhân " };
                    }
                    var listSchedulePatientDb = db.Schedules.Where(x => x.PatientId == idPatient);
                    if (status != null)
                    {
                        listSchedulePatientDb = listSchedulePatientDb.Where(x => x.Status == status);
                    }
                    var listSchedulePatient = await listSchedulePatientDb
                        .Join(db.UserPeoples, s => s.DoctorId, us => us.Id, (s, us) => new { s, us })
                        .Join(db.Services, sh => sh.s.ServiceId, service => service.Id, (sh, service) => new { sh, service })
                        .ToListAsync();

                    var data = new List<ScheduleOfPatientModel>();
                    if (listSchedulePatient.Count() > 0)
                    {
                        foreach (var item in listSchedulePatient)
                        {

                            data.Add(new ScheduleOfPatientModel
                            {
                                Id = item.sh.s.Id,
                                IdDoctor = item.sh.s.DoctorId,
                                NameDoctor = item.sh.us.Name,
                                DateTimeStamp = item.sh.s.DateTimeStamp,
                                ServiceName = item.service.Name,
                                ServicePrice = item.service.Price
                            });
                        }
                    }
                    return new RepoResponse<List<ScheduleOfPatientModel>> { Status = 1, Data = data };
                }
            }
            catch (Exception e)
            {
                return new RepoResponse<List<ScheduleOfPatientModel>> { Status = 0, Msg = "Lỗi" };
            }
        }
        public async Task<RepoResponse<string>> UpdateSchedule(UpdateScheduleRequest updateSchedule)
        {
            try
            {
                var schedule = new Schedule
                {
                    Id = updateSchedule.Id,
                    DoctorId = updateSchedule.DoctorId,
                    PatientId = updateSchedule.PatientId,
                    ServiceId = updateSchedule.ServiceId,
                    Status = (int)Constants.ScheduleStatus.NOT_CONFIRM,
                    DateTimeStamp = updateSchedule.DateTimeStamp,
                };

                using (var db = new MyDbContext())
                {
                    schedule = await db.Schedules.Where(x => x.Id == updateSchedule.Id).FirstOrDefaultAsync();
                    if (schedule == null)
                    {
                        return new RepoResponse<string> { Status = 0, Msg = "Không tồn tại lịch hẹn này" };
                    }
                    var checkIdDoctor = await db.UserPeoples.Where(x => x.Id == updateSchedule.DoctorId).FirstOrDefaultAsync();
                    var checkIdPatient = await db.UserPeoples.Where(x => x.Id == updateSchedule.PatientId).FirstOrDefaultAsync();
                    var checkIdService = await db.Services.Where(x => x.Id == updateSchedule.ServiceId).FirstOrDefaultAsync();
                    var checkDoctorService = await db.DoctorServices.Where(x => x.ServiceId == updateSchedule.ServiceId && x.UserId == updateSchedule.DoctorId).FirstOrDefaultAsync();
                    if (checkIdDoctor == null)
                    {
                        return new RepoResponse<string> { Status = 0, Msg = " Không có bác sĩ này " };
                    }
                    if (checkIdPatient == null)
                    {
                        return new RepoResponse<string> { Status = 0, Msg = " Không có bệnh nhân này " };
                    }
                    if (checkIdService == null)
                    {
                        return new RepoResponse<string> { Status = 0, Msg = " Không có dịch vụ này " };
                    }
                    if (checkDoctorService == null)
                    {
                        return new RepoResponse<string> { Status = 0, Msg = " Không có bác sĩ dịch vụ này " };
                    }

                    // Id = updateSchedule.Id,
                    schedule.DoctorId = updateSchedule.DoctorId;
                    schedule.PatientId = updateSchedule.PatientId;
                    schedule.ServiceId = updateSchedule.ServiceId;
                    schedule.Status =  (int)updateSchedule.Status;
                    schedule.DateTimeStamp = updateSchedule.DateTimeStamp;

                    db.Schedules.Update(schedule);
                    await db.SaveChangesAsync();
                    return new RepoResponse<string> { Status = 1, Msg = " Cập nhật lịch hẹn thành công " };
                }
            }
            catch (Exception e)
            {
                return new RepoResponse<string> { Status = 0, Msg = " Lỗi " };
            }
        }
        public async Task<RepoResponse<string>> DeleteSchedule(Guid id)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var checkIdSchedule = await db.Schedules.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (checkIdSchedule == null)
                    {
                        return new RepoResponse<string> { Status = 0, Msg = " Không tồn tại lịch hẹn này " };
                    }
                    db.Schedules.Remove(checkIdSchedule);
                    await db.SaveChangesAsync();
                }
                return new RepoResponse<string> { Status = 1, Msg = " Xoá lịch hẹn thành công " };
            }
            catch (Exception e)
            {
                return new RepoResponse<string> { Status = 0, Msg = " Lỗi " };
            }
        }
        public async Task<RepoResponse<ScheduleOfPatientModel>> DetailSchedulePatient(Guid IdShcedule, Guid IdPatient)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var checkIdSchedule = await db.Schedules.Where(x => x.Id == IdShcedule).FirstOrDefaultAsync();
                    var checkIdPatient = await db.UserPeoples.Where(x => x.Id == IdPatient).FirstOrDefaultAsync();
                    if (checkIdSchedule == null)
                    {
                        return new RepoResponse<ScheduleOfPatientModel> { Status = 0, Msg = " Không tồn tại lịch hẹn " };
                    }
                    if (checkIdPatient == null)
                    {
                        return new RepoResponse<ScheduleOfPatientModel> { Status = 0, Msg = " Không tồn tại bệnh nhân " };
                    }
                    var patientScheduleDetail = await db.Schedules.Where(x => x.Id == IdShcedule && x.PatientId == IdPatient).
                        Join(db.UserPeoples,
                             s => s.DoctorId,
                             us => us.Id,
                             (s, us) => new { s, us }).
                        Join(db.Services,
                              a => a.s.ServiceId,
                              b => b.Id,
                              (a, b) => new { a, b })
                        .FirstOrDefaultAsync();
                    if (patientScheduleDetail == null)
                    {
                        return new RepoResponse<ScheduleOfPatientModel> { Status = 0, Msg = " Không có lịch hẹn bệnh nhân này " };
                    }
                    var data = new ScheduleOfPatientModel
                    {
                        Id = IdShcedule,
                        NameDoctor = patientScheduleDetail.a.us.Name,
                        IdDoctor = patientScheduleDetail.a.s.DoctorId,
                        DateTimeStamp = patientScheduleDetail.a.s.DateTimeStamp,
                        ServiceName = patientScheduleDetail.b.Name,
                        ServicePrice = patientScheduleDetail.b.Price
                    };
                    return new RepoResponse<ScheduleOfPatientModel> { Status = 1, Data = data };
                }
            }
            catch (Exception e)
            {
                return new RepoResponse<ScheduleOfPatientModel> { Status = 0, Msg = "Lỗi" };
            }
        }
        public async Task<RepoResponse<ScheduleOfDoctorModel>> DetailScheduleDoctor(Guid IdShcedule, Guid IdDoctor)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var checkIdSchedule = await db.Schedules.Where(x => x.Id == IdShcedule).FirstOrDefaultAsync();
                    var checkIdDoctor = await db.UserPeoples.Where(x => x.Id == IdDoctor).FirstOrDefaultAsync();
                    if (checkIdSchedule == null)
                    {
                        return new RepoResponse<ScheduleOfDoctorModel> { Status = 0, Msg = " Không tồn tại lịch hẹn này " };
                    }
                    if (checkIdDoctor == null)
                    {
                        return new RepoResponse<ScheduleOfDoctorModel> { Status = 0, Msg = " Không có bác sĩ này" };
                    }
                    var doctorScheduleDetail = await db.Schedules.Where(x => x.Id == IdShcedule && x.DoctorId == IdDoctor).
                        Join(db.UserPeoples,
                             s => s.PatientId,
                             us => us.Id,
                             (s, us) => new { s, us }).
                        Join(db.Services,
                              a => a.s.ServiceId,
                              b => b.Id,
                              (a, b) => new { a, b })
                        .FirstOrDefaultAsync();
                    var data = new ScheduleOfDoctorModel
                    {
                        Id = IdShcedule,
                        NamePatient = doctorScheduleDetail.a.us.Name,
                        IdPatient = doctorScheduleDetail.a.s.PatientId,
                        DateTimeStamp = doctorScheduleDetail.a.s.DateTimeStamp,
                        ServiceName = doctorScheduleDetail.b.Name,
                        ServicePrice = doctorScheduleDetail.b.Price
                    };
                    return new RepoResponse<ScheduleOfDoctorModel> { Status = 1, Data = data };
                }
            }
            catch (Exception e)
            {
                return new RepoResponse<ScheduleOfDoctorModel> { Status = 0, Msg = " Lỗi " };
            }
        }
        public async Task<RepoResponse<string>> ConfirmScheduleDoctor(ConfirmScheduleRequestDoctor request)
        {

            try
            {
                using (var db = new MyDbContext())
                {
                    var checkSchedule = await db.Schedules.Where(x => x.Id == request.ScheduleID).FirstOrDefaultAsync();

                    if (checkSchedule == null)
                    {
                        return new RepoResponse<string> { Status = 0, Msg = "Lịch không tồn tại" };
                    }
                    if (checkSchedule.Status == (int)ScheduleStatus.COMFIRM)
                    {
                        return new RepoResponse<string> { Status = 0, Msg = "Lịch đã được xác nhận" };
                    }
                    if (checkSchedule.Status == (int)ScheduleStatus.PAIED)
                    {
                        return new RepoResponse<string> { Status = 0, Msg = "Lịch đã được thanh toán" };
                    }
                    if (checkSchedule.Status == (int)ScheduleStatus.CANCELED)
                    {
                        return new RepoResponse<string> { Status = 0, Msg = "Lịch đã bị huỷ" };
                    }
                    if (request.Status == 1 || request.Status == 3)
                    {
                        checkSchedule.Status = request.Status;
                        db.Schedules.Update(checkSchedule);
                        await db.SaveChangesAsync();
                    }
                    else
                    {
                        return new RepoResponse<string> { Status = 0, Msg = "trạng thái không hợp lệ" };
                    }
                    return new RepoResponse<string> { Status = 1, Msg = "Xác nhận lịch hẹn thành công" };
                }
            }
            catch (Exception e)
            {
                return new RepoResponse<string> { Status = 0, Msg = "Lỗi" };
            }
        }
        public async Task<RepoResponse<string>> CancelSchedulePatient(CancelSchedulePatient request)
        {

            try
            {
                using (var db = new MyDbContext())
                {
                    var checkSchedule = await db.Schedules.Where(x => x.Id == request.ScheduleID).FirstOrDefaultAsync();

                    if (checkSchedule == null)
                    {
                        return new RepoResponse<string> { Status = 0, Msg = "Lịch không tồn tại" };
                    }
                    if (checkSchedule.Status != (int)ScheduleStatus.NOT_CONFIRM)
                    {
                        return new RepoResponse<string> { Status = 0, Msg = "Không được phép huỷ" };
                    }
                    checkSchedule.Status = (int)ScheduleStatus.CANCELED;
                    db.Schedules.Update(checkSchedule);
                    await db.SaveChangesAsync();
                    return new RepoResponse<string> { Status = 1, Msg = "Đã huỷ lịch hẹn thành công" };
                }
            }
            catch (Exception e)
            {
                return new RepoResponse<string> { Status = 0, Msg = "Lỗi" };
            }
        }
        public async Task<RepoResponse<List<CreateScheduleRequest>>> GetListSchedule()
        {
            try
            {
                using (var db = new MyDbContext())
                {

                    var listSchedule = new List<CreateScheduleRequest>();
                    var checkSchedule = await db.Schedules.ToListAsync();
                    if (checkSchedule.Count > 0)
                    {
                        foreach (var item in checkSchedule)
                        {
                            var Schedule = new CreateScheduleRequest
                            {
                                DoctorId = item.DoctorId.ToString(),
                                PatientId = item.PatientId.ToString(),
                                ServiceId = item.ServiceId.ToString(),
                                DateTimeStamp = item.DateTimeStamp,
                                Status = item.Status,
                                Id = item.Id.ToString(),
                            };
                            listSchedule.Add(Schedule);
                        }
                        return new RepoResponse<List<CreateScheduleRequest>> { Status = 1, Data = listSchedule };
                    }
                    return new RepoResponse<List<CreateScheduleRequest>> { Status = 0, Msg = " không có lịch hen nào " };

                }
                return new RepoResponse<List<CreateScheduleRequest>> { Status = 0, Msg = " không có lịch hen nào " };
            }
            catch (Exception e)
            {
                return new RepoResponse<List<CreateScheduleRequest>> { Status = 0, Msg = "Lỗi" };
            }
        }
    }
}
