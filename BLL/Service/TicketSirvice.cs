using BLL.DTO;
using BLL.DTO.Converters;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq; 
using System.Threading.Tasks;

namespace BLL
{
    public class TicketSirvice
    {
        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IRepository<Place> _repositoryPlace;
        private readonly IRepository<TypeOfSeat> _repositoryTypeOfSeat;
        private readonly DAL.TicketRepository _ticketsReadOnly = null;

        public TicketSirvice(IRepository<Ticket> ticketRepository, IRepository<Place> repositoryPlace, IRepository<TypeOfSeat> repositoryTypeOfSeat, TicketRepository ticketsReadOnly)
        {
            _ticketRepository = ticketRepository;
            _repositoryPlace = repositoryPlace;
            _repositoryTypeOfSeat = repositoryTypeOfSeat;
            _ticketsReadOnly = ticketsReadOnly;
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

        public IEnumerable<DTOTicket> GetTicketsByUserId(int id)
        {
            var tickets = _ticketsReadOnly.Read();
            return tickets.Where(e => e.User?.Id == id).Select(e=>e.ToDTOTicket());
        }

      
    }
}
