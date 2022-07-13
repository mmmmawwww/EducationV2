using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.BLL.DTO
{
    public class TestsDTO 
    {
        public string TestName { get; set; }

        public IEnumerable<QuestionDTO> TestQuestions { get; set; }

    }
}
