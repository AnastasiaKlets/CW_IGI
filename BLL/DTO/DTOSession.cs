using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class DTOSession
    {
        public int Id { get; set; }
        public DTOPerformance DTOPerformance { get; set; }
        public DateTime Date { get; set; }
        public int QuantityPlace { get; set; }
    }
}
