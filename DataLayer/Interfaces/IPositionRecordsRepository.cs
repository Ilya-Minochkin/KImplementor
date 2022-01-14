using DataLayer.Entities;
using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
    public interface IPositionRecordsRepository
    {
        public PositionRecord GetPositionRecordById(long id);
        public List<PositionRecord> GetAllPositionRecords();
        public void Save(PositionRecord positionRecord);
        public void Delete(PositionRecord positionRecord);
    }
}
