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

                if (entity.Id == Guid.Empty)
                    entity.Id = Guid.NewGuid();

                context.AccountProfiles.InsertOnSubmit(entity);
                context.SubmitChanges();
                result = entity.Id;
            }
            catch 
            {
            }

            return entity.Id;
        }

        public void UpdateAccountProfile(AccountProfile entity)
        {
            try
            {
                SecurityDataContext context = new SecurityDataContext();
                var profile = context.AccountProfiles.Where(x => x.Id == entity.Id).FirstOrDefault();

                profile.Id = entity.Id;
                profile.FirstName = entity.FirstName;
                profile.LastName = entity.LastName;
                profile.FullName = entity.FullName;
                profile.Title = entity.Title;
                profile.JobTitle = entity.JobTitle; ;
                profile.IsMale = entity.IsMale;
                profile.IsDeleted = entity.IsDeleted;
                

                context.SubmitChanges();
                
            }
            catch
            {
            }

       
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
