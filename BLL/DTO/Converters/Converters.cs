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
            res.Duration =obj.Duration;
            res.DTOActors = obj.Actors?.Select(e=>e.ToDTOActor());
            res.DTOGenres = obj.Genres?.Select(g => g.ToDTOGenre());
            res.DTOAgeQualification = obj.AgeQualification?.ToDTOAgeQualification();
            res.Description = obj.Description;
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
            var res = new DTOGenre() { 
                Id = genre.Id,
                Name = genre.Name,
            };
            return res;
        }
        public static DTOAgeQualification  ToDTOAgeQualification(this AgeQualification age)
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
                Actors = obj.DTOActors?.Select(a =>a.FromDTOActor()),
                Genres = obj.DTOGenres?.Select(g=>g.FromDTOGenre()),
                AgeQualification = obj.DTOAgeQualification?.FromDTOAgeQualification(),
                Description = obj.Description,
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
        //public static DTOTicket ToDTOTicket(this Ticket ticket)
        //{
        //    var res = new DTOTicket()
        //    {
        //        Id = ticket.Id,
        //        dTOSession = ticket.Session.ToDTOSession(),
                
        //    };
        //    return res;
        //} 

    }
}
