using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
