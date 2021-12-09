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
                    var doctor = await db.UserPeoples.Where(x => x.Id == DoctorId).FirstOrDefaultAsync();
                    var patient = await db.UserPeoples.Where(x => x.Id == PatientId).FirstOrDefaultAsync();
                    var services = await db.Services.Where(x => serviceIds.Contains(x.Id)).ToListAsync();
                    
                    if (doctor == null || patient == null||services.Count()==0)
                    {
                        return false;
                    }
                    
                    var schedule = new Schedule()
                    {
                        Id = Guid.NewGuid(),
                        DoctorId = DoctorId,
                        PatientId = PatientId,
                        DateTimeStamp = DateTimeStamp,
                        Status=Status
                    };
                    var scheduleServices = new List<ScheduleService>();
                    foreach (var serviceId in serviceIds)
                    {
                        scheduleServices.Add(new ScheduleService
                        {
                            Id = Guid.NewGuid(),
                            ScheduleId = schedule.Id,
                            ServiceId = serviceId
                        });
                    }
                    db.Schedules.Add(schedule);
                    db.scheduleServices.AddRange(scheduleServices);
                    await db.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
       /* public async Task<ServiceModels> GetServiceInfo(Guid id)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var ServiceInfor = await db.Services.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (ServiceInfor != null)
                    {
                        return new ServiceModels
                        {
                            Id = id,
                            Name = ServiceInfor.Name,
                            Price = ServiceInfor.Price
                        };
                    }
                    return null;
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
        }*/
    }
}
