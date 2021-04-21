using BLL.DTO;
using BLL.DTO.Converters;
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
        private readonly IRepository<TypeOfSeat> _repositoryTypeOfSeat;
        private readonly IRepository<Hall> _repositoryHall; 

        public PlaceServise(IRepository<Place> repositoryPlace, IRepository<TypeOfSeat> repositoryTypeOfSeat, IRepository<Hall> repositoryHall)
        {
            _repositoryPlace = repositoryPlace;
            _repositoryTypeOfSeat = repositoryTypeOfSeat;
            _repositoryHall = repositoryHall;
        }
        public IEnumerable<Place> GetPlace()
        {
            return _repositoryPlace.Read();
        }
        public DTOPlace GetPlaceById(int id)
        {
            return _repositoryPlace.GetById(id).Result.ToDTOPlace();
        }
        public DTOTypeOfSeat GetTypeOfSeatById(int id)
        {
            return _repositoryTypeOfSeat.GetById(id).Result.ToDTOTypeOfSeat();
        }
        public DTOHall GetHallById(int id)
        {
            return _repositoryHall.GetById(id).Result.ToDTOHall();
        }


    }
}
