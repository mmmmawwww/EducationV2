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
   
   public class TopicService : ITopicService
    {
        const int MinMark = 3;
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<Topics, TopicDTO>()).CreateMapper();
        IUnitOfWork Database { get; set; }

        public TopicService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public IEnumerable<TopicDTO> getAllTopics()
        {
            return mapper.Map<IEnumerable<Topics>, List<TopicDTO>>(Database.Topics.GetAll().OrderBy(u => u.SequenceNumber));
        }

        public TopicDTO getCurrentTopicById(int ID)
        {
            return mapper.Map<Topics, TopicDTO>(Database.Topics.Get(ID));
        }

        public int availableTopics(string CurrentUserLogin)
        {
            var user = Database.Users.Find(u => u.Login == CurrentUserLogin).FirstOrDefault();
            var topics = Database.Topics.GetAll().OrderBy(u => u.SequenceNumber);
            int k = 0;
            foreach(var top in topics)
            {
                k++;
                if (top.Marks.Where(u => u.UserID == user.UserID && u.Mark>MinMark).Count() == 0)
                {
                    return k;
                }
               
            }
            return k;
        }

        public void addTopic(TopicDTO newTopic)
        {
            // Database.Topics.CreateAndReturnID(mapper.Map<TopicDTO, Topics>(newTopic);
            Database.Topics.Create(new Topics
            {
                TopicName = newTopic.TopicName,
                Topic = newTopic.Topic,
                SequenceNumber = newTopic.SequenceNumber
            });
            Database.Save();
        }

        public int addTopicAndTest(TopicDTO newTopic,string TestName)
        {
            Topics topic = new Topics();
            topic.TopicName = newTopic.TopicName;
                topic.Topic = newTopic.Topic;
            topic.SequenceNumber = newTopic.SequenceNumber;
            Database.Topics.Create(topic);
            Database.Save();
            
            Database.Tests.Create(new Tests
            {
                TestID = topic.TopicID,
                TestName = TestName
            });

            Database.Save();
            return topic.TopicID;
        }
    }
}
