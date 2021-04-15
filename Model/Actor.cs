using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Actor
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public IEnumerable<Performance> Performances { get; set; }
    }
}
