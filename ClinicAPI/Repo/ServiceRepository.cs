using ClinicAPI.Entity;
using ClinicAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Repo
{
    public class ServiceRepository
    {
        public async Task<bool> CreateService(string name, string price)
        {
            try
            {
                var ServiceInformation = new Service
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Price = price
                };
                using (var db = new MyDbContext())
                {
                    db.Services.Add(ServiceInformation);
                    await db.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<ServiceModels> GetServiceInfo(Guid id)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var ServiceInfor = await db.Services.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (ServiceInfor != null)
                    {
                        return new ServiceModels
                        {
                            Id = id,
                            Name = ServiceInfor.Name,
                            Price = ServiceInfor.Price
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
        public async Task<List<ServiceModels>> GetListServiceInfo()
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var listService = new List<ServiceModels>();
                    var ListServiceInfor = await db.Services.ToListAsync();
                    if (ListServiceInfor.Count>0)
                    {
                        foreach (var item in ListServiceInfor)
                        {
                            var ServiceModels = new ServiceModels
                            {
                                Id = item.Id,
                                Name = item.Name,
                                Price = item.Price
                            };
                            listService.Add(ServiceModels);
                        }
                        return listService;
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<bool> UpdateService(Guid id, string name, string price)
        {
            try
            {
                var service = new Service
                {
                    Id = id,
                    Name = name,
                    Price = price
                };
                using (var db = new MyDbContext())
                {
                    service = await db.Services.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (service != null)
                    {
                        service.Name = name;
                        service.Price = price;
                        db.Services.Update(service);
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
        public async Task<bool> DeleteService(Guid id)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var RemoveService = await db.Services.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (RemoveService == null)
                    {
                        return false;
                    }
                    else
                    {
                        db.Services.Remove(RemoveService);
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
