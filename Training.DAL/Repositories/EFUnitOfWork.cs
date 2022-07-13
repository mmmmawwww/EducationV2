using System;
using Training.DAL.EF;
using Training.DAL.Entities;
using Training.DAL.Interfaces;

namespace Training.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private TrainingContext db;        
        private EFGenericRepository<Marks> MarksRepository;
        private EFGenericRepository<Roles> RolesRepository;
        private EFGenericRepository<TestQuestions> TestQuestionsRepository;
        private EFGenericRepository<Topics> TopicsRepository;
        private EFGenericRepository<Tests> TestsRepository;
        private EFGenericRepository<Users> UsersRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new TrainingContext(connectionString);
        }

        public IGenericRepository<Marks> Marks 
        { 
            get {
                if (MarksRepository == null)
                    MarksRepository = new EFGenericRepository<Marks>(db);
                return MarksRepository;
            } 
        }

        public IGenericRepository<Roles> Roles
        {
            get
            {
                if (RolesRepository == null)
                    RolesRepository = new EFGenericRepository<Roles>(db);
                return RolesRepository;
            }
        }

        public IGenericRepository<TestQuestions> TestQuestions
        {
            get
            {
                if (TestQuestionsRepository == null)
                    TestQuestionsRepository = new EFGenericRepository<TestQuestions>(db);
                return TestQuestionsRepository;
            }
        }

        public IGenericRepository<Tests> Tests
        {
            get
            {
                if (TestsRepository == null)
                    TestsRepository = new EFGenericRepository<Tests>(db);
                return TestsRepository;
            }
        }

        public IGenericRepository<Topics> Topics
        {
            get
            {
                if (TopicsRepository == null)
                    TopicsRepository = new EFGenericRepository<Topics>(db);
                return TopicsRepository;
            }
        }

        public IGenericRepository<Users> Users
        {
            get
            {
                if (UsersRepository == null)
                    UsersRepository = new EFGenericRepository<Users>(db);
                return UsersRepository;
            }
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
