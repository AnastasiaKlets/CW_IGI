using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class CreatePlaceViewModel
    {
        public IEnumerable<TypeOfSeat> typeOfSeats { get; set; }
        public IEnumerable<Hall> halls { get; set; }
    }
}
