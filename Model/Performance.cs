using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Performance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
        public AgeQualification AgeQualification { get; set; }
        public string Description { get; set; }

        public IEnumerable<Session> Sessions { get; set; }

        public string Image { get; set; }



    }
}
