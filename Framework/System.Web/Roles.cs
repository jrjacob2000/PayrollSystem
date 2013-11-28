using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using Framework.Helpers.Linq;

namespace System.Web
{
    public static class ContextHelper
    {
        public static bool Match(this Role role)
        {
            return (String.IsNullOrEmpty(role.Predicate));
        }

        public static bool Match(this Privilege privilege)
        {
            return (String.IsNullOrEmpty(privilege.Predicate));
        }

        public static bool Match<T>(this Role role, T ctx)
        {
            if (String.IsNullOrEmpty(role.Predicate)) return true;
            Func<T, bool> DoMatch;
            DoMatch = DynamicExpression.ParseLambda<T, bool>(role.Predicate, null).Compile();
            return DoMatch(ctx);
        }

        public static bool Match<T>(this Privilege privilege, T ctx)
        {
            if (String.IsNullOrEmpty(privilege.Predicate)) return true;
            Func<T, bool> DoMatch;
            DoMatch = DynamicExpression.ParseLambda<T, bool>(privilege.Predicate, null).Compile();
            return DoMatch(ctx);
        }

        public static Privileges WithNoContext(this Roles roles)
        {
            Privileges result = new Privileges();
            result.AddRange(roles.Where(r => r.Match()).SelectMany(u => u.Privileges).Where(p => p.Match()).ToList());
            return result;
        }


        public static Privileges WithinContext<T>(this Roles roles, T context)
        {
            Privileges result = new Privileges();
            result.AddRange(roles.Where(r => r.Match<T>(context)).SelectMany(u => u.Privileges).Where(p => p.Match<T>(context)).ToList());
            return result;
        }
    }

    public class Roles : List<Role>
    {
        public Roles InContext<T>(T ctx)
        {
            Roles result = OutOfContext();
            PredicateList<T> predicates = new PredicateList<T>();
            foreach (Role hr in this.Where(u => u.Predicate != null)) predicates.Add(new Predicate<T> { Evaluation = hr.Predicate });
            PredicateList<T> matching = predicates.Match(ctx);
            foreach (Role hr in this.Where(u => u.Predicate != null)) if (matching.Contains(new Predicate<T> { Evaluation = hr.Predicate })) result.Add(hr);
            return result;
        }

        public Roles OutOfContext()
        {
            Roles result = new Roles();
            result.AddRange(this.Where(u => u.Predicate == null).ToList());
            return result;
        }

        public bool Contains(string roleCode, string predicate)
        {
            return (this.Count(u => u.Code == roleCode && u.Predicate == predicate) > 0);
        }

        public void Add(string roleCode, string predicate)
        {
            if (!this.Contains(roleCode, predicate)) this.Add(new Role { Code = roleCode, Predicate = predicate });
        }

        internal bool GivesPrivilege<FactType>(string operation, FactType facts)
        {
            return (this.WithinContext<FactType>(facts).Where(u => u.Code == operation).Count() > 0);
        }

        internal bool GivesPrivilege(string operation)
        {
            return (this.WithNoContext().Where(u => u.Code == operation).Count() > 0);
        }

        internal bool Contains(string role)
        {
            return this.OutOfContext().Where(u => u.Code == role).Count() > 0;
        }

        internal bool Contains<FactType>(string role, FactType facts)
        {
            return this.InContext<FactType>(facts).Select(u => u.Code == role).Count() > 0;
        }
    }

    [DataContract]
    public class PredicateList<T> : List<Predicate<T>>
    {
        public PredicateList<T> Match(T ctx)
        {
            PredicateList<T> result = new PredicateList<T>();
            foreach (Predicate<T> predicate in this) if (predicate.Match(ctx)) result.Add(predicate);
            return result;
        }
    }

    [DataContract]
    public class Predicate<T>
    {
        public string Evaluation { get; set; }

        public Func<T, bool> DoMatch;
        public bool Match(T ctx)
        {
            DoMatch = DynamicExpression.ParseLambda<T, bool>(Evaluation, null).Compile();
            return DoMatch(ctx);
        }
    }

    [DataContract]
    public class Role
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Predicate { get; set; }
        [DataMember]
        public Privileges Privileges { get; set; }
    }

    [DataContract]
    public class Privilege
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Predicate { get; set; }
    }

    public class Privileges : List<Privilege>
    {

        public Privileges InContext<T>(T ctx)
        {
            Privileges result = OutOfContext();
            PredicateList<T> predicates = new PredicateList<T>();
            foreach (Privilege hr in this.Where(u => u.Predicate != null)) predicates.Add(new Predicate<T> { Evaluation = hr.Predicate });
            PredicateList<T> matching = predicates.Match(ctx);
            foreach (Privilege hr in this.Where(u => u.Predicate != null)) if (matching.Contains(new Predicate<T> { Evaluation = hr.Predicate })) result.Add(hr);
            return result;
        }

        public Privileges OutOfContext()
        {
            Privileges result = new Privileges();
            result.AddRange(this.Where(u => u.Predicate == null).ToList());
            return result;
        }
    }
}