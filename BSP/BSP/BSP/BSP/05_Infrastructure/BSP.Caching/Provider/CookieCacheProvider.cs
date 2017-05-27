namespace BSP.Caching.Provider
{
    using BSP.Core;
    using BSP.Helper;
    using Ninject;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Web;

    /// <summary>
    /// Cookie缓存提供程序
    /// </summary>
    public class CookieCacheProvider : ICache
    {
        [Inject]
        private HttpContextBase Context { get; set; }

        public T Get<T>(string key)
        {
            if (typeof(T) == typeof(string))
            {
                HttpCookie cookie = Context.Request.Cookies[key];
                if (cookie != null)
                {
                    return (T)DataTypeHelper.ChangeType(typeof(T), cookie.Value);
                }
            }

            return default(T);
        }

        public void Set(string key, object value, int expriseTime = 0)
        {
            if (expriseTime == 0)
            {
                expriseTime = AppSettings.Get<int>(AppKeys.SettingKeys.Cache_CookieCacheExprise);
            }

            HttpCookie cookie = new HttpCookie(key, value.ToString());
            cookie.Expires = DateTime.Now + TimeSpan.FromMinutes(expriseTime);

            Context.Response.Cookies.Add(cookie);
        }

        public bool Contains(string key)
        {
            HttpCookie cookie = Context.Request.Cookies[key];
            return (cookie != null && !string.IsNullOrEmpty(cookie.Value));
        }

        public void Remove(string key)
        {
            HttpCookie cookie = Context.Request.Cookies[key];
            if (cookie != null)
            {
                cookie.Value = string.Empty;
                cookie.Expires = DateTime.Now.AddDays(-1);
                Context.Response.Cookies.Add(cookie);
            }
        }

        public void RemoveByPartten(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            HttpCookieCollection cookies = Context.Request.Cookies;
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
            HttpCookieCollection cookies = Context.Request.Cookies;
            IEnumerator enumerator = cookies.Keys.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Remove((string)enumerator.Current);
            }
        }
    }
}
