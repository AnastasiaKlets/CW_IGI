using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Session
    {
        public int Id { get; set; }
        public Performance Performance { get; set; }
        public DateTime Date { get; set; }
        public int QuantityPlace { get; set; }
    }
}
