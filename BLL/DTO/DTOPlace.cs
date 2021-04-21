using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class DTOPlace
    {
        public int Id { get; set; }
        public DTOHall DTOHall { get; set; }
        public int Row { get; set; }
        public DTOTypeOfSeat DTOTypeOfSeat { get; set; }
    }
}
