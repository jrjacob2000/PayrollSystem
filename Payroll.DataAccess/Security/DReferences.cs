using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.DataAccess.Security
{
    public class DReferences
    {
        public void CreateReference(Reference entity)
        {
            SecurityDataContext context = new SecurityDataContext();
            context.References.InsertOnSubmit(entity);
            context.SubmitChanges();
            
        }

        public void UpdateReference(Reference entity)
        {
            SecurityDataContext context = new SecurityDataContext();
            var result = context.References.Single(x => x.ReferenceTypeCode == entity.ReferenceTypeCode && x.ReferenceCode == entity.ReferenceCode);

            result.ReferenceValue = entity.ReferenceValue;
            result.Sequence = entity.Sequence;
                       
            context.SubmitChanges();

        }

        public void DeleteReference(Guid id)
        {
            SecurityDataContext context = new SecurityDataContext();
            //var result = context.References.Single(x => x.ReferenceTypeCode == referenceTypeCode && x.ReferenceCode == referenceCode);
            var result = context.References.Single(x => x.Id == id);
            result.IsDeleted = true;

            context.SubmitChanges();
        }

        public Reference GetReferenceById(Guid id)
        {
            SecurityDataContext context = new SecurityDataContext();
            return context.References.FirstOrDefault(x => x.Id == id);
        }

        public List<Reference> GetReferenceList()
        {
            SecurityDataContext context = new SecurityDataContext();
            return context.References.Where(x => x.IsDeleted == false || x.IsDeleted == null).ToList();
        }

        public List<Reference> GetReferenceByType(string referenceType)
        {
            SecurityDataContext context = new SecurityDataContext();
            return context.References.Where(x => x.ReferenceTypeCode.ToLower() == referenceType.ToLower() && (x.IsDeleted.HasValue ? x.IsDeleted.Value : false) == false).ToList();
        }

        public List<Entity.ReferenceType> GetReferenceTypeList()
        {
            SecurityDataContext context = new SecurityDataContext();
            return context.ReferenceTypes.Where(x => x.IsDeleted == false || x.IsDeleted == null)
                .Select(x =>
                    new Entity.ReferenceType()
            {
                ReferenceTypeCode = x.ReferenceTypeCode,
                Description = x.Description,
                IsDeleted = x.IsDeleted
            }).ToList();
        }
    }
}
