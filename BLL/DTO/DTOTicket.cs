using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class DTOTicket
    {
        public int Id { get; set; }
        public DTOUser dTOUser { get; set; }
        public DTOSession dTOSession { get; set; }
        public DTOPlace dTOPlace { get; set; }
        public DateTime DatePurchase { get; set; }
    }
}
