using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TicketRepository : IRepository<Model.Ticket>
    {
        private readonly ApplicationContext _context = null;
        public TicketRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Task<Ticket> Create(Ticket entity)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> Delete(Ticket entity)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> GetById(int id)
        {
            return _context.Tickets.Include(e => e.User).Include(e => e.Session).Include(e => e.Place).FirstOrDefaultAsync(e => e.Id == id);
        }

        public IEnumerable<Ticket> Read()
        {
            return _context.Tickets.Include(e => e.User).Include(e => e.Session).Include(e => e.Place).Include(e=>e.Session.Performance);
        }

        public Task<Ticket> Update(Ticket entity)
        {
            throw new NotImplementedException();
        }
    }
}
