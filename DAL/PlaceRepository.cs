using Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class PlaceRepository : Repository<Place>
    {
        public PlaceRepository(ApplicationContext applicationContext) : base(applicationContext)
        {}

        public override IEnumerable<Place> Read()
        {
            return _applicationContext
                .Places
                .Include(x => x.Hall)
                .Include(x => x.TypeOfSeat);
        }

        public override async Task<Place> Create(Place entity)
        {
            await _applicationContext.Set<Place>().AddAsync(entity);
            _applicationContext.Set<Hall>().Attach(entity.Hall);
            _applicationContext.Set<TypeOfSeat>().Attach(entity.TypeOfSeat);
            await _applicationContext.SaveChangesAsync();
            return entity;
        }

        public override async Task<Place> Update(Place entity)
        {
             _applicationContext.Set<Place>().Update(entity);
            _applicationContext.Set<Hall>().Attach(entity.Hall);
            _applicationContext.Set<TypeOfSeat>().Attach(entity.TypeOfSeat);
            await _applicationContext.SaveChangesAsync();
            return entity;
        }
    }
}
