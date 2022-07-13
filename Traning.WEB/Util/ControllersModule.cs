using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Training.BLL.Interfaces;
using Training.BLL.Services;

namespace Training.WEB.Util
{
    public class ControllersModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IAccountService>().To<AccountService>();
            Bind<ITopicService>().To<TopicService>();
            Bind<IRoleService>().To<RoleService>();
            Bind<IQuestionService>().To<QuestionService>();
            Bind<ITestService>().To<TestService>();
        }
    }
}