using DataLayer.Interfaces;

namespace DataLayer
{
    public class DataManager
    {
        public IBillsRepository BillsRepository { get; }
        public IOrganizationsRepository OrganizationsRepository { get; }
        public IUsersRepository UsersRepository { get; }

        public DataManager(IBillsRepository billsRepository, 
            IOrganizationsRepository organizationsRepository,
            IUsersRepository usersRepository)
        {
            BillsRepository = billsRepository;
            OrganizationsRepository = organizationsRepository;
            UsersRepository = usersRepository;
        }

    }
}
