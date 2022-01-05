using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class DataManager
    {
        private readonly IBillsRepository _billsRepository;
        private readonly IOrganizationsRepository _organizationsRepository;

        public DataManager(IBillsRepository billsRepository, IOrganizationsRepository organizationsRepository)
        {
            _billsRepository = billsRepository;
            _organizationsRepository = organizationsRepository;
        }

        public IBillsRepository BillsRepository => _billsRepository;
        public IOrganizationsRepository OrganizationsRepository => _organizationsRepository;
    }
}
