using BusinessLayer.Models;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class BillService
    {
        private readonly IBillsRepository _billsRepository;

        public BillService(DataManager dataManager)
        {
            _billsRepository = dataManager.BillsRepository;
        }

        public BillModel GetBillById(long id)
        {
            return ToModel(_billsRepository.GetBillById(id));
        }
        public List<BillModel> GetAllBillModelsForUser(User user)
        {
            var result = new List<BillModel>();
            var dbSet = _billsRepository.GetAllBillsForUser(user);
            foreach (var bill in dbSet)
            {
                result.Add(ToModel(bill));
            }
            return result;
        }

        public void Save(BillModel model)
        {
            _billsRepository.SaveBill(model.Bill);
        }

        private BillModel ToModel(Bill bill)
        {
            return new BillModel() { Bill = bill };
        }
    }
}
