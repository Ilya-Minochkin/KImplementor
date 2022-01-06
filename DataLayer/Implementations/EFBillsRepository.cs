﻿using DataLayer.Entities;
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

        public Bill GetBillById(long billId)
        {
            return _context.Bills.Find(billId);
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