using BusinessLayer;
using BusinessLayer.Models;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KImplementor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationsController : Controller
    {
        private readonly OrganizationService _organizationService;
        public OrganizationsController(ServiceManager serviceManager)
        {
            _organizationService = serviceManager.OrganizationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrganizationModel>>> Get()
        {
            return new JsonResult(await _organizationService.GetAllAsync());
        }

        public async Task<ActionResult<OrganizationModel>> Get(long id)
        {
            return new JsonResult(await _organizationService.GetOrganizationModelByIdAsync(id));
        }
    }
}
