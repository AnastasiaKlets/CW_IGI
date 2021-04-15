using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Ticket
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Session Session { get; set; }
        public Place Place { get; set; }
        public DateTime DatePurchase { get; set; }

    }
}
