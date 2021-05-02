using BLL.DTO;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO.Converters;

namespace BLL
{
    public class PerformanceService
    {
        private readonly IRepository<Performance> _repositoryPerformanse;
        private readonly IRepository<Session> _repositorySession;
        private readonly SessionRepository _sessionReadRepository;
        private readonly IRepository<Actor> _repositoryActor;
        private readonly IRepository<AgeQualification> _repositoryAge;
        private readonly IRepository<Genre> _repositoryGenre;

        public PerformanceService(IRepository<Performance> repositoryPerformanse, IRepository<Session> repositorySession, SessionRepository sessionReadRepository,
            IRepository<Actor> repositoryActor, IRepository<AgeQualification> repositoryAge, IRepository<Genre> repositoryGenre)
        {
            _repositoryPerformanse = repositoryPerformanse;
            _repositorySession = repositorySession;
            _sessionReadRepository = sessionReadRepository;
            _repositoryActor = repositoryActor;
            _repositoryAge = repositoryAge;
            _repositoryGenre = repositoryGenre;
        }

        public IEnumerable<DTOPerformance> GetPerformances()
        {
            return _repositoryPerformanse.Read().Select(e => e.ToDTOPerformance());
        }

        public IEnumerable<DTOSession> GetSessions()
        {
            return _sessionReadRepository.Read()?.Select(e=>e.ToDTOSession());
            //return null;
        }

        public async Task<DTOPerformance> AddPerformance(string name, TimeSpan duration, IEnumerable<DTOGenre> genres, IEnumerable<DTOActor> actors, DTOAgeQualification ageQualification, string description)
        {
            DTOPerformance performance = new DTOPerformance()
            {
                Name = name,
                Duration = duration,
                DTOGenres = genres,
                DTOActors = actors,
                DTOAgeQualification = ageQualification,
                Description = description
            };
            await _repositoryPerformanse.Create((performance.FromDTOPerfomance()));
            return performance;
        }

        public void DeletePerformance(DTOPerformance performance)
        {
            _repositoryPerformanse.Delete(performance.FromDTOPerfomance());
        }

        public void UpdatePerformance(int id, string name, TimeSpan duration, IEnumerable<DTOGenre> genres, IEnumerable<DTOActor> actors, DTOAgeQualification ageQualification, string description)
        {
            DTOPerformance performance = new DTOPerformance()
            {
                Id = id,
                Name = name,
                Duration = duration,
                DTOGenres = genres,
                DTOActors = actors,
                DTOAgeQualification = ageQualification,
                Description = description
            };
            _repositoryPerformanse.Update(performance.FromDTOPerfomance());
        }

        public DTOPerformance GetPerformanceById(int id)
        {
            return _repositoryPerformanse.GetById(id).Result.ToDTOPerformance();
        }

        public IEnumerable<DTOSession> GetSessionsByPerformanceId(int performanceId)
        {
            return _repositoryPerformanse.GetById(performanceId).Result.Sessions.Select(e => e.ToDTOSession());
        }

        public IEnumerable<DTOSession> ReadSessionByDate(DateTime dateTimeSession )
        {
            return _sessionReadRepository
                .Read()
                .Where(s => s.Date >= dateTimeSession.Date && s.Date < (dateTimeSession.Date + TimeSpan.FromDays(1)))
                .Select(e=>e.ToDTOSession());
        }

        public void CreateSession(DTOPerformance performance, DateTime date, int quantiti = 100)
        {
            DTOSession session = new DTOSession()
            {
                DTOPerformance = performance,
                Date = date,
            };
            if (ValidateSessionIntersection(session))
            {
                _repositorySession.Create(session.FromDTOSession());
            }
        }
        public bool ValidateSessionIntersection(DTOSession session)
        {
            var allDate = ReadSessionByDate(session.Date).Append(session).OrderBy(e=>e.Date).ToArray();
            int number = 0;
            for (int i = 0; i < allDate.Length && allDate[i].Id != session.Id; i++) { number = i; }
            number++;
            if (number == 0)
                return true;
            //TODO: Разбить на два ифа. + на длину > 3
            if (allDate[number - 1].Date + allDate[number - 1].DTOPerformance.Duration < session.Date + session.DTOPerformance.Duration 
                && allDate[number - 1].Date + allDate[number + 1].DTOPerformance.Duration > session.Date + session.DTOPerformance.Duration)
            {
                return true;
            }
            else
                return false;
        }


    }
}
