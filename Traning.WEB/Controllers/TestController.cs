using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Training.BLL.DTO;
using Training.BLL.Interfaces;
using Training.WEB.Models;

namespace Training.WEB.Controllers
{
    public class TestController : Controller
    {
        ITestService testService;

        public TestController( ITestService test)
        {
            testService = test;
        }
        // GET: Test
        public ActionResult Test(int id)
        {
            var QuestionMapper = new MapperConfiguration(cfg => cfg.CreateMap<QuestionDTO, QuestionViewModel>()).CreateMapper();
            var TestMapper = new MapperConfiguration(cfg => cfg.CreateMap<TestsDTO, TestViewModel>().ForMember(dto => dto.TestQuestions, opt => opt.MapFrom(s => QuestionMapper.Map<IEnumerable<QuestionDTO>, List<QuestionViewModel>>(s.TestQuestions)))).CreateMapper();
            TestViewModel model = TestMapper.Map<TestsDTO, TestViewModel>(testService.getTestByID(id));
            return View(model);
        }
        [HttpPost]
        public ActionResult Test(List<Answer> Answers)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Answer, AnswersDTO>()).CreateMapper();
            var result = testService.СalculateTestResult(mapper.Map<IEnumerable<Answer>, List<AnswersDTO>>(Answers),User.Identity.Name);
            TestResultViewModel model = new TestResultViewModel() { Mark = result.Item1, WrongAnswers = result.Item2 };
            return View("TestResult",model);
        }
    }
}