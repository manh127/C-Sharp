using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicAPI.Models
{
    public class RoleModels
    {
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}