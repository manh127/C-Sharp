using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Models
{
    public class RepoResponse<T>
    {
        public int Status { get; set; }
        public string Msg { get; set; }
        public T Data { get; set; }
    }
}
