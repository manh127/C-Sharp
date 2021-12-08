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
        public async Task<bool> CreateRole(string name, string code)
        {
            try
            {
                var RoleInformation = new Role
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Code=code
                };
                using (var db = new MyDbContext())
                {
                    db.Roles.Add(RoleInformation);
                    await db.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<RoleModels> GetRoleInfo(Guid id)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var RoleInfor = await db.Roles.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (RoleInfor != null)
                    {
                        return new RoleModels
                        {
                            Id = id,
                            Name = RoleInfor.Name,
                            Code = RoleInfor.Code
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
        public async Task<bool> UpdateRole(Guid id, string name, string code)
        {
            try
            {
                var role = new Role
                {
                    Id = id,
                    Name = name,
                    Code = code
                };
                using (var db = new MyDbContext())
                {
                    role = await db.Roles.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (role != null)
                    {
                        role.Name = name;
                        role.Code = code;
                        db.Roles.Update(role);
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
        public async Task<bool> DeleteRole(Guid id)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var RemoveRole = await db.Roles.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (RemoveRole == null)
                    {
                        return false;
                    }
                    else
                    {
                        db.Roles.Remove(RemoveRole);
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
    }
}
