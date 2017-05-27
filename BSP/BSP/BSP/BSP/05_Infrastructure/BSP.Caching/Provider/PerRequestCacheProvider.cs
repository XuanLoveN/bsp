namespace BSP.Caching.Provider
{
    using Ninject;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Web;

    /// <summary>
    /// Web请求缓存提供程序
    /// </summary>
    public class PerRequestCacheProvider : ICache
    {
        [Inject]
        private HttpContextBase Context { get; set; }

        protected virtual IDictionary Items
        {
            get
            {
                if (Context != null)
                    return Context.Items;

                return null;
            }
        }

        public T Get<T>(string key)
        {
            if (this.Items != null)
            {
                return (T)Items[key];
            }

            return default(T);
        }

        public void Set(string key, object value, int expriseTime = 0)
        {
            if (Items == null)
                return;

            if (value != null)
            {
                if (Items.Contains(key))
                    Items[key] = value;
                else
                    Items.Add(key, value);
            }
        }

        public bool Contains(string key)
        {
            if (Items == null)
            {
                return false;
            }

            return Items[key] != null;
        }

        public void Remove(string key)
        {
            if (Items != null)
            {
                Items.Remove(key);
            }
        }

        public void RemoveByPartten(string pattern)
        {
            if (Items == null) return;

            var enumerator = Items.GetEnumerator();
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = new List<String>();
            while (enumerator.MoveNext())
            {
                if (regex.IsMatch(enumerator.Key.ToString()))
                {
                    keysToRemove.Add(enumerator.Key.ToString());
                }
            }

            foreach (string key in keysToRemove)
            {
                Items.Remove(key);
            }
        }

        public void Clear()
        {
            if (Items == null)
                return;

            var enumerator = Items.GetEnumerator();
            var keysToRemove = new List<String>();
            while (enumerator.MoveNext())
            {
                keysToRemove.Add(enumerator.Key.ToString());
            }

            foreach (string key in keysToRemove)
            {
                Items.Remove(key);
            }
        }
    }
}
