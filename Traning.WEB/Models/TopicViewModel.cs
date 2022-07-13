using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Training.WEB.Models
{
    public class TopicViewModel
    {
        public int AvailableTopics { get; set; }
        public TopicView CurrentTopic { get; set; }
        public List<TopicView> topics { get; set; }
    }

    public class TopicView
    {
        public int TopicID { get; set; }

        public string TopicName { get; set; }
        public string Topic { get; set; }

        public int SequenceNumber { get; set; }
    }
}