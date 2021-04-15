using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Place
    {
        public int Id { get; set; }
        public Hall Hall { get; set; }
        public int Row { get; set; }
        public TypeOfSeat TypeOfSeat { get; set; }
    }
}
