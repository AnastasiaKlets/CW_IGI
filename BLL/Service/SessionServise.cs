using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Service
{
    public class SessionServise
    {
        private readonly IRepository<Session> _repositorySession;

        public SessionServise(IRepository<Session> repositorySession)
        {
            _repositorySession = repositorySession;
        }
        public IEnumerable<Session> GetSessions()
        {
            return _repositorySession.Read();
        }
    }
}
