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
        public async Task<RepoResponse<string>> CreateService(string name, double price)
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
                return new RepoResponse<string> { Status = 1 , Msg = " Tạo dịch vụ thành công "};
            }
            catch (Exception e)
            {
                return new RepoResponse<string> {Status = 0 , Msg = " Lỗi " };
            }
        }
        public async Task<RepoResponse<ServiceModels>> GetServiceInfo(Guid id)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var ServiceInfor = await db.Services.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (ServiceInfor != null)
                    {
                         var data =  new ServiceModels
                        {
                            Id = id,
                            Name = ServiceInfor.Name,
                            Price = ServiceInfor.Price
                        };
                        return new RepoResponse<ServiceModels> { Status = 1, Data = data };
                    }
                    return new RepoResponse<ServiceModels> { Status = 0, Msg = " Không tìm thấy dịch vụ này " };
                }
            }
            catch (Exception e)
            {
                return new RepoResponse<ServiceModels> { Status = 0 , Msg = " Lỗi " };
            }
        }
        public async Task<RepoResponse<List<ServiceModels>>> GetListServiceInfo()
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
                        return new RepoResponse<List<ServiceModels>> { Status = 1 , Data = listService };
                    }
                    return new RepoResponse<List<ServiceModels>> { Status = 0 , Msg = " không có dịch vụ nào " };
                }
            }
            catch (Exception e)
            {
                return new RepoResponse<List<ServiceModels>> { Status = 0 ,Msg = " Lỗi " };
            }
        }
        public async Task<RepoResponse<string>> UpdateService(Guid id, string name, double price)
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
                        service.Id = id;
                        service.Name = name;
                        service.Price = price;
                        db.Services.Update(service);
                        await db.SaveChangesAsync();
                    }
                    return new RepoResponse<string> { Status = 0, Msg = " Không tìm thấy dịch vụ " };
                }
            }

            catch (Exception e)
            {
                return new RepoResponse<string> { Status = 0, Msg = " Lỗi " };
            }
        }
        public async Task<RepoResponse<string>> DeleteService(Guid id)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var RemoveService = await db.Services.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (RemoveService != null)
                    {
                        db.Services.Remove(RemoveService);
                        await db.SaveChangesAsync();
                    }
                    return new RepoResponse<string> { Status = 0 , Msg = " Không tồn tại dịch vụ này " };
                }
            }
            catch (Exception)
            {
                return new RepoResponse<string> { Status = 0, Msg = " Lỗi " };
            }
        }
       
    }
}
