using BLL.DTO;
using BLL.DTO.Converters;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TicketSirvice
    {
        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IRepository<Place> _repositoryPlace;
        private readonly IRepository<TypeOfSeat> _repositoryTypeOfSeat;

        public TicketSirvice(IRepository<Ticket> ticketRepository, IRepository<Place> repositoryPlace, IRepository<TypeOfSeat> repositoryTypeOfSeat)
        {
            _ticketRepository = ticketRepository;
            _repositoryPlace = repositoryPlace;
            _repositoryTypeOfSeat = repositoryTypeOfSeat;
        }

        public async Task<Ticket> BuyTicket(int ticketId, User user)
        {
            Ticket ticket = await _ticketRepository.GetById(ticketId);
            ticket.User = user;
            ticket.DatePurchase = DateTime.Now;
            return await _ticketRepository.Update(ticket);
        }

        public DTOTicket GEtTicketById (int id)
        {
            return _ticketRepository.GetById(id).Result.ToDTOTicket();
        }

        public void DeleteTicket(DTOTicket ticket)
        {
             _ticketRepository.Delete(ticket.FromDTOTicket());
        }

      
    }
}
