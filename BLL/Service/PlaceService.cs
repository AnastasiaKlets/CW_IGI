using BLL.DTO;
using BLL.DTO.Converters;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class PlaceService
    {
        private readonly IRepository<Place> _repositoryPlace;
        private readonly IRepository<TypeOfSeat> _repositoryTypeOfSeat;
        private readonly IRepository<Hall> _repositoryHall; 

        public PlaceService(IRepository<Place> repositoryPlace, IRepository<TypeOfSeat> repositoryTypeOfSeat, IRepository<Hall> repositoryHall)
        {
            _repositoryPlace = repositoryPlace;
            _repositoryTypeOfSeat = repositoryTypeOfSeat;
            _repositoryHall = repositoryHall;
        }
        public IEnumerable<Place> GetPlace()
        {
            return _repositoryPlace.Read();
        }
        public DTOPlace GetDTOPlaceById(int id)
        {
            return _repositoryPlace.GetById(id).Result.ToDTOPlace();
        }
        public DTOTypeOfSeat GetDTOTypeOfSeatById(int id)
        {
            return _repositoryTypeOfSeat.GetById(id).Result.ToDTOTypeOfSeat();
        }
        public DTOHall GetDTOHallById(int id)
        {
            return _repositoryHall.GetById(id).Result.ToDTOHall();
        }

        public IEnumerable<TypeOfSeat> GetTypeOfSeats()
        {
            return _repositoryTypeOfSeat.Read();
        }

        public async void AddTypeOfSeat( string name, double price)
        {
            TypeOfSeat typeOfSeat = new TypeOfSeat()
            {
                Name = name,
                Price = price,
            };
            await _repositoryTypeOfSeat.Create(typeOfSeat);
        }

        public async void UpdateTypeOfSeat(int id, string name, double price)
        {
            TypeOfSeat typeOfSeat = new TypeOfSeat()
            {
                Id = id,
                Name = name,
                Price = price,
            };
            await _repositoryTypeOfSeat.Update(typeOfSeat);
        }

        public async void DeleteTypeOfseat(int id)
        {
            TypeOfSeat typeOfSeat = new TypeOfSeat()
            {
                Id = id,
            };
            await _repositoryTypeOfSeat.Delete(typeOfSeat);
        }
        public async Task<TypeOfSeat> GetTypeOfSeatById(int id)
        {
            return await _repositoryTypeOfSeat.GetById(id);
        }
        public async void AddHall(string type)
        {
            Hall hall = new Hall()
            {
                Type = type,
            };
            await _repositoryHall.Create(hall);
        }

        public async void UpdateHall(int id, string type)
        {
           Hall hall = new Hall()
            {
                Id = id,
                Type = type,
            };
            await _repositoryHall.Update(hall);
        }

        public async void DeleteHall(int id)
        {
            Hall hall = new Hall()
            {
                Id = id,
            };
            await _repositoryHall.Delete(hall);
        }
        public IEnumerable<Hall> GetHalls()
        {
            return _repositoryHall.Read();
        }

        public async Task<Hall> GetHallById(int id)
        {
            return await _repositoryHall.GetById(id);
        }

        public async void AddPlace(int hallId, int row, int typeOfSeatId)
        {
            Place place = new Place()
            {
                Hall = await GetHallById(hallId),
                Row = row,
                TypeOfSeat = await GetTypeOfSeatById(typeOfSeatId),
            };
            await _repositoryPlace.Create(place);
        }

        public async void UpdatePlace(int id, int hallId, int row, int typeOfSeatId)
        {
            Place place = new Place()
            {
                Id = id,
                Hall = await GetHallById(hallId),
                Row = row,
                TypeOfSeat = await GetTypeOfSeatById(typeOfSeatId),
            };
            await _repositoryPlace.Update(place);
        }

        public async void DeletePlace(int id)
        {
            Place place = new Place()
            {
                Id = id,
            };
            await _repositoryPlace.Delete(place);
        }
        public async Task<Place> GetPlaceById(int id)
        {
            return await _repositoryPlace.GetById(id);
        }
    }
}
