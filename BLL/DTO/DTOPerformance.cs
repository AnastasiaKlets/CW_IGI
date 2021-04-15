using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class DTOPerformance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public IEnumerable<DTOGenre> DTOGenres { get; set; }
        public IEnumerable<DTOActor> DTOActors { get; set; }

        public IEnumerable<DTOSession> DTOSessions { get; set; }
        public DTOAgeQualification DTOAgeQualification { get; set; }
        public string Description { get; set; }
    }
}
