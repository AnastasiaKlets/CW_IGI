using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Model;

namespace BLL.DTO.Converters
{
    public static class Converters
    {
        public static DTOPerformance ToDTOPerformance(this Performance obj)
        {
            var res = new DTOPerformance();
            res.Id = obj.Id;
            res.Name = obj.Name;
            res.Duration = obj.Duration;
            res.DTOGenres = obj.Genres?.Select(g => g.ToDTOGenre());
            res.DTOActors = obj.Actors?.Select(e => e.ToDTOActor());
            res.DTOAgeQualification = obj.AgeQualification?.ToDTOAgeQualification();
            res.Description = obj.Description;
            res.DTOImage = obj.Image;
            res.DTOSessions = obj.Sessions.Select(e => e.ToDTOSession());
            return res;
        }

        public static DTOActor ToDTOActor(this Actor actor)
        {
            var res = new DTOActor()
            {
                Id = actor.Id,
                FIO = actor.FIO,
            };
            return res;
        }
        public static DTOGenre ToDTOGenre(this Genre genre)
        {
            var res = new DTOGenre()
            {
                Id = genre.Id,
                Name = genre.Name,
            };
            return res;
        }
        public static DTOAgeQualification ToDTOAgeQualification(this AgeQualification age)
        {
            var res = new DTOAgeQualification()
            {
                Id = age.Id,
                Name = age.Name,
            };
            return res;
        }
        public static Performance FromDTOPerfomance(this DTOPerformance obj)
        {
            var res = new Performance()
            {
                Id = obj.Id,
                Name = obj.Name,
                Duration = obj.Duration,
                Actors = obj.DTOActors?.Select(a => a.FromDTOActor()),
                Genres = obj.DTOGenres?.Select(g => g.FromDTOGenre()),
                AgeQualification = obj.DTOAgeQualification?.FromDTOAgeQualification(),
                Description = obj.Description,
                Image = obj.DTOImage,
            };
            return res;
        }
        public static Actor FromDTOActor(this DTOActor actor)
        {
            var res = new Actor()
            {
                Id = actor.Id,
                FIO = actor.FIO,
            };
            return res;
        }
        public static Genre FromDTOGenre(this DTOGenre genre)
        {
            var res = new Genre()
            {
                Id = genre.Id,
                Name = genre.Name,
            };
            return res;
        }
        public static AgeQualification FromDTOAgeQualification(this DTOAgeQualification age)
        {
            var res = new AgeQualification()
            {
                Id = age.Id,
                Name = age.Name,
            };
            return res;
        }
        public static DTOSession ToDTOSession(this Session session)
        {
            var res = new DTOSession()
            {
                Id = session.Id,
                DTOPerformance = session.Performance?.ToDTOPerformance(),
                Date = session.Date,
                QuantityPlace = session.QuantityPlace,
            };
            return res;
        }
        public static Session FromDTOSession(this DTOSession session)
        {
            var res = new Session()
            {
                Id = session.Id,
                Performance = session.DTOPerformance?.FromDTOPerfomance(),
                Date = session.Date,
                QuantityPlace = session.QuantityPlace,
            };
            return res;
        }
        public static DTOHall ToDTOHall(this Hall hall)
        {
            var res = new DTOHall()
            {
                Id = hall.Id,
                Type = hall.Type,
            };
            return res;
        }
        public static Hall FromDTOHall(this DTOHall dTOHall)
        {
            var res = new Hall()
            {
                Id = dTOHall.Id,
                Type = dTOHall.Type,
            };
            return res;
        }

        public static DTOTypeOfSeat ToDTOTypeOfSeat(this TypeOfSeat typeOfSeat)
        {
            var res = new DTOTypeOfSeat()
            {
                Id = typeOfSeat.Id,
                Price = typeOfSeat.Price,
                Name = typeOfSeat.Name,
            };
            return res;
        }

        public static TypeOfSeat FromDTOTypeOfSeat(this DTOTypeOfSeat typeOfSeat)
        {
            var res = new TypeOfSeat()
            {
                Id = typeOfSeat.Id,
                Price = typeOfSeat.Price,
                Name = typeOfSeat.Name,
            };
            return res;
        }

        public static DTOPlace ToDTOPlace(this Place place)
        {
            var res = new DTOPlace()
            {
                Id = place.Id,
                DTOHall = place.Hall?.ToDTOHall(),
                DTOTypeOfSeat = place.TypeOfSeat?.ToDTOTypeOfSeat(),
                Row = place.Row,
            };
            return res;
        }

        public static Place FromDTOPlace(this DTOPlace place)
        {
            var res = new Place()
            {
                Id = place.Id,
                Hall = place.DTOHall.FromDTOHall(),
                Row = place.Row,
                TypeOfSeat = place.DTOTypeOfSeat.FromDTOTypeOfSeat(),
            };
            return res;
        }

        public static DTOUser ToDTOUser(this User user)
        {
            var res = new DTOUser()
            {
                Id = user.Id,
                FullName = user.FullName,
                Role = user.Role,
                Age = user.Age,
                Login = user.Login,
                Password = user.Password,
                Mail = user.Mail,
            };
            return res;
        }

        public static User FromDTOUser(this DTOUser user)
        {
            var res = new User()
            {
                Id = user.Id,
                FullName = user.FullName,
                Role = user.Role,
                Age = user.Age,
                Login = user.Login,
                Password = user.Password,
                Mail = user.Mail,
            };
            return res;
        }

        public static DTOTicket ToDTOTicket(this Ticket ticket)
        {
            var res = new DTOTicket()
            {
                Id = ticket.Id,
                dTOSession = ticket.Session?.ToDTOSession(),
                dTOPlace = ticket.Place?.ToDTOPlace(),
                dTOUser = ticket.User?.ToDTOUser(),
                DatePurchase = ticket.DatePurchase,
            };
            return res;
        }

        public static Ticket FromDTOTicket(this DTOTicket ticket)
        {
            var res = new Ticket()
            {
                Id = ticket.Id,
                Session = ticket.dTOSession.FromDTOSession(),
                Place = ticket.dTOPlace.FromDTOPlace(),
                User = ticket.dTOUser.FromDTOUser(),
                DatePurchase = ticket.DatePurchase,
            };
            return res;
        }
    }
}
