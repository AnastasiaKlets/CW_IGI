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

        public TicketSirvice(IRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<Ticket> BuyTicket(int ticketId, User user)
        {
            Ticket ticket = await _ticketRepository.GetById(ticketId);
            ticket.User = user;
            ticket.DatePurchase = DateTime.Now;
            return await _ticketRepository.Update(ticket);
        }
    }
}
