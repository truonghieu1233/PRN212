using System.Collections.Generic;
using BusinessObjects;

namespace Repositories
{
    public interface IAccountRepository
    {
        List<AccountMember> GetAccounts();
        AccountMember? CheckLogin(string userName, string password);
        AccountMember? GetAccountByUserName(string userName);
        AccountMember CreateAccount(AccountMember account);
    }
}
