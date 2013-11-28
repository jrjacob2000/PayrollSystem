using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.DataAccess.Security
{
    public class DAccountProfile
    {
        public Guid? CreateAccountProfile(AccountProfile entity)
        {
            Guid? result = null;
            try
            {
                SecurityDataContext context = new SecurityDataContext();
                context.AccountProfiles.InsertOnSubmit(entity);
                context.SubmitChanges();
                result = entity.Id;
            }
            catch 
            {
            }

            return entity.Id;
        }
    
        public void DeleteAccountProfile(Guid accountProfileId,bool softDelete)
        {
            SecurityDataContext context = new SecurityDataContext();
            var result = context.AccountProfiles.Single(x => x.Id == accountProfileId);

            if (softDelete)
            {
                result.IsDeleted = true;
            }
            else
            {
                context.AccountProfiles.DeleteOnSubmit(result);
            }

            context.SubmitChanges();
        }

        public AccountProfile GetAccoutProfileById(Guid id)
        {
            SecurityDataContext context = new SecurityDataContext();
            return context.AccountProfiles.FirstOrDefault(x => x.Id == id);
        }

        public List<AccountProfile> GetAccountProfileList()
        {
            SecurityDataContext context = new SecurityDataContext();
            return context.AccountProfiles.Where(x => x.IsDeleted == false).ToList();
        }

    }
}
