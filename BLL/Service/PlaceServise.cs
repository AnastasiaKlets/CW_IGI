using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Service
{
    public class PlaceServise
    {
        private readonly IRepository<Place> _repositoryPlace;

        public PlaceServise(IRepository<Place> repositoryPlace)
        {
            _repositoryPlace = repositoryPlace;
        }
        public IEnumerable<Place> GetSessions()
        {
            return _repositoryPlace.Read();
        }
    }
}
