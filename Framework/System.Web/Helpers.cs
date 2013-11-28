using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web
{
    public class Switch
    {
       public object Object{get; private set;}
       public Switch(object o)
       {
           Object = o;
       }
    }

    public class Switch<T>
    {
        public Switch(T o)
        {
            Object = o;
        }

        public T Object { get; private set; }
    }

    public class Switch<T, R>
    {
        public Switch(T o)
        {
            Object = o;
        }

        public T Object { get; private set; }
        public bool HasValue { get; private set; }
        public R Value { get; private set; }

        public void Set(R value)
        {
            Value = value;
            HasValue = true;
        }
    }

    public static class SwitchExtensions
    {
        public static Switch Case(this Switch s, object o, Action<object> a)
        {

            return Case(s, o, a, false);
        }

        public static Switch Case(this Switch s, object o, Action<object> a, bool fallThrough)
        {

            return Case(s, x => object.Equals(x, o), a, fallThrough);
        }

        public static Switch Case(this Switch s, Func<object, bool> c, Action<object> a)
        {

            return Case(s, c, a, false);
        }

        public static Switch Case(this Switch s, Func<object, bool> c, Action<object> a, bool fallThrough)
        {

            if (s == null)
            {

                return null;
            }

            else if (c(s.Object))
            {

                a(s.Object);

                return fallThrough ? s : null;
            }

            return s;
        }

        public static Switch Case<T>(this Switch s, Action<T> a) where T : class
        {

            return Case<T>(s, o => true, a, false);
        }

        public static Switch Case<T>(this Switch s, Action<T> a, bool fallThrough) where T : class
        {

            return Case<T>(s, o => true, a, fallThrough);
        }

        public static Switch Case<T>(this Switch s, Func<T, bool> c, Action<T> a) where T : class
        {

            return Case<T>(s, c, a, false);
        }

        public static Switch Case<T>(this Switch s, Func<T, bool> c, Action<T> a, bool fallThrough) where T : class
        {

            if (s == null)
            {

                return null;
            }

            else
            {

                T t = s.Object

                as T;
                if (t != null)
                {

                    if (c(t))
                    {

                        a(t);

                        return fallThrough ? s : null;
                    }

                }

            }

            return s;
        }

        public static Switch<T, R> Case<T, R>(this Switch<T, R> s, T t, Func<T, R> f)
        {

            return Case<T, R>(s, x => object.Equals(x, t), f);
        }

        public static Switch<T, R> Case<T, R>(this Switch<T, R> s, Func<T, bool> c, Func<T, R> f)
        {

            if (!s.HasValue && c(s.Object))
            {

                s.Set(f(s.Object));

            }

            return s;
        }

        public static R Default<T, R>(this Switch<T, R> s, Func<T, R> f)
        {

            if (!s.HasValue)
            {

                s.Set(f(s.Object));

            }

            return s.Value;
        }

        public static void Default<T>(this Switch<T> s, Action<T> a)
        {

            if (s != null)
            {

                a(s.Object);

            }

        }

        public static void Default(this Switch s, Action<object> a)
        {

            if (s != null)
            {

                a(s.Object);

            }

        }

    }


}