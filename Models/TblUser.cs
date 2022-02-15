using System;
using System.Collections.Generic;

namespace ClinicManagementSystemv2022.Models
{
    public partial class TblUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Userpassword { get; set; }
        public int RoleId { get; set; }
    }
}
