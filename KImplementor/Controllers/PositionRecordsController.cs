using BusinessLayer.Models;
using BusinessLayer.Services;
using DataLayer.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KImplementor.Controllers
{
    [ApiController]
    [Authorize]
    public class PositionRecordsController : Controller
    {
        private readonly PositionRecordService _positionRecordService;

        public PositionRecordsController(PositionRecordService positionRecordService)
        {
            _positionRecordService = positionRecordService;
        }

        [HttpGet]
        public ActionResult<List<PositionRecordModel>> GetAll()
        {
            return Json(_positionRecordService.GetAllPositionRecordModels());
        }

        [HttpGet("{id}")]
        public ActionResult<PositionRecordModel> GetById(long id)
        {
            try
            {
                return Json(_positionRecordService.GetPositionRecordModelById(id));
            }
            catch (PositionRecordNotFoundException ex)
            {
                return BadRequest(new { errorText = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult<PositionRecordModel> Save(PositionRecordModel model)
        {
            _positionRecordService.SavePositionRecordModel(model);
            return Ok();
        }
    }
}
