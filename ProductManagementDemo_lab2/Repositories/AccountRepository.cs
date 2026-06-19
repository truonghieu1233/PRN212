using System.Collections.Generic;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public List<AccountMember> GetAccounts()
        {
            return AccountDAO.Instance.GetAccounts();
        }

        public AccountMember? CheckLogin(string userName, string password)
        {
            return AccountDAO.Instance.CheckLogin(userName, password);
        }

        public AccountMember? GetAccountByUserName(string userName)
        {
            return AccountDAO.Instance.GetAccountByUserName(userName);
        }

        public AccountMember CreateAccount(AccountMember account)
        {
            return AccountDAO.Instance.CreateAccount(account);
        }
    }
}
