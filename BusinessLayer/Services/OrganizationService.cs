using BusinessLayer.Models;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class OrganizationService
    {
        private readonly IOrganizationsRepository _organizationsRepository;
        public OrganizationService(DataManager dataManager)
        {
            _organizationsRepository = dataManager.OrganizationsRepository;
        }

        public OrganizationModel GetOrganizationModelById(long id)
        {
            var organization = _organizationsRepository.GetOrganizationById(id);
            return ToModel(organization);
        }

        public async Task<OrganizationModel> GetOrganizationModelByIdAsync(long id)
        {
            return ToModel(await _organizationsRepository.GetOrganizationByIdAsync(id));
        }

        public IEnumerable<OrganizationModel> GetAll()
        {
            var organizations = _organizationsRepository.GetAllOrganizations();
            return organizations.Select(o => ToModel(o));
        }

        public async Task<IEnumerable<OrganizationModel>> GetAllAsync()
        {
            return await Task.Run(() => _organizationsRepository
                    .GetAllOrganizationsAsync().Result.Select(o => ToModel(o))
                );
        }

        public void SaveOrganizationModel(OrganizationModel organizationModel)
        {
            _organizationsRepository.SaveOrganization(organizationModel.Organization);
        }


        private static OrganizationModel ToModel(Organization organization)
        {
            return new OrganizationModel() { Organization = organization };
        }
    }
}
