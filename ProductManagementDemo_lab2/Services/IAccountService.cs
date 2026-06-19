using System.Collections.Generic;
using BusinessObjects;

namespace Services
{
    public interface IAccountService
    {
        List<AccountMember> GetAccounts();
        AccountMember? CheckLogin(string userName, string password);
        AccountMember? GetAccountByUserName(string userName);
        AccountMember CreateAccount(AccountMember account);
    }
}
