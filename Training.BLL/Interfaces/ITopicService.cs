using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.BLL.DTO;

namespace Training.BLL.Interfaces
{
   public interface ITopicService
    {
        IEnumerable<TopicDTO> getAllTopics();

        int availableTopics(string CurrentUserLogin);
        TopicDTO getCurrentTopicById(int ID);

        void addTopic(TopicDTO newTopic);
        int addTopicAndTest(TopicDTO newTopic, string TestName);

    }
}
