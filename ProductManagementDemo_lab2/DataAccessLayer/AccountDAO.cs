using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;

namespace DataAccessLayer
{
    public class AccountDAO
    {
        private static AccountDAO? instance;
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null) instance = new AccountDAO();
                return instance;
            }
        }

        public List<AccountMember> GetAccounts()
        {
            using var context = new MyStoreContext();
            return context.AccountMembers.ToList();
        }

        public AccountMember? CheckLogin(string userName, string password)
        {
            using var context = new MyStoreContext();
            return context.AccountMembers
                .FirstOrDefault(a => a.UserName == userName && a.Password == password);
        }

        public AccountMember? GetAccountByUserName(string userName)
        {
            using var context = new MyStoreContext();
            return context.AccountMembers.FirstOrDefault(a => a.UserName == userName);
        }

        public AccountMember CreateAccount(AccountMember account)
        {
            using var context = new MyStoreContext();
            context.AccountMembers.Add(account);
            context.SaveChanges();
            return account;
        }
    }
}
