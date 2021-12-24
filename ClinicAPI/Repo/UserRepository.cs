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
    public class UserRepository
    {
        public async Task<RepoResponse<string>> Create(CreatUserRequest request )
        {
            try
            {

               
                using (var db = new MyDbContext())
                {
                   var checkUser = await db.UserPeoples.Where(x => x.UserName == request.Username).FirstOrDefaultAsync();
                    if(checkUser != null)
                    {
                        return new RepoResponse<string> {Status = 0 , Msg = " Đã tồn tại bệnh nhân " };
                    }
                    var insertUser = new UserPeople
                    {
                        Id = Guid.NewGuid(),
                        Name = request.Name,
                        Sex = request.Sex,
                        YearOfBirth = request.YearOfBirth,
                        Phone = request.Phone,
                        Address = request.Address,
                        UserName = request.Username,
                        PassWord = request.Password
                    };
                    db.UserPeoples.Add(insertUser);
                   await db.SaveChangesAsync();
                   return new RepoResponse<string> { Status = 1, Msg = " Tạo User thành công " };
                }
            }
            catch (Exception e )
            {
                return new RepoResponse<string> { Status = 0, Msg = " Lỗi " };
            }
        }
        public async Task <RepoResponse<UserModels>> GetUserInfo(Guid id)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var UserInfor =await db.UserPeoples.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (UserInfor != null)
                    {
                        var data = new UserModels
                        {
                            Id = id,
                            Name = UserInfor.Name,
                            PassWord=UserInfor.PassWord,
                            UserName=UserInfor.UserName
                        };
                        return new RepoResponse<UserModels> { Status = 1, Data = data };
                    }
                    return new RepoResponse<UserModels> { Status = 0, Msg = " Không tồn tại người dùng này " };
                }
            }
            catch (Exception e)
            {
                return new RepoResponse<UserModels> { Status = 0, Msg = " Lỗi " };
            }
        }
        public async Task <RepoResponse<string>> UpdateUser(UpdateUserRequest request)
        {
            try
            {
                var User = new UserPeople
                {
                    Id = request.Id,
                    Name = request.Name,
                    Sex = request.Sex,
                    YearOfBirth = request.YearOfBirth,
                    Address= request.Address,
                    Phone= request.Phone,
                };
                using (var db = new MyDbContext())
                {
                    User =await db.UserPeoples.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                    if (User != null)
                    {
                        User.Name = request.Name;
                        User.Sex = request.Sex;
                        User.YearOfBirth = request.YearOfBirth;
                        User.Address = request.Address;
                        User.Phone = request.Phone;
                        db.UserPeoples.Update(User);
                        await db.SaveChangesAsync();
                    }
                    return new RepoResponse<string> {Status = 0 ,Msg = " Không có người dùng này " };
                }
            }
            
            catch (Exception e)
            {
                return new RepoResponse<string> { Status = 0, Msg = " Lỗi " };
            }
        }
        public async Task <RepoResponse<string>> DeleteUser(Guid id)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var RemoveUser = await db.UserPeoples.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (RemoveUser != null)
                    {
                        db.UserPeoples.Remove(RemoveUser);
                        await db.SaveChangesAsync();
                    }
                    return new RepoResponse<string> {Status = 0 ,Msg = " Không tồn tại người dùng " }  ;
                } 
            }
            catch (Exception)
            {
                return new RepoResponse<string> { Status = 0, Msg = " Lỗi " };
            }
        }
        public async Task<RepoResponse<string>> AddUserRole(Guid UserId , Guid RoleId)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var user = await db.UserPeoples.Where(x => x.Id == UserId).FirstOrDefaultAsync();
                    var role = await db.Roles.Where(x => x.Id == RoleId).FirstOrDefaultAsync();

                    if (user == null )
                    {
                        return new RepoResponse<string> {Status = 0 , Msg = " Không tồn tại người dùng " };
                    }
                    if ( role == null)
                    {
                        return new RepoResponse<string> { Status = 0, Msg = " Không tồn tại quyền " };
                    }

                    var userRole = db.UserRoles.Where(x => x.UserId == UserId && x.RoleId == RoleId).FirstOrDefault();
                    if (userRole == null)
                    {
                        var newUserRole = new UserRole()
                        {
                            Id = Guid.NewGuid(),
                            RoleId = RoleId,
                            UserId = UserId
                        };
                        db.UserRoles.Add(newUserRole);
                        await db.SaveChangesAsync();
                    }
                    return new RepoResponse<string> { Status = 0, Msg = " Đã tồn tại " };
                }
            }
            catch (Exception)
            {

                return new RepoResponse<string> { Status = 0, Msg = " Đã tồn tại " };
            }
        }
        public async Task<RepoResponse<List<UserModels>>> GetUserRole(Guid idRole)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var listUser = new List<UserModels>();
                    var userRole = await db.UserRoles.Where(x => x.RoleId == idRole)
                         .Join(db.UserPeoples,
                         ur => ur.UserId,
                         s => s.Id,
                         (cs, s) => new { s }).ToListAsync();

                    if (userRole.Count() > 0)
                    {
                        foreach (var item in userRole)
                        {
                            listUser.Add(new UserModels
                            {
                                Name = item.s.Name,
                                Id = item.s.Id,
                                PassWord = item.s.PassWord,
                                UserName = item.s.UserName
                            });
                        }
                    }
                    return new RepoResponse<List<UserModels>> {Status =1 , Data =listUser };
                }
            }
            catch (Exception e)
            {
                return new RepoResponse<List<UserModels>> { Status = 0, Msg = " Lỗi " };
            }
        }
        public async Task<RepoResponse<string>>AddServiceToDoctor(Guid DoctorId,Guid ServiceId)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var user = await db.UserPeoples.Where(x => x.Id == DoctorId).FirstOrDefaultAsync();
                    var service = await db.Services.Where(x => x.Id == ServiceId).FirstOrDefaultAsync();

                    if (user == null )
                    {
                        return new RepoResponse<string> {Status = 0 , Msg = " Không đúng người dùng " };
                    }
                    if ( service == null)
                    {
                        return new RepoResponse<string> { Status = 0, Msg = " Không đúng dịch vụ " };
                    }
                    var doctorService = await db.DoctorServices.Where(x => x.ServiceId == ServiceId && x.UserId == DoctorId).FirstOrDefaultAsync();
                    if (doctorService == null)
                    {
                        var newDoctorService = new DoctorService()
                        {
                            Id = Guid.NewGuid(),
                            UserId = DoctorId,
                            ServiceId = ServiceId
                        };
                        db.DoctorServices.Add(newDoctorService);
                        await db.SaveChangesAsync();
                    }
                    return new RepoResponse<string> { Status = 0, Msg = " Dịch vụ đã tồn tại " };
                }
            }
            catch (Exception e)
            {
                return new RepoResponse<string> { Status = 0, Msg = " Lỗi " };
            }
        }
        public async Task<RepoResponse<List<DoctorModels>>> GetDoctorOfServices(Guid ServiceId)
        {
            try
            {
                using( var db = new MyDbContext())
                {
                    var listDoctorService = new List<DoctorModels>();
                    var listDoctorOfServices = await db.DoctorServices.Where(x => x.ServiceId == ServiceId).
                        Join(db.UserPeoples, du => du.UserId, u => u.Id, (du, u) => new {du,u})
                        .ToListAsync();
                    if(listDoctorOfServices.Count>0)
                    {
                        foreach (var item in listDoctorOfServices)
                        {
                            var doctorModels = new DoctorModels { Id = item.du.UserId, NameDoctor = item.u.Name };
                            listDoctorService.Add(doctorModels);
                        }
                        return new RepoResponse<List<DoctorModels>> { Status = 1 , Data = listDoctorService };
                    }
                    return new RepoResponse<List<DoctorModels>> { Status = 0, Msg = " Không có bác sĩ nào  "};
                }
            }
            catch (Exception)
            {

                return new RepoResponse<List<DoctorModels>> { Status = 0, Msg = " Lỗi " };
            }
        }
        public async Task<RepoResponse<List<UserInfomation>>> GetUser(GetUserByRoleRequest request)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var checkRole = await db.Roles.Where(x => x.Code == request.Code).FirstOrDefaultAsync();
                    if(checkRole == null )
                    {
                        return new RepoResponse<List<UserInfomation>> { Status = 0, Msg = "Không tìm thấy quyền " };
                    }
                    var data = new List<UserInfomation>();
                    var getUserRoleDb = db.UserRoles.Where(x => x.RoleId == checkRole.Id)
                        .Join(db.UserPeoples,s=>s.UserId,a=>a.Id,(s,a)=>new {s,a});
                    if(!string.IsNullOrEmpty(request.KeyWord))
                    {
                        getUserRoleDb = getUserRoleDb.Where(x => x.a.UserName.Contains(request.KeyWord)||x.a.Name.Contains(request.KeyWord)
                        ||x.a.Phone.Contains(request.KeyWord));
                    }
                    var getUserId = await getUserRoleDb.ToListAsync();
                    if (getUserId.Count()>0)
                    {
                        foreach (var item in getUserId)
                        {
                            data.Add(new UserInfomation
                            {
                                Id=item.s.UserId,
                                Address=item.a.Address,
                                Name=item.a.Name,
                                Phone= item.a.Phone,
                                Sex=item.a.Sex,
                                YearOfBirth=item.a.YearOfBirth
                            });
                        }
                    }
                    return new RepoResponse<List<UserInfomation>> { Status = 1, Data=data };

                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
