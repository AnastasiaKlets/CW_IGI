using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class PerformanceReadOnlyRepository : Repository<Performance>
    {
        public PerformanceReadOnlyRepository(ApplicationContext context) : base(context)
        {

        }

        public async override Task<Performance> GetById(int id)
        {
            return await Task.Run(() => _applicationContext.Performances.Include(e => e.Sessions).Include(e => e.AgeQualification).Include(e => e.Actors).Include(e => e.Genres).First(e => e.Id == id));
        }

        public override IEnumerable<Performance> Read()
        {
            return _applicationContext.Performances.Include(e => e.Sessions).Include(e => e.AgeQualification).Include(e => e.Actors).Include(e => e.Genres);
        }
    }
}
