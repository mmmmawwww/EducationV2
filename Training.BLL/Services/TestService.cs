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
    public class TestService : ITestService
    {
        IUnitOfWork Database { get; set; }

        public TestService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public TestsDTO getTestByID(int TestID)
        {
            var QuestionMapper = new MapperConfiguration(cfg => cfg.CreateMap<TestQuestions, QuestionDTO>()).CreateMapper();
            var TestMapper = new MapperConfiguration(cfg => cfg.CreateMap<Tests, TestsDTO>().ForMember(dto => dto.TestQuestions, opt => opt.MapFrom(s => QuestionMapper.Map<IEnumerable<TestQuestions>, List<QuestionDTO>>(s.TestQuestions)))).CreateMapper();
            var model = TestMapper.Map<Tests, TestsDTO>(Database.Tests.Find(t => t.TestID == TestID).FirstOrDefault());
            return model;

        }

        public (int, List<string>) СalculateTestResult(List<AnswersDTO> answers,string UserLogin)
        {
            double point = 10.0 / answers.Count();
            double sum = 0;
            List<string> questions = new List<string>();

            foreach (var ans in answers)
            {
                var question = Database.TestQuestions.Find(q => q.QuestionID == ans.QuestionID).FirstOrDefault();
                if (question.Correct_answer == ans.answer)
                {
                    sum = sum + point;
                }
                else { questions.Add(question.Question); }
            }
            var ID = Database.TestQuestions.Find(q => q.QuestionID == answers[0].QuestionID).FirstOrDefault().TestID;
            var mark = Database.Marks.Find(m => m.TopicID == ID).FirstOrDefault();
            if (mark != null)
            {
                mark.Mark = (int)Math.Round(sum);
                Database.Marks.Update(mark);
            }
            else
            {
                Database.Marks.Create(new Marks
                {
                    Mark = (int)Math.Round(sum),
                    TopicID = ID,
                    UserID = Database.Users.Find(u => u.Login == UserLogin).FirstOrDefault().UserID
                });
            }
            Database.Save();
            return ((int)Math.Round(sum), questions);
        }
    }
}
