using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class SessionRepository : Repository<Session>
    {
        public SessionRepository(ApplicationContext applicationContext) : base(applicationContext)
        { }
        //public override Task<Performance> Create(Performance entity)
        //{
        //    return base.Create(entity);
        //}

        //public override bool Equals(object obj)
        //{
        //    return base.Equals(obj);
        //}

        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}

        public override IEnumerable<Session> Read()
        {
            return _applicationContext.Sessions
                .Include(e => e.Performance);
                
        }

        //    public override string ToString()
        //    {
        //        return base.ToString();
        //    }

        //    public override Task<Performance> Update(Performance entity)
        //    {
        //        return base.Update(entity);
        //    }
    }
}
