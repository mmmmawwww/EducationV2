using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.BLL.DTO;

namespace Training.BLL.Interfaces
{
    public interface IAccountService
    {
        int Login(string login, string password);
        bool Register(UsersDTO newuser);
        void Dispose();
        string ChangePassword(string Login,string password);
    }
}
