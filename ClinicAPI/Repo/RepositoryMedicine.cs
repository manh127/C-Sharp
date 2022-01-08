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
    public class RepositoryMedicine
    {
        public async Task<RepoResponse<Guid>> CreateMedicine(CreateMedicineRequest request)
        {
            try
            {
                using (var db = new MyDbContext())
                {
<<<<<<< HEAD
                    var checkUser = await db.medicines.Where(x => x.NameMedicine == request.NameMedicine).FirstOrDefaultAsync();
=======
                    var checkUser = await db.Prescriptions.Where(x => x.NameMedicine == request.NameMedicine).FirstOrDefaultAsync();
>>>>>>> 38e20eabbc43b4bb1c7983053b97dcf501223b5b
                    if (checkUser != null)
                    {
                        return new RepoResponse<Guid> { Status = 0, Msg = " Đã tồn tại thuốc này " };
                    }
<<<<<<< HEAD
                    var insertMedicine = new Medicine
=======
                    var insertMedicine = new Prescription
>>>>>>> 38e20eabbc43b4bb1c7983053b97dcf501223b5b
                    {
                        IdMedicine = Guid.NewGuid(),
                        NameMedicine = request.NameMedicine,
                        PriceMedicine = request.PriceMedicine,
                        Quantily = request.Quantily,
                        Unit = request.Unit,
                        UseMedicine = request.UseMedicine
                    };
<<<<<<< HEAD
                    db.medicines.Add(insertMedicine);
=======
                    db.Prescriptions.Add(insertMedicine);
>>>>>>> 38e20eabbc43b4bb1c7983053b97dcf501223b5b
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
<<<<<<< HEAD
                    var MedicineInfor = await db.medicines.Where(x => x.IdMedicine == id).FirstOrDefaultAsync();
=======
                    var MedicineInfor = await db.Prescriptions.Where(x => x.IdMedicine == id).FirstOrDefaultAsync();
>>>>>>> 38e20eabbc43b4bb1c7983053b97dcf501223b5b
                    if (MedicineInfor != null)
                    {
                        var data = new MedicineModels
                        {
                            IdMedicine = id,
                            NameMedicine = MedicineInfor.NameMedicine,
                            UseMedicine = MedicineInfor.UseMedicine,
<<<<<<< HEAD
                            Quantily = MedicineInfor.Quantily.ToString(),
=======
                            Quantily = MedicineInfor.Quantily,
>>>>>>> 38e20eabbc43b4bb1c7983053b97dcf501223b5b
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

<<<<<<< HEAD
                    var Medicine_ = new Medicine
=======
                    var Medicine = new Prescription
>>>>>>> 38e20eabbc43b4bb1c7983053b97dcf501223b5b
                    {
                        IdMedicine = request.IdMedicine,
                        NameMedicine = request.NameMedicine,
                        PriceMedicine = request.PriceMedicine,
                        Quantily = request.Quantily,
                        Unit = request.Unit,
                        UseMedicine = request.UseMedicine
                    };
<<<<<<< HEAD
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
=======
                    Medicine = await db.Prescriptions.Where(x => x.IdMedicine == request.IdMedicine).FirstOrDefaultAsync();
                    if (Medicine != null)
                    {
                        Medicine.NameMedicine = request.NameMedicine;
                        Medicine.PriceMedicine = request.PriceMedicine;
                        Medicine.Quantily = request.Quantily;
                        Medicine.Unit = request.Unit;
                        db.Prescriptions.Update(Medicine);
                        await db.SaveChangesAsync();
                    }
                    return new RepoResponse<string> { Status = 0, Msg = " Không tồn tại loại thuốc này " };
>>>>>>> 38e20eabbc43b4bb1c7983053b97dcf501223b5b
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
<<<<<<< HEAD
                    var RemoveMedicine = await db.medicines.Where(x => x.IdMedicine == id).FirstOrDefaultAsync();
                    if (RemoveMedicine != null)
                    {
                        db.medicines.Remove(RemoveMedicine);
                        await db.SaveChangesAsync();
                    }
                    return new RepoResponse<string> { Status = 0, Msg = " Xóa thuốc thành công " };
=======
                    var RemoveMedicine = await db.Prescriptions.Where(x => x.IdMedicine == id).FirstOrDefaultAsync();
                    if (RemoveMedicine != null)
                    {
                        db.Prescriptions.Remove(RemoveMedicine);
                        await db.SaveChangesAsync();
                    }
                    return new RepoResponse<string> { Status = 0, Msg = " Không tồn tại thuốc này " };
>>>>>>> 38e20eabbc43b4bb1c7983053b97dcf501223b5b
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
<<<<<<< HEAD
                    var listMidecineInfor = await db.medicines.ToListAsync();
=======
                    var listMidecineInfor = await db.Prescriptions.ToListAsync();
>>>>>>> 38e20eabbc43b4bb1c7983053b97dcf501223b5b
                    if(listMidecineInfor.Count>0)
                    {
                        foreach (var item in listMidecineInfor)
                        {
                            var MedicineModel = new MedicineModels
                            {
<<<<<<< HEAD
                                IdMedicine = (Guid)item.IdMedicine,
=======
                                IdMedicine = item.IdMedicine,
>>>>>>> 38e20eabbc43b4bb1c7983053b97dcf501223b5b
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
