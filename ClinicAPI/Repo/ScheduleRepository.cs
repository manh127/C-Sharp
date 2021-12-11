using ClinicAPI.Entity;
using ClinicAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Repo
{
    public class ScheduleRepository
    {
        public async Task<bool> CreateSchedule(Guid DoctorId, Guid PatientId, long DateTimeStamp, int Status,List<Guid> serviceIds)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var checkDoctor = await db.UserPeoples.Where(x => x.Id == DoctorId).FirstOrDefaultAsync();
                    var checkPatient = await db.UserPeoples.Where(x => x.Id == PatientId).FirstOrDefaultAsync();
                    var checkService = await db.Services.Where(x => serviceIds.Contains(x.Id)).ToListAsync();
                    if (checkDoctor == null || checkPatient == null || serviceIds.Count == 0)
                    {
                        return false;
                    }
                    var schedule = new Schedule
                    {
                        Id = new Guid(),
                        DateTimeStamp = DateTimeStamp,
                        DoctorId = DoctorId,
                        PatientId = PatientId,
                        Status = Status
                    };
                    var scheduleService = new List<ScheduleService>();
                    foreach (var item in serviceIds)
                    {
                        scheduleService.Add(new ScheduleService
                        {
                            Id = new Guid(),
                            ServiceId = item,
                            ScheduleId = schedule.Id
                        });
                    }
                    db.Schedules.Add(schedule);
                    db.scheduleServices.AddRange(scheduleService);
                    await db.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public async Task<List<ScheduleOfDoctorModel>> GetScheduleOfDoctor(Guid idDoctor)
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
                    var listScheduleDoctor = await db.Schedules.Where(x => x.DoctorId == idDoctor)
                        .Join(db.UserPeoples, s => s.PatientId, us=> us.Id, (s,us ) => new { s,us })
                        .ToListAsync();
                    var data = new List<ScheduleOfDoctorModel>();
                    if(listScheduleDoctor.Count()>0)
                    {
                        foreach (var item in listScheduleDoctor)
                        {
                            data.Add(new ScheduleOfDoctorModel{
                               Id=item.s.Id ,
                               DateTimeStamp= item.s.DateTimeStamp,
                               IdPatient= item.s.PatientId,
                               NamePatient=item.us.Name
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
        public async Task<bool> UpdateService(Guid id, string name, string price)
        {
            try
            {
                var service = new Service
                {
                    Id = id,
                    Name = name,
                    Price = price
                };
                using (var db = new MyDbContext())
                {
                    service = await db.Services.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (service != null)
                    {
                        service.Name = name;
                        service.Price = price;
                        db.Services.Update(service);
                        await db.SaveChangesAsync();
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }

            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<bool> DeleteService(Guid id)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var RemoveService = await db.Services.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (RemoveService == null)
                    {
                        return false;
                    }
                    else
                    {
                        db.Services.Remove(RemoveService);
                        await db.SaveChangesAsync();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
