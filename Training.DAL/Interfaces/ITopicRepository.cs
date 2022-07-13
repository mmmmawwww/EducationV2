using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.DAL.Entities;

namespace Training.DAL.Interfaces
{
    public interface ITopicRepository : IGenericRepository<Topics> 
    {
         int CreateAndReturnID(Topics item);
    }
}
