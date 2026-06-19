using System.Collections.Generic;
using BusinessObjects;
using Repositories;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService()
        {
            _accountRepository = new AccountRepository();
        }

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public List<AccountMember> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public AccountMember? CheckLogin(string userName, string password)
        {
            return _accountRepository.CheckLogin(userName, password);
        }

        public AccountMember? GetAccountByUserName(string userName)
        {
            return _accountRepository.GetAccountByUserName(userName);
        }

        public AccountMember CreateAccount(AccountMember account)
        {
            return _accountRepository.CreateAccount(account);
        }
    }
}
