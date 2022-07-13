using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.BLL.DTO;

namespace Training.BLL.Interfaces
{
   public interface IRoleService
    {
        IEnumerable<RolesDTO> GetAllRoles();
        RolesDTO GetRoleByID(int RoleID);

        bool IsUserInRole(string username, string roleName);

        string[] GetRolesForUser(string username);
    }
}
