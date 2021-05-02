using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class BuyViewModel
    {
        public readonly PerformanceService _performanceService;

        public BuyViewModel(PerformanceService performanceService)
        {
            _performanceService = performanceService;
        }



        public int pId;
        public int uId;
    }
}
