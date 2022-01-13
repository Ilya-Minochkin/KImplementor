using BusinessLayer;
using BusinessLayer.Models;
using BusinessLayer.Services;
using DataLayer.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KImplementor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
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
        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizationModel>> Get(long id)
        {
            try
            {
                return new JsonResult(await _organizationService.GetOrganizationModelByIdAsync(id));
            }
            catch (OrganizationNotFoundException ex)
            {
                return BadRequest(new { errorText = ex.Message });
            }
        }
        public ActionResult<OrganizationModel> Save(OrganizationModel model)
        {
            _organizationService.SaveOrganizationModel(model);
            return Ok();
        }
    }
}
