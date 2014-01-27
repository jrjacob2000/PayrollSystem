using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.DataAccess.Core
{
    public class DATaxTable
    {
        public Guid Create(TaxTable taxtable)
        {
            PayrollDataContext context = new PayrollDataContext();
            if (taxtable.Id == Guid.Empty)
                taxtable.Id = Guid.NewGuid();

            context.TaxTables.InsertOnSubmit(taxtable);
            context.SubmitChanges();

            return taxtable.Id;
        }

        public void Update(TaxTable taxtable)
        {
            PayrollDataContext context = new PayrollDataContext();
            
            var tax = context.TaxTables.Where(x=> x.Id == taxtable.Id).FirstOrDefault();
            tax.TaxCode = taxtable.TaxCode;
            tax.Description = taxtable.Description;
            tax.Exemption = taxtable.Exemption;

            context.SubmitChanges();

        }

        public void Delete(Guid id)
        {
            PayrollDataContext context = new PayrollDataContext();

            var tax = context.TaxTables.Where(x => x.Id == id).FirstOrDefault();

            tax.IsDeleted  = true;

            context.SubmitChanges();

        }

        public List<TaxTable> List()
        {
            PayrollDataContext context = new PayrollDataContext();

            return context.TaxTables.ToList();

        }
    }
}
