using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Training.BLL.BusinessModels;
using Training.BLL.DTO;
using Training.BLL.Infrastructure;
using Training.BLL.Interfaces;
using Training.DAL.Entities;
using Training.DAL.Interfaces;

namespace Training.BLL.Services
{
   public class AccountService : IAccountService
    {
        IUnitOfWork Database { get; set; }

        public AccountService(IUnitOfWork uow)
        {
            Database = uow;
        }


        public int Login(string login, string password)
        {
            Users user = Database.Users.Find(u => u.Login == login && u.Password == GetHashMD5.GetHash(password)).FirstOrDefault();
            if (user == null)
                return 0;
            return (int)user.RoleID;
        }

        public bool Register(UsersDTO newuser)
        {
            Users user = null;
            user = Database.Users.Find(u => u.Login == newuser.Login).FirstOrDefault();
            if(user == null)
            {
                Database.Users.Create(new Users
                {
                    UserName = newuser.UserName,
                    UserLastname = newuser.UserLastname,
                    UserMiddlename = newuser.UserMiddlename,
                    TrainingGroup = newuser.TrainingGroup,
                    Login = newuser.Login,
                    Password = GetHashMD5.GetHash(newuser.Password),
                    RoleID = Database.Roles.Find(x => x.RoleName == "Student").FirstOrDefault().RoleID,
                    OnTest = false
                });
                Database.Save();
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Dispose()
        {
            Database.Dispose();
        }

        public string ChangePassword(string login,string password)
        {
                string message;
                var user = Database.Users.Find(u => u.Login == login).FirstOrDefault();
                if (user != null)
                {
                    user.Password = GetHashMD5.GetHash(password);
                    Database.Users.Update(user);
                    Database.Save();
                    return message = "Пароль успешно изменен!";
                }
                else { return message = "Что-то пошло не так!"; }
            
        }
    }
}
