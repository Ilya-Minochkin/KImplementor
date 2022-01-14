using BusinessLayer;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KImplementor.Controllers
{
    public class BillController : Controller
    {
        private readonly BillService _billService;

        public BillController(ServiceManager serviceManager)
        {
            _billService = serviceManager.BillService;
        }
    }
}
