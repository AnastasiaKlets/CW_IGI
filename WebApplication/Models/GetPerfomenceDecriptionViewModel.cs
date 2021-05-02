using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class GetPerfomenceDecriptionViewModel
    {
        public BLL.DTO.DTOPerformance performance = null;
        public IEnumerable<BLL.DTO.DTOSession> session = null;

        public GetPerfomenceDecriptionViewModel(BLL.DTO.DTOPerformance performance, IEnumerable<BLL.DTO.DTOSession> session)
        {
            this.performance = performance;
            this.session = session;
        }
    }
}
