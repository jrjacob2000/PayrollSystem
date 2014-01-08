using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Payroll.DataAccess.Security
{
    public class DAccounts
    {
        public bool ValidateAccount(string userName, string password)
        {
            SecurityDataContext context = new SecurityDataContext();
            var account = context.Accounts.Where(x => x.UserName == userName && x.Password == password);

            return account.Count() > 0;

        }
        public void CreateAccount(Account entity)
        {
            SecurityDataContext context = new SecurityDataContext();
            context.Accounts.InsertOnSubmit(entity);
            context.SubmitChanges();

        }

        public List<Account> List()
        {
            SecurityDataContext context = new SecurityDataContext();
            return context.Accounts.ToList();
        }

        public Account Get(Guid Id)
        {
            SecurityDataContext context = new SecurityDataContext();
            var result = context.Accounts.Single(x => x.Id == Id);
                        
            return result;
        }


        public void ChangePassword(Guid accountId, string newPassword)
        {
            SecurityDataContext context = new SecurityDataContext();
            var result = context.Accounts.Single(x => x.Id == accountId);

            result.Password = newPassword;
            result.ChangePasswordOnFirstLogon = false;

            context.SubmitChanges();

        }

        public void DeleteAccount(Guid accountId)
        {
            SecurityDataContext context = new SecurityDataContext();
            var result = context.Accounts.Single(x => x.Id == accountId);

            result.IsDeleted = true;
            context.SubmitChanges();
        }

        public System.Web.Operator GetOperator(string username)
        {
            System.Web.Operator optr = new System.Web.Operator();
            SecurityDataContext context = new SecurityDataContext();

            var acct = context.Accounts.Where(a => a.UserName == username).FirstOrDefault();

            if (acct != null)
            {
                optr.Id = acct.Id;
                optr.UserName = acct.UserName;
                optr.Email = acct.Email;
                optr.PersonId = acct.ProfileId;
                optr.IsDisabled = acct.IsDeleted.HasValue ? acct.IsDeleted.Value : false;

                Roles roles = new Roles();
                if (acct != null)
                {
                    roles.AddRange(GetRoles(acct.Id));
                    optr.Roles = roles;
                }
            }

           
            return optr;

        }

        public void AddRoles(Guid accountId, List<string> roleCodes)
        {
            SecurityDataContext context = new SecurityDataContext();

            DeleteRoles(accountId);

            foreach (string roleCode in roleCodes)
            {
                AccountHasRole ahr = new AccountHasRole()
                {
                    AccountId = accountId,
                    RoleCode = roleCode
                };
                context.AccountHasRoles.InsertOnSubmit(ahr);
            }
            context.SubmitChanges();
        }

        public void DeleteRoles(Guid accountId)
        {
            try
            {
                SecurityDataContext context = new SecurityDataContext();

                var roles = context.AccountHasRoles.Where(x => x.AccountId == accountId).ToList();

                context.AccountHasRoles.DeleteAllOnSubmit(roles);
                context.SubmitChanges();
                context.Dispose();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Role> GetRoles(Guid accountId)
        {
            List<Role> result = new List<Role>();
            SecurityDataContext context = new SecurityDataContext();

            var refRoles = context.References.Where(x => x.ReferenceTypeCode == "Role").ToList();

            var roles =
                from a in context.AccountHasRoles.Where(x => x.AccountId == accountId)
                select new Role()
                {
                    Code = a.RoleCode,
                    
                };
            
            foreach(Role role in roles)
            {
                Privileges privilege = new Privileges();
                privilege.AddRange(GetPrivileges(role.Code));

                role.Privileges = privilege;
                result.Add(role);
            }
            return result.ToList();
        }

        private List<Privilege> GetPrivileges(string roleCode)
        {
            SecurityDataContext context = new SecurityDataContext();
            var result =  (from a in context.RoleCanPerforms.Where(x => x.RoleCode == roleCode)
                              select new Privilege()
                              {
                                  Code = a.OperationCode
                              }).ToList();

            return result;
        }
                
    }
}
