using DataLayer.Interfaces;

namespace DataLayer
{
    public class DataManager
    {
        public IBillsRepository BillsRepository { get; }
        public IOrganizationsRepository OrganizationsRepository { get; }
        public IUsersRepository UsersRepository { get; }

        public DataManager(IBillsRepository billsRepository = default(IBillsRepository),
            IOrganizationsRepository organizationsRepository = default(IOrganizationsRepository),
            IUsersRepository usersRepository = default(IUsersRepository))
        {
            BillsRepository = billsRepository;
            OrganizationsRepository = organizationsRepository;
            UsersRepository = usersRepository;
        }

    }
}
