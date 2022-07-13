using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.DAL.Entities;

namespace Training.DAL.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {

        IGenericRepository<Marks> Marks { get; }
        IGenericRepository<Roles> Roles { get; }
        IGenericRepository<TestQuestions> TestQuestions { get; }
        IGenericRepository<Tests> Tests { get; }
        IGenericRepository<Topics> Topics { get; }
        IGenericRepository<Users> Users { get; }

        void Save();
    }
}
