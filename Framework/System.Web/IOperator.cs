using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web
{
    public interface IOperator
    {
        Guid Id { get; set; }
        string UserName { get; set; }
        Roles Roles { get; set; }
        string Email { get; set; }
        int LocaleId { get; set; }
        int TimezoneId { get; set; }
        Guid PersonId { get; set; }
        bool IsInRole<FactType>(string role, FactType fact);
        bool HasPrivilege(string operation);
        bool HasPrivilege<FactType>(string privilege, FactType fact);
        bool IsDisabled { get; set; }

        //EvaluationFact GetPartyFacts(Guid PartyId);
        //bool HasPrivilege(string privilege, EvaluationFact fact);
    }
}