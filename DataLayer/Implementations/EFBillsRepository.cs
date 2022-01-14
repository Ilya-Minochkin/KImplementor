using DataLayer.Entities;
using DataLayer.Exceptions;
using DataLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Implementations
{
    public class EFBillsRepository : IBillsRepository
    {
        private readonly EFDBContext _context;
        public EFBillsRepository(EFDBContext context)
        {
            _context = context;
        }

        public void DeleteBill(Bill bill)
        {
            _context.Remove(bill);
            _context.SaveChanges();
        }

        public IEnumerable<Bill> GetAllBills()
        {
            return _context.Bills.ToList();
        }

        public IEnumerable<Bill> GetAllBillsForUser(User user)
        {
            return _context.Bills.Where(bill => bill.Owner.Id == user.Id);
        }

        public Bill GetBillById(long billId)
        {
            var result = _context.Bills.FirstOrDefault(b => b.Id == billId);
            if (result == null)
                throw new BillNotFoundException($"Bill with id {billId} not found");
            return result;
        }

        public void SaveBill(Bill bill)
        {
            if (bill.Id == 0)
            {
                _context.Bills.Add(bill);
            }
            else
            {
                _context.Bills.Update(bill);
            }
            _context.SaveChanges();
        }
    }
}
