using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.BLL.DTO
{
    public class UsersDTO
    {
        public int UserID { get; set; }

        public string UserName { get; set; }
        public string UserLastname { get; set; }

        public string UserMiddlename { get; set; }
        public string TrainingGroup { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public int RoleID { get; set; }

        public bool OnTest { get; set; }

        public RolesDTO Roles { get; set; }
    }
}
