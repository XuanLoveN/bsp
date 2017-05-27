namespace BSP.Caching.Provider
{
    using Ninject;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Web;

    /// <summary>
    /// 会话缓存提供程序
    /// </summary>
    public class SessionCacheProvider : ICache
    {
        [Inject]
        private HttpContextBase Context { get; set; }

        public T Get<T>(string key)
        {
            if (Context.Session[key] == null)
            {
                return default(T);
            }

            return (T)Context.Session[key];
        }

        public void Set(string key, object value, int expriseTime = 0)
        {
            Context.Session[key] = value;
        }

        public bool Contains(string key)
        {
            return Context.Session != null && Context.Session[key] != null;
        }

        public void Remove(string key)
        {
            Context.Session.Remove(key);
        }

        public void RemoveByPartten(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = new List<String>();

            foreach (var keyObj in Context.Session.Keys)
            {
                string key = keyObj.ToString();

                if (regex.Match(key).Success)
                {
                    keysToRemove.Add(key);
                }
            }

            foreach (var key in keysToRemove)
            {
                Remove(key);
            }
        }

        public void Clear()
        {
            Context.Session.Clear();
        }
    }
}
