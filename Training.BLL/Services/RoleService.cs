using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.BLL.DTO;
using Training.BLL.Interfaces;
using Training.DAL.Entities;
using Training.DAL.Interfaces;

namespace Training.BLL.Services
{
    public class RoleService : IRoleService
    {
        IUnitOfWork Database { get; set; }

        public RoleService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public IEnumerable<RolesDTO> GetAllRoles()
        {
            var RoleMapper = new MapperConfiguration(cfg => cfg.CreateMap<Roles, RolesDTO>()).CreateMapper();
            return RoleMapper.Map<IEnumerable<Roles>, List<RolesDTO>>(Database.Roles.GetAll());
        }

        public RolesDTO GetRoleByID(int RoleID)
        {
            var RoleMapper = new MapperConfiguration(cfg => cfg.CreateMap<Roles, RolesDTO>()).CreateMapper();
            return RoleMapper.Map<Roles, RolesDTO>(Database.Roles.Find(r => r.RoleID == RoleID).FirstOrDefault());
        }

        public bool IsUserInRole(string username, string roleName)
        {
            var RoleMapper = new MapperConfiguration(cfg => cfg.CreateMap<Roles, RolesDTO>()).CreateMapper();
            var UserMapper = new MapperConfiguration(cfg => cfg.CreateMap<Users, UsersDTO>().ForMember(dto => dto.Roles, opt => opt.MapFrom(s => RoleMapper.Map<Roles, RolesDTO>(s.Roles)))).CreateMapper();
            UsersDTO user = UserMapper.Map<Users, UsersDTO>(Database.Users.Find(u => u.Login == username).FirstOrDefault());

            if (user != null && user.Roles != null && user.Roles.RoleName == roleName)
                    return true;
                else
                    return false;           
        }

        public string[] GetRolesForUser(string username)
        {
            string[] roles = new string[] { };
            // Получаем пользователя
            var RoleMapper = new MapperConfiguration(cfg => cfg.CreateMap<Roles, RolesDTO>()).CreateMapper();
            var UserMapper = new MapperConfiguration(cfg => cfg.CreateMap<Users, UsersDTO>().ForMember(dto => dto.Roles, opt => opt.MapFrom(s => RoleMapper.Map<Roles, RolesDTO>(s.Roles)))).CreateMapper();

            UsersDTO user = UserMapper.Map<Users, UsersDTO>(Database.Users.Find(u => u.Login == username).FirstOrDefault());
            if (user != null && user.Roles != null)
                {
                    RolesDTO userRole = GetRoleByID(user.RoleID);
                    if (userRole != null)
                    {
                        roles = new string[] { user.Roles.RoleName };
                    }
                    // получаем роль
             }
             return roles;
            
        }
    }
}
