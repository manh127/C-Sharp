using ClinicAPI.Entity;
using ClinicAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Repo
{
    public class RoleRepository
    {
        public async Task<RepoResponse<string>> CreateRole(string name, string code)
        {
            try
            {
                
                using (var db = new MyDbContext())

                {
                    var RoleInformation = new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = name,
                        Code = code
                    };
                    db.Roles.Add(RoleInformation);
                    await db.SaveChangesAsync();
                }
                return new RepoResponse<string> {Status =1 , Msg = " Tạo quyền thành công "  };
            }
            catch (Exception e)
            {
                return new RepoResponse<string> { Status = 0, Msg = " Lỗi " }; ;
            }
        }
        public async Task<RepoResponse<RoleModels>> GetRoleInfo(Guid id)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var RoleInfor = await db.Roles.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (RoleInfor != null)
                    {
                        var data = new RoleModels
                        {
                            Id = id,
                            Name = RoleInfor.Name,
                            Code = RoleInfor.Code
                        };
                        return new RepoResponse<RoleModels> { Status = 1, Data = data };
                    }
                    return new RepoResponse<RoleModels> { Status = 0, Msg = " Không có quyền này " };
                }
            }
            catch (Exception e)
            {
                return new RepoResponse<RoleModels> { Status = 0, Msg = " Lỗi " };
            }
        }
        public async Task<RepoResponse<string>> UpdateRole(Guid id, string name, string code)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var role = new Role
                    {
                        Id = id,
                        Name = name,
                        Code = code
                    };
                    role = await db.Roles.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (role != null)
                    {
                        role.Name = name;
                        role.Code = code;
                        db.Roles.Update(role);
                        await db.SaveChangesAsync();
                        return new RepoResponse<string> { Status = 1, Msg = " update thành công " };
                    }
                    else { return new RepoResponse<string> { Status = 0, Msg = " Không tìm thấy quyền này " }; }
                }
            }
            catch (Exception e)
            {
                return new RepoResponse<string> { Status = 0, Msg = " Lỗi" };
            }
        }
        public async Task< RepoResponse<string>> DeleteRole(Guid id)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var RemoveRole = await db.Roles.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (RemoveRole != null)
                    {
                        db.Roles.Remove(RemoveRole);
                        await db.SaveChangesAsync();
                    }
                    return new RepoResponse<string> {Status = 0 ,Msg = " Không tìm thấy quyền này " };
                }
            }
            catch (Exception)
            {
                return new RepoResponse<string> { Status = 0, Msg = " Lỗi " };
            }
        }
    }
}
