﻿using ClinicAPI.Entity;
using ClinicAPI.Models;
using ClinicAPI.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Repo
{
    public class RepositoryMedicine
    {
        public async Task<RepoResponse<Guid>> CreateMedicine(CreateMedicineRequest request)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var checkUser = await db.medicines.Where(x => x.NameMedicine == request.NameMedicine).FirstOrDefaultAsync();
                    if (checkUser != null)
                    {
                        return new RepoResponse<Guid> { Status = 0, Msg = " Đã tồn tại thuốc này " };
                    }
                    var insertMedicine = new Medicine
                    {
                        IdMedicine = Guid.NewGuid(),
                        NameMedicine = request.NameMedicine,
                        PriceMedicine = request.PriceMedicine,
                        Quantily = request.Quantily,
                        Unit = request.Unit,
                        UseMedicine = request.UseMedicine
                    };
                    db.medicines.Add(insertMedicine);
                    await db.SaveChangesAsync();
                    return new RepoResponse<Guid> { Status = 1, Msg = " Tạo Medicine thành công ", Data = insertMedicine.IdMedicine };
                }
            }
            catch (Exception e)
            {
                return new RepoResponse<Guid> { Status = 0, Msg = " Lỗi " };
            }
        }
        public async Task<RepoResponse<MedicineModels>> GetMedicineInfo(Guid id)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var MedicineInfor = await db.medicines.Where(x => x.IdMedicine == id).FirstOrDefaultAsync();
                    if (MedicineInfor != null)
                    {
                        var data = new MedicineModels
                        {
                            IdMedicine = id,
                            NameMedicine = MedicineInfor.NameMedicine,
                            UseMedicine = MedicineInfor.UseMedicine,
                            Quantily = MedicineInfor.Quantily.ToString(),
                            Unit = MedicineInfor.Unit,
                            PriceMedicine = MedicineInfor.PriceMedicine
                        };
                        return new RepoResponse<MedicineModels> { Status = 1, Data = data };
                    }
                    return new RepoResponse<MedicineModels> { Status = 0, Msg = " Không tồn tại thuốc này " };
                }
            }
            catch (Exception e)
            {
                return new RepoResponse<MedicineModels> { Status = 0, Msg = " Lỗi " };
            }
        }
        public async Task<RepoResponse<string>> UpdateMedicine(UpdateMedicineRequest request)
        {
            try
            {
                using (var db = new MyDbContext())
                {

                    var Medicine_ = new Medicine
                    {
                        IdMedicine = request.IdMedicine,
                        NameMedicine = request.NameMedicine,
                        PriceMedicine = request.PriceMedicine,
                        Quantily = request.Quantily,
                        Unit = request.Unit,
                        UseMedicine = request.UseMedicine
                    };
                    Medicine_ = await db.medicines.Where(x => x.IdMedicine == request.IdMedicine).FirstOrDefaultAsync();
                    if (Medicine_ != null)
                    {
                        Medicine_.NameMedicine = request.NameMedicine;
                        Medicine_.PriceMedicine = request.PriceMedicine;
                        Medicine_.Quantily = request.Quantily;
                        Medicine_.Unit = request.Unit;
                        db.medicines.Update(Medicine_);
                        await db.SaveChangesAsync();
                    }
                    return new RepoResponse<string> { Status = 0, Msg = "Sửa thông tin thuốc thành công" };
                }
            }

            catch (Exception e)
            {
                return new RepoResponse<string> { Status = 0, Msg = " Lỗi " };
            }
        }
        public async Task<RepoResponse<string>> DeleteMedicine(Guid id)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var RemoveMedicine = await db.medicines.Where(x => x.IdMedicine == id).FirstOrDefaultAsync();
                    if (RemoveMedicine != null)
                    {
                        db.medicines.Remove(RemoveMedicine);
                        await db.SaveChangesAsync();
                    }
                    return new RepoResponse<string> { Status = 0, Msg = " Xóa thuốc thành công " };
                }
            }
            catch (Exception)
            {
                return new RepoResponse<string> { Status = 0, Msg = " Lỗi " };
            }
        }
        public async Task<RepoResponse<List<MedicineModels>>> GetListMedicine()
            {
            try
            {
                using (var db = new MyDbContext())
                {
                    var listMedicine = new List<MedicineModels>();
                    var listMidecineInfor = await db.medicines.ToListAsync();
                    if(listMidecineInfor.Count>0)
                    {
                        foreach (var item in listMidecineInfor)
                        {
                            var MedicineModel = new MedicineModels
                            {
                                IdMedicine = (Guid)item.IdMedicine,
                                NameMedicine = item.NameMedicine,
                                PriceMedicine = item.PriceMedicine,
                                Quantily = item.Quantily,
                                Unit = item.Unit,
                                UseMedicine = item.UseMedicine
                            };
                            listMedicine.Add(MedicineModel);
                        }
                        return new RepoResponse<List<MedicineModels>> { Status = 1, Data=listMedicine };
                    }
                    return new RepoResponse<List<MedicineModels>> { Status = 0, Msg = " Không có thuốc nào " };
                }
            }
            catch (Exception)
            {
                return new RepoResponse<List<MedicineModels>> { Status = 0, Msg = " Lỗi " };
            }
        }
    }
}
