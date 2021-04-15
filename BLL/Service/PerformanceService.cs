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

        public PerformanceService(IRepository<Performance> repositoryPerformanse , IRepository<Session> repositorySession)
        {
            _repositoryPerformanse = repositoryPerformanse;
            _repositorySession = repositorySession;
        }

        public IEnumerable<DTOPerformance> GetPerformances()
        {
            return _repositoryPerformanse.Read().Select(e=>e.ToDTOPerformance());
        }

        public IEnumerable<DTOSession> GetSessions()
        {
            //return _repositorySession.Read().Select(e=>e);
            return null;
        }

        public  async Task<DTOPerformance> AddPerformance(string name, TimeSpan duration, IEnumerable<DTOGenre> genres, IEnumerable<DTOActor> actors, DTOAgeQualification ageQualification, string description)
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

    }
}
