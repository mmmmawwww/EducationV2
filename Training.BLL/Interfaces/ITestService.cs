using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.BLL.DTO;

namespace Training.BLL.Interfaces
{
    public interface ITestService
    {
        TestsDTO getTestByID(int TestID);
        (int,List<string>) СalculateTestResult(List<AnswersDTO> answers, string UserLogin);
    }
}
