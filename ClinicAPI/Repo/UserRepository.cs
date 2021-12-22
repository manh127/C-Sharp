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
        public async Task<bool> Create(string name, string sex, int yearOfBirth, string phone , string address,string username, string password )
        {
            try
            {

               
                using (var db = new MyDbContext())
                {
                   var checkUser = await db.UserPeoples.Where(x => x.UserName == username).FirstOrDefaultAsync();
                    if(checkUser != null)
                    {
                        return false;
                    }

                    var insertUser = new UserPeople
                    {
                        Id = Guid.NewGuid(),
                        Name = name,
                        Sex = sex,
                        YearOfBirth = yearOfBirth,
                        Phone = phone,
                        Address = address,
                        UserName = username,
                        PassWord = password
                    };
                    db.UserPeoples.Add(insertUser);
                   await db.SaveChangesAsync();

                }
                return true;
            }
            catch (Exception e )
            {
                return false;
            }
        }
        public async Task <UserModels> GetUserInfo(Guid id)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var UserInfor =await db.UserPeoples.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (UserInfor != null)
                    {
                        return new UserModels
                        {
                            Id = id,
                            Name = UserInfor.Name,
                            PassWord=UserInfor.PassWord,
                            UserName=UserInfor.UserName
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
        public async Task <bool> UpdateUser(Guid id, string name, string sex, int yearOfBirth, string address, string phone)
        {
            try
            {
                var User = new UserPeople
                {
                    Id = id,
                    Name = name,
                    Sex = sex,
                    YearOfBirth = yearOfBirth,
                    Address=address,
                    Phone=phone,
                };
                using (var db = new MyDbContext())
                {
                    User =await db.UserPeoples.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (User != null)
                    {
                        User.Name = name;
                        User.Sex = sex;
                        User.YearOfBirth = yearOfBirth;
                        User.Address = address;
                        User.Phone = phone;
                        db.UserPeoples.Update(User);
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
        public async Task <bool> DeleteUser(Guid id)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var RemoveUser = await db.UserPeoples.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (RemoveUser == null)
                    {
                        return false;
                    }
                    else
                    {
                      db.UserPeoples.Remove(RemoveUser);
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
        public async Task<bool> AddUserRole(Guid UserId , Guid RoleId)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var user = await db.UserPeoples.Where(x => x.Id == UserId).FirstOrDefaultAsync();
                    var role = await db.Roles.Where(x => x.Id == RoleId).FirstOrDefaultAsync();

                    if (user == null || role == null)
                    {
                        return false;
                    }

                    var userRole = db.UserRoles.Where(x => x.UserId == UserId && x.RoleId == RoleId).FirstOrDefault();
                    if (userRole != null)
                    {
                        return false;
                    }
                    var newUserRole = new UserRole()
                    {
                        Id = Guid.NewGuid(),
                        RoleId=RoleId,
                        UserId=UserId
                    };
                    db.UserRoles.Add(newUserRole);
                   await db.SaveChangesAsync();

                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public async Task<List<UserModels>> GetUserRole(Guid idRole)
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
                    return listUser;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<bool>AddServiceToDoctor(Guid DoctorId,Guid ServiceId)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var user = await db.UserPeoples.Where(x => x.Id == DoctorId).FirstOrDefaultAsync();
                    var service = await db.Services.Where(x => x.Id == ServiceId).FirstOrDefaultAsync();

                    if (user == null || service == null)
                    {
                        return false;
                    }
                    var doctorService = await db.DoctorServices.Where(x => x.ServiceId == ServiceId && x.UserId == DoctorId).FirstOrDefaultAsync();
                    if (doctorService != null)
                    {
                        return false;
                    }
                    var newDoctorService = new DoctorService()
                    {
                        Id = Guid.NewGuid(),
                        UserId=DoctorId,
                        ServiceId=ServiceId
                    };
                    db.DoctorServices.Add(newDoctorService);
                    await db.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<List<DoctorModels>> GetDoctorOfServices(Guid ServiceId)
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
                    }
                    return listDoctorService;
                }
            }
            catch (Exception)
            {

                throw;
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
                    var getUserId = await db.UserRoles.Where(x => x.RoleId == checkRole.Id)
                        .Join(db.UserPeoples,s=>s.UserId,a=>a.Id,(s,a)=>new {s,a}).ToListAsync();
                    if(getUserId.Count()>0)
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
