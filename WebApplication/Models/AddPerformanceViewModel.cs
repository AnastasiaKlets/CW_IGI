using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class AddPerformanceViewModel
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
        public AgeQualification AgeQualification { get; set; }
        public string Description { get; set; }
    }
}
