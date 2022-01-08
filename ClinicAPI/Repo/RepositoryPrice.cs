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
                return new RepoResponse<string> { Status = 1, Msg = "Lỗi" };
            }
        }
        public async Task<RepoResponse<double>> GetSchedulePrice(PriceRequest request)
        {
            try
            {
                using ( var db = new MyDbContext())
                {
                    var checkSchedule = await db.Schedules.Where(x => x.Id == request.Idschedule).FirstOrDefaultAsync();
                    if(checkSchedule==null)
                    {
                        return new RepoResponse<double> { Status = 0, Msg = "Không tồn tại lịch hẹn" };
                    }
                   if(checkSchedule.Status!=2)
                    {
                        return new RepoResponse<double> { Status = 0, Msg = " Lịch hẹn chưa dược thanh toán" };
                    }
                    var getPriceRevenue = await db.Revenues.Where(x => x.ScheduleId == request.Idschedule).FirstOrDefaultAsync();
                    var revenuePrice=getPriceRevenue.Price;
                    var checkPrescription = await db.Prescriptions.Where(x => x.IdSchedule == request.Idschedule).FirstOrDefaultAsync();
                    double MedicinePrice = 0;
                    if (checkPrescription!=null)
                    {
                        var getListMedicineId = await db.PreMedicine.Where(x => x.IdPrescription==checkPrescription.Id).
                            Join(db.medicines,s=>s.IdMedicine,sh=>sh.IdMedicine,(s,sh)=>new {s,sh }).ToListAsync();
                        
                       if(getListMedicineId.Count>0)
                        {
                            foreach (var item in getListMedicineId)
                            {
                                MedicinePrice +=(double) item.s.QuantilyMedicine * Int32.Parse(item.sh.PriceMedicine);
                            }
                        }

                    }
                    return new RepoResponse<double> { Status = 1, Data = revenuePrice + MedicinePrice };
                }
            }
            catch (Exception)
            {

                return new RepoResponse<double> { Status = 0, Msg = " Lỗi" };
            }
        }
        public async Task<RepoResponse<GetInformationPatientModels>> GetInformationPatientPrice(GetInfomationPatientt request)
        {
            try
            {
                using ( var db = new MyDbContext())
                {
                    var checkPatient = await db.UserPeoples.Where(x => x.Id == request.IdPatient).FirstOrDefaultAsync();
                        if(checkPatient==null)
                    {
                        return new RepoResponse<GetInformationPatientModels> { Status = 0, Msg = "Không tồn tại bệnh nhân" };
                    }
                    var checkSchedule = await db.Schedules.Where(x => x.Id == request.IdSchedule).
                        Join(db.Services , s=>s.ServiceId,sh=>sh.Id,(s,sh)=>new { s, sh }).Join(db.UserPeoples,a=>a.s.PatientId,b=>b.Id,(a,b)=>new {a,b}).FirstOrDefaultAsync();
                    if (checkSchedule == null)
                    {
                        return new RepoResponse<GetInformationPatientModels> { Status = 0, Msg = "Không tồn tại lịch hẹn này" };
                    }
                    var checkRevenue = await db.Revenues.Where(x => x.ScheduleId == request.IdSchedule).FirstOrDefaultAsync();
                    var checkPrescription = await db.Prescriptions.Where(x => x.IdSchedule == request.IdSchedule).FirstOrDefaultAsync();
                    var revenuePrice = checkRevenue.Price;
                    var listMedicine = new List<PatientMedicineModels>();
                    double MedicinePrice = 0;
                    if (checkPrescription != null)
                    {
                        var getListMedicineId = await db.PreMedicine.Where(x => x.IdPrescription == checkPrescription.Id).
                            Join(db.medicines, s => s.IdMedicine, sh => sh.IdMedicine, (s, sh) => new { s, sh }).ToListAsync();
                        
                        if (getListMedicineId.Count > 0)
                        {
                            foreach (var item in getListMedicineId)
                            {
                                MedicinePrice += (double)item.s.QuantilyMedicine * Int32.Parse(item.sh.PriceMedicine);
                                var MedicineInfor = new PatientMedicineModels
                                {
                                    NameMedicine = item.sh.NameMedicine,
                                    Quantity = Int32.Parse(item.sh.Quantily),
                                    PriceMedicine = Int32.Parse(item.sh.PriceMedicine),
                                    TotalPrice = Int32.Parse(item.sh.Quantily) * Int32.Parse(item.sh.PriceMedicine)
                                   
                                };
                                listMedicine.Add(MedicineInfor);
                            }
                        }
                    }
                    var InformationPatient = new GetInformationPatientModels
                    {
                        NamePatient = checkSchedule.b.Name,
                        Address = checkSchedule.b.Address,
                        IdentityCard = checkSchedule.b.IdentityCard,
                        Job = checkSchedule.b.Job,
                        Sex = checkSchedule.b.Sex,
                        Phone = checkSchedule.b.Phone,
                        YearOfBirth = checkSchedule.b.YearOfBirth,
                        Service = checkSchedule.a.sh.Name,
                        PriceService = checkSchedule.a.sh.Price,
                        TimeStampPaid = checkRevenue.Time,
                        NamePrescription = checkPrescription.Name,
                        TimeStampSchedule = checkSchedule.a.s.DateTimeStamp,
                        PriceSchedule = MedicinePrice + revenuePrice,
                        Medicine = listMedicine
                    };
                    return new RepoResponse<GetInformationPatientModels> { Status = 1, Data = InformationPatient };
                }
            }
            catch (Exception)
            {

                return new RepoResponse<GetInformationPatientModels> { Status = 0, Msg =" Lỗi" };
            }
        }
    }
}
