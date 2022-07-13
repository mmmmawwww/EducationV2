using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.BLL.DTO
{
    public class QuestionDTO 
    {
        public int QuestionID { get; set; }
        public string Question { get; set; }

        public string Answer_1 { get; set; }

        public string Answer_2 { get; set; }

        public string Answer_3 { get; set; }
        public string Answer_4 { get; set; }

        public string Correct_answer { get; set; }

        public int TestID { get; set; }

    }
}
