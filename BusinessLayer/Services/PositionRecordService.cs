using BusinessLayer.Models;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class PositionRecordService
    {
        private readonly IPositionRecordsRepository _positionRecordsRepository;

        public PositionRecordService(DataManager dataManager)
        {
            _positionRecordsRepository = dataManager.PositionRecordsRepository;
        }

        public PositionRecordModel GetPositionRecordModelById(long id)
        {
            return ToModel(_positionRecordsRepository.GetPositionRecordById(id));
        }
        public List<PositionRecordModel> GetAllPositionRecordModels()
        {
            var dbSet = _positionRecordsRepository.GetAllPositionRecords();
            var result = new List<PositionRecordModel>();
            foreach (var positionRecord in dbSet)
            {
                result.Add(ToModel(positionRecord));
            }
            return result;
        }
        public void SavePositionRecordModel(PositionRecordModel model)
        {
            _positionRecordsRepository.Save(model.PositionRecord);
        }

        private PositionRecordModel ToModel(PositionRecord positionRecord)
        {
            return new PositionRecordModel() { PositionRecord = positionRecord };
        }
    }
}
