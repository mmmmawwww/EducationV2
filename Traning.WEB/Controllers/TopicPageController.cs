using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Training.BLL.DTO;
using Training.BLL.Interfaces;
using Training.WEB.Models;

namespace Training.WEB.Controllers
{
    [Authorize(Roles = "Student")]
    public class TopicPageController : Controller
    {
        ITopicService topicService;

        public TopicPageController(ITopicService serv)
        {
            topicService = serv;
        }
        // GET: TopicPage
        
        public ActionResult Topic()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TopicDTO, TopicView>()).CreateMapper();
            TopicViewModel model = new TopicViewModel();
                model.AvailableTopics = topicService.availableTopics(User.Identity.Name);
                model.topics = mapper.Map<IEnumerable<TopicDTO>, List<TopicView>>(topicService.getAllTopics());
                model.CurrentTopic = model.topics[model.AvailableTopics-1];
                return View("TopicPage", model);
        }

        public ActionResult TopicAjax(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TopicDTO, TopicView>()).CreateMapper();
           TopicView model = mapper.Map<TopicDTO, TopicView>(topicService.getCurrentTopicById((int)id));
            return PartialView("CurrentTopicPartial",model);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }

}