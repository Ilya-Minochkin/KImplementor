using DataLayer.Entities;
using DataLayer.Exceptions;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Implementations
{
    public class EFOrganizationsRepository : IOrganizationsRepository
    {
        private readonly EFDBContext _context;
        public EFOrganizationsRepository(EFDBContext context)
        {
            _context = context;
        }
        ~EFOrganizationsRepository()
        {
            Console.WriteLine("Delete");
        }
        public void DeleteOrganization(Organization organization)
        {
            _context.Organizations.Remove(organization);
            _context.SaveChanges();
        }

        public IEnumerable<Organization> GetAllOrganizations()
        {
            return _context.Organizations.ToList();
        }

        public Organization GetOrganizationById(long organizationId)
        {
            return _context.Organizations.Find(organizationId);
        }

        public void SaveOrganization(Organization organization)
        {
            if (organization.Id == 0)
            {
                _context.Organizations.Add(organization);
            }
            else
            {
                _context.Organizations.Update(organization);
            }
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Organization>> GetAllOrganizationsAsync()
        {
            return await _context.Organizations.ToListAsync();
        }

        public async Task<Organization> GetOrganizationByIdAsync(long organizationId)
        {
            var result = await _context.Organizations.FindAsync(organizationId);
            if (result == null)
                throw new OrganizationNotFoundException($"Organization with id = {organizationId} is not found!");

            return result;
        }
    }
}
