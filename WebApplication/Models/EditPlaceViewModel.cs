using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class EditPlaceViewModel
    {
        public IEnumerable<TypeOfSeat> typeOfSeats { get; set; }
        public IEnumerable<Hall> halls { get; set; }
        public int id { get; set; }
        public int row { get; set; }
        public Hall hall { get; set; }
        public TypeOfSeat typeOfSeat { get; set; }
    }
}
