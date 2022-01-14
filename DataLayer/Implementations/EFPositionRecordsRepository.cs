using DataLayer.Entities;
using DataLayer.Enums;
using DataLayer.Exceptions;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Implementations
{
    public class EFPositionRecordsRepository : IPositionRecordsRepository
    {
        private readonly EFDBContext _context;

        public EFPositionRecordsRepository(EFDBContext context)
        {
            _context = context;
        }

        public void Delete(PositionRecord positionRecord)
        {
            _context.PositionRecords.Remove(positionRecord);
            _context.SaveChanges();
        }

        public List<PositionRecord> GetAllPositionRecords()
        {
            return _context.PositionRecords.ToList();
        }

        public PositionRecord GetPositionRecordById(long id)
        {
            var result = _context.PositionRecords.FirstOrDefault(pr => pr.Id == id);
            if (result == null)
                throw new PositionRecordNotFoundException($"Position Record with id {id} not found!");
            return result;
        }

        public void Save(PositionRecord positionRecord)
        {
            throw new NotImplementedException();
        }
    }
}
