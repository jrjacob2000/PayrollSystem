using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Runtime.Serialization;
using System.Web;

namespace System.Web
{
    [DataContract]
    public class Operator : IIdentity, IPrincipal, IOperator
    {
        public Operator()
        {
            Groups = new List<string>();
            Roles = new Roles();
        }
        #region IIdentity Members

        public string AuthenticationType
        {
            get { return "Custom"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public string Name
        {
            get { return UserName; }
        }

        #endregion

        #region IPrincipal Members

        public IIdentity Identity
        {
            get { return (IIdentity)this; }
        }

        public bool IsInRole(string role)
        {
            return this.Roles.Contains(role) || this.HasPrivilege(role);
        }

        #endregion


        public bool IsInRole<FactType>(string role, FactType facts)
        {
            return this.Roles.Contains<FactType>(role, facts);
        }

        public bool HasPrivilege(string operation)
        {
            return this.Roles.GivesPrivilege(operation);
        }

        public bool HasPrivilege<FactType>(string operation, FactType facts)
        {
            return this.Roles.GivesPrivilege<FactType>(operation, facts);
        }

        public bool HasPrivilege(string privilege, EvaluationFact fact)
        {
            return this.Roles.GivesPrivilege<EvaluationFact>(privilege, fact);
        }


        public List<string> GetFlattenRolesAndPrivileges()
        {
            List<string> result = new List<string>();
            result.AddRange((this.Roles.OutOfContext().Select(p => p.Code)).ToList());
            result.AddRange((this.Roles.OutOfContext().SelectMany(p => p.Privileges.OutOfContext()).Select(u => u.Code)).ToList());
            return result;
        }

        //GetFacts

        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public List<string> Groups { get; set; }
        [DataMember]
        public Roles Roles { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public int LocaleId { get; set; }
        [DataMember]
        public int TimezoneId { get; set; }
        [DataMember]
        public Guid PersonId { get; set; }
        [DataMember]
        public bool IsDisabled { get; set; }

        #region IOperator Members


        //public EvaluationFact GetPartyFacts(Guid PartyId)
        //{
        //    return null;
        //}

        #endregion
    }
}