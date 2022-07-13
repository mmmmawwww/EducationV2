using AutoMapper;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Training.BLL.DTO;
using Training.BLL.Interfaces;
using Training.WEB.Models;

namespace Training.WEB.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminPanelController : Controller
    {
        // GET: AdminPanel
        IAccountService accountSevice;
        ITopicService topicSevice;
        IQuestionService questionSevice;
        public AdminPanelController(IAccountService serv, ITopicService topic, IQuestionService quest)
        {
            accountSevice = serv;
            topicSevice = topic;
            questionSevice = quest;
        }
        public ActionResult Admin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(string password, string chekpass)
        {

            string message;
            if (password != chekpass)
            {
                message = "Введенные пароли не совпадают";
                return Content($"<p style=\"color:red\">{message}<p>");
            }
            message = accountSevice.ChangePassword(User.Identity.Name, password);

            return Content($"<p style=\"color:red\">{message}<p>");
        }

        public ActionResult AddTopic()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddTopic(TopicView model, string TestName)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TopicView, TopicDTO>()).CreateMapper();
            if (ModelState.IsValid)
            {
                int id = topicSevice.addTopicAndTest(mapper.Map<TopicView, TopicDTO>(model), TestName);
                return RedirectToAction("AddQuestionsForTest", "AdminPanel", new { id = id });
            }
            return View(model);

        }
        public ActionResult AddQuestionsForTest(int id)
        {
            QuestionViewModel model = new QuestionViewModel();
            model.TestID = id;
            return View(model);
        }
        [HttpPost]
        public ActionResult AddQuestionsForTest(QuestionViewModel model, int id)
        {
            model.TestID = id;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<QuestionViewModel, QuestionDTO>()).CreateMapper();
            var mapper2 = new MapperConfiguration(cfg => cfg.CreateMap<QuestionDTO, QuestionViewModel>()).CreateMapper();
            if (ModelState.IsValid)
            {
                questionSevice.AddQuestion(mapper.Map<QuestionViewModel, QuestionDTO>(model));
                List<QuestionViewModel> list = mapper2.Map<IEnumerable<QuestionDTO>, IEnumerable<QuestionViewModel>>(questionSevice.GetAllQuestionForTest(model.TestID)).ToList();
                return PartialView("TestQuestionsPartial", list);
            }
            return View(model);

        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}