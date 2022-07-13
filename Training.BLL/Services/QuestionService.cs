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
    public class QuestionService : IQuestionService
    {
        IUnitOfWork Database { get; set; }

        public QuestionService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void AddQuestion(QuestionDTO question)
        {
            Database.TestQuestions.Create(new TestQuestions
            {
                Question = question.Question,
                Answer_1 = question.Answer_1,
                Answer_2 = question.Answer_2,
                Answer_3 = question.Answer_3,
                Answer_4 = question.Answer_4,
                Correct_answer = question.Correct_answer,
                TestID = question.TestID
            });
            Database.Save();
        }

        public IEnumerable<QuestionDTO> GetAllQuestionForTest(int TestID)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TestQuestions, QuestionDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<TestQuestions>, List<QuestionDTO>>(Database.TestQuestions.GetAll().Where(t => t.TestID == TestID));
        }
    }
}
