using ClinicAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAPI.Request;
using ClinicAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Repo
{
    public class RepositoryPrescription
    {
        public async Task<RepoResponse<Guid>> CreatePrescription(CreatePrescriptionRequest request)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    if (request.IdSchedule != null)
                    {
                        var checkSchedule = await db.Schedules.Where(x => x.Id == request.IdSchedule).FirstOrDefaultAsync();
                        if (checkSchedule == null)
                        {
                            return new RepoResponse<Guid> { Status = 0, Msg = "Không tồn tại lịch khám" };
                        }
                    }
                   
                    var listIdMedicine = request.Medicines.Select(x => x.IdMedicine).ToList();
                    var checkMedicine = await db.Prescriptions.Where(x => listIdMedicine.Contains(x.IdMedicine)).ToListAsync();
                    if(checkMedicine.Count()!=listIdMedicine.Count())
                    {
                        return new RepoResponse<Guid> { Status = 0,Msg =" Có thuốc không tồn tại " };
                    }
                        var prescriptions = new Prescription
                        {
                            IdSchedule=request.IdSchedule,
                            Id =  Guid.NewGuid(),
                            Code = request.Code,
                            Name = request.Name,
                            TimeStamp = request.TimeStamp
                        };
                        var listInsertMedicinePrescription = new List<MedicinePrescription>();
                        foreach (var item in request.Medicines)
                        {
                            var medicinePre = new MedicinePrescription
                            {
                                IdMedicine = item.IdMedicine,
                                QuantilyMedicine = item.QuantilyMedicine,
                                Id =Guid.NewGuid(),
                                IdPrescription = prescriptions.Id
                            };
                            listInsertMedicinePrescription.Add(medicinePre);
                        }
                        db.PreMedicine.AddRange(listInsertMedicinePrescription);
                        db.MedicinePrescriptions.Add(prescriptions);
                        await db.SaveChangesAsync();
                        return new RepoResponse<Guid> { Status = 1, Data = prescriptions.Id };
                    
                }
            }
            catch (Exception e )
            {
                return new RepoResponse<Guid> { Status = 0, Msg = "Lỗi"};
            }
        }
        public async Task<RepoResponse<List<GetPrescription>>> GetPrescription(GetPrescriptionByKeyWordRequest request)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var data = new List<GetPrescription>();
                    var getPrescriptionDb = db.MedicinePrescriptions.Where(x => 1 == 1);
                    if (!string.IsNullOrEmpty(request.KeyWord))
                    {
                        getPrescriptionDb = getPrescriptionDb.Where(x => x.Code.Contains(request.KeyWord) || x.Name.Contains(request.KeyWord));
                    }
                    if(request.BySchedule!=null)
                    {
                        if( request.BySchedule == 1)
                        {
                            getPrescriptionDb = getPrescriptionDb.Where(x => x.IdSchedule != null); 
                        }
                        if(request.BySchedule==0)
                        {
                            getPrescriptionDb = getPrescriptionDb.Where(x => x.IdSchedule == null);
                        }
                    }
                    var getListPrescription = await getPrescriptionDb.ToListAsync();
                    if(getListPrescription.Count()>0)
                    {
                        foreach (var item in getListPrescription)
                        {
                            data.Add(new GetPrescription
                            {
                                Id = item.Id,
                                Name = item.Name,
                                Code = item.Code,
                                TimeStamp = item.TimeStamp
                            });
                        }
                    }
                    return new RepoResponse<List<GetPrescription>> { Status = 1, Data = data };
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<RepoResponse<GetDetailPrescription>> GetDetailPrescription(Guid Id)
        {
            try
            {
                using (var db = new MyDbContext())
                {

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
