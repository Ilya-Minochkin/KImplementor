using BusinessLayer.Services;
using DataLayer;

namespace BusinessLayer
{
    public class ServiceManager
    {
        private readonly DataManager _dataManager;
        public OrganizationService OrganizationService { get; }
        public UserService UserService { get; }
        public AuthService AuthService { get; }


        public ServiceManager(DataManager dataManager)
        {
            _dataManager = dataManager;
            OrganizationService = new OrganizationService(_dataManager);
            UserService = new UserService(_dataManager);
            AuthService = new AuthService(_dataManager, UserService);
        }
    }
}
