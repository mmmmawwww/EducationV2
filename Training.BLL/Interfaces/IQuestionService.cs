using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.BLL.DTO;

namespace Training.BLL.Interfaces
{
    public interface IQuestionService
    {
        void AddQuestion(QuestionDTO question);
        IEnumerable<QuestionDTO> GetAllQuestionForTest(int TestID);
    }
}
