using ClinicAPI.Entity;
using ClinicAPI.Models;
using ClinicAPI.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Repo
{
    public class ScheduleRepository
    {
        public async Task<bool> CreateSchedule(CreateScheduleRequest scheduleRequest)
        {
            try
            {
                using (var db = new MyDbContext())
                {

                    var checkDoctor = await db.UserPeoples.Where(x => x.Id ==scheduleRequest.DoctorId).FirstOrDefaultAsync();
                    var checkPatient = await db.UserPeoples.Where(x => x.Id == scheduleRequest.PatientId).FirstOrDefaultAsync();
                    var checkService = await db.Services.Where(x => x.Id== scheduleRequest.ServiceId).FirstOrDefaultAsync();
                    var checkDoctorService = await db.DoctorServices.Where(x => x.UserId == scheduleRequest.DoctorId && x.ServiceId == scheduleRequest.ServiceId).FirstOrDefaultAsync();
                    
                    if (checkDoctor == null || checkPatient == null || checkService ==null||checkDoctorService==null)
                    {
                        return false;
                    }
                    var schedule = new Schedule
                    {
                        Id = Guid.NewGuid(),
                        DateTimeStamp = scheduleRequest.DateTimeStamp,
                        DoctorId = scheduleRequest.DoctorId,
                        PatientId = scheduleRequest.PatientId,
                        Status =(int)Constants.ScheduleStatus.NOT_CONFIRM,
                        ServiceId= scheduleRequest.ServiceId
                    };
                    db.Schedules.Add(schedule);
                    await db.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public async Task<List<ScheduleOfDoctorModel>> GetScheduleOfDoctor(Guid idDoctor,int? status)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var getDoctor = await db.UserPeoples.Where(x => x.Id == idDoctor).FirstOrDefaultAsync();
                    if (getDoctor == null)
                    {
                        return null;
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
                    return data;

                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<List<ScheduleOfPatientModel>> GetScheduleOfPatient(Guid idPatient, int? status)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var getPatient = await db.UserPeoples.Where(x => x.Id == idPatient).FirstOrDefaultAsync();
                    if (getPatient == null)
                    {
                        return null;
                    }
                    var listSchedulePatientDb =db.Schedules.Where(x => x.PatientId == idPatient);
                    if (status != null)
                    {
                        listSchedulePatientDb = listSchedulePatientDb.Where(x => x.Status == status);
                    }
                    var listSchedulePatient= await listSchedulePatientDb
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
                                IdDoctor=item.sh.s.DoctorId,
                                NameDoctor=item.sh.us.Name,
                                DateTimeStamp=item.sh.s.DateTimeStamp,
                                ServiceName=item.service.Name,
                                ServicePrice=item.service.Price
                            });
                        }
                    }
                    return data;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<bool> UpdateSchedule( UpdateScheduleRequest updateSchedule)
        {
            try
            {
                using ( var db = new MyDbContext())
                {
                    var checkIdSchedule = await db.Schedules.Where(x => x.Id == updateSchedule.Id).FirstOrDefaultAsync();
                    if(checkIdSchedule ==null )
                    {
                        return false;
                    }
                    var checkIdDoctor = await db.UserPeoples.Where(x => x.Id == updateSchedule.DoctorId).FirstOrDefaultAsync();
                    var checkIdPatient = await db.UserPeoples.Where(x => x.Id == updateSchedule.PatientId).FirstOrDefaultAsync();
                    var checkIdService = await db.Services.Where(x => x.Id == updateSchedule.ServiceId).FirstOrDefaultAsync();
                    var checkDoctorService = await db.DoctorServices.Where(x => x.ServiceId == updateSchedule.ServiceId && x.UserId == updateSchedule.DoctorId).FirstOrDefaultAsync();
                    if (checkIdDoctor == null || checkIdPatient == null || checkIdService == null || checkDoctorService == null)
                    {
                        return false;
                    }
                    var schedule = new Schedule
                    {
                        Id = updateSchedule.Id,
                        DoctorId=updateSchedule.DoctorId,
                        PatientId= updateSchedule.PatientId,
                        ServiceId=updateSchedule.ServiceId,
                        DateTimeStamp=updateSchedule.DateTimeStamp,
                    };
                    db.Schedules.Update(schedule);
                    await db.SaveChangesAsync();
                }
                return true;
            }

            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<bool>DeleteSchedule(Guid id)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var checkIdSchedule = await db.Schedules.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (checkIdSchedule == null)
                    {
                        return false;
                    }
                    db.Schedules.Remove(checkIdSchedule);
                    await db.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<ScheduleOfPatientModel>DetailSchedulePatient(Guid IdShcedule,Guid IdPatient)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var checkIdSchedule = await db.Schedules.Where(x => x.Id == IdShcedule).FirstOrDefaultAsync();
                    var checkIdPatient = await db.UserPeoples.Where(x => x.Id == IdPatient).FirstOrDefaultAsync();
                    if(checkIdSchedule==null || checkIdPatient ==null)
                    {
                        return null;
                    }
                    var patientScheduleDetail = await db.Schedules.Where(x => x.Id == IdShcedule&&x.PatientId==IdPatient).
                        Join(db.UserPeoples,
                             s=>s.DoctorId,
                             us=>us.Id,
                             (s, us) =>new { s,us}).
                        Join(db.Services,
                              a=>a.s.ServiceId,
                              b=>b.Id,
                              (a, b) => new {a,b})
                        .FirstOrDefaultAsync();
                    if(patientScheduleDetail==null)
                    {
                        return null;
                    }
                    var data = new ScheduleOfPatientModel
                    {
                        Id=IdShcedule,
                        NameDoctor=patientScheduleDetail.a.us.Name,
                        IdDoctor=patientScheduleDetail.a.s.DoctorId,
                        DateTimeStamp=patientScheduleDetail.a.s.DateTimeStamp,
                        ServiceName=patientScheduleDetail.b.Name,
                        ServicePrice=patientScheduleDetail.b.Price
                    };
                    return data; 
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public async Task<ScheduleOfDoctorModel> DetailScheduleDoctor(Guid IdShcedule, Guid IdDoctor)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var checkIdSchedule = await db.Schedules.Where(x => x.Id == IdShcedule).FirstOrDefaultAsync();
                    var checkIdDoctor = await db.UserPeoples.Where(x => x.Id == IdDoctor).FirstOrDefaultAsync();
                    if (checkIdSchedule == null || checkIdDoctor == null)
                    {
                        return null;
                    }
                    var doctorScheduleDetail = await db.Schedules.Where(x => x.Id == IdShcedule && x.DoctorId==IdDoctor).
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
                    return data;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
