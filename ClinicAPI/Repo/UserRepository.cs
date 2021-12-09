using ClinicAPI.Models;
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
                var UserInformation = new UserPeople
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
                using (var db = new MyDbContext())
                {
                    db.UserPeoples.Add(UserInformation);
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
        public async Task <bool> UpdateUser(Guid id, string name, string sex, int yearOfBirth, string address, string phone, string username, string password)
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
                    UserName=username,
                    PassWord=password
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
                        User.UserName = username;
                        User.PassWord = password;
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

    }
}
