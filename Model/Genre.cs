using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Performance> Performances { get; set; }
    }
}
