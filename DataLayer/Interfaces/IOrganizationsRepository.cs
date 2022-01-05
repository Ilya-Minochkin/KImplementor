using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IOrganizationsRepository
    {
        IEnumerable<Organization> GetAllOrganizations();
        Task<IEnumerable<Organization>> GetAllOrganizationsAsync();
        Organization GetOrganizationById(long organizationId);
        Task<Organization> GetOrganizationByIdAsync(long organizationId);
        void SaveOrganization(Organization organization);
        void DeleteOrganization(Organization organization);
    }
}
