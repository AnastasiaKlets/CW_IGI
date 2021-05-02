using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class SeatsSchema
    {
        public byte[][] Seats { get; } = new byte[7][] {
            new byte[]{ 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
             new byte[]{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
             new byte[]{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
             new byte[]{ 0, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 },
             new byte[]{ 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
             new byte[]{ 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
             new byte[]{ 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0 },
            };
    }
}
