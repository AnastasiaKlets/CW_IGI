using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class DTOPlace
    {
        public int Id { get; set; }
        public DTOHall dTOHall { get; set; }
        public int Row { get; set; }
        public DTOTypeOfSeat dTOTypeOfSeat { get; set; }
    }
}
