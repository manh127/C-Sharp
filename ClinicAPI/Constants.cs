using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI
{
    public class Constants
    {
        public enum ScheduleStatus
            {
            [Display(Name = "Chưa xác nhận")]
            NOT_CONFIRM = 0,

            [Display(Name = "Xác nhận")]
            COMFIRM = 1,

            [Display(Name = "Dã thanh toán")]
            PAIED = 2,

            [Display(Name = "Huỷ")]
            CANCELED = 3,
        }
    }
}
