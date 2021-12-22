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
    public class RepositoryPrice
    {

        public async Task<RepoResponse<string>> SchedulePayment(CreatPayment request)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var checkSchedule = await db.Schedules.Where(x => x.Id == request.ScheduleId).
                        Join(db.Services, sh => sh.ServiceId, sv => sv.Id, (sh, sv) =>new {sh,sv}).FirstOrDefaultAsync();

                    if(checkSchedule == null)
                    {
                        return new RepoResponse<string> { Status = 0, Msg = "Không tồn tại lịch hẹn" };
                    }
                    if(checkSchedule.sh.Status != 1)
                    {
                        return new RepoResponse<string> { Status = 0, Msg = "Lịch hẹn chưa được xác nhận" };
                    }

                    var payment = new Revenue
                    {
                        Id = new Guid(),
                        ScheduleId = request.ScheduleId,
                        Price = checkSchedule.sv.Price,
                        Time = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
                    };
                    var schedule = checkSchedule.sh;
                    schedule.Status =(int) ScheduleStatus.PAIED;
                    db.Revenues.Add(payment);
                    db.Schedules.Update(schedule);
                    await db.SaveChangesAsync();
                }
                return new RepoResponse<string> { Status = 1, Msg = "Không tồn tại lịch hẹn" };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
