using DataLayer.Entities;
using System.Collections.Generic;

namespace DataLayer.Interfaces
{
    public interface IBillsRepository
    {
        IEnumerable<Bill> GetAllBills();
        Bill GetBillById(long billId);
        void SaveBill(Bill bill);
        void DeleteBill(Bill bill);
    }
}
