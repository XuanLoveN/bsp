using System;
using System.Linq;
using System.Web;

namespace BSP.Core
{
    /// <summary>
    /// 客户端信息
    /// </summary>
    public sealed class ClientInformation
    {
        private readonly HttpContext _httpContext = null;

        public ClientInformation(HttpContext httpContext)
        {
            this._httpContext = httpContext;
        }

        /// <summary>
        /// 验证请求对象
        /// </summary>
        public Boolean IsRequestAvailable
        {
            get
            {
                if (_httpContext == null)
                    return false;

                try
                {
                    if (_httpContext.Request == null)
                        return false;
                }
                catch (HttpException)
                {
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// 获取客户端IP地址
        /// </summary>
        public string ClientIPAddress
        {
            get
            {
                if (!IsRequestAvailable)
                    return string.Empty;

                var result = "";
                if (_httpContext.Request.Headers != null)
                {
                    var forwardedHttpHeader = "X-FORWARDED-FOR";

                    //此处可自定义转发标头
                    //if (!String.IsNullOrEmpty(AppSettings.Get(SettingsKeys.Web_ForwardedHTTPheader)))
                    //{
                    //    forwardedHttpHeader = AppSettings.Get(SettingsKeys.Web_ForwardedHTTPheader);
                    //}

                    string xff = _httpContext.Request.Headers.AllKeys
                        .Where(x => forwardedHttpHeader.Equals(x, StringComparison.InvariantCultureIgnoreCase))
                        .Select(k => _httpContext.Request.Headers[k])
                        .FirstOrDefault();

                    if (!String.IsNullOrEmpty(xff))
                    {
                        string lastIp = xff.Split(new[] { ',' }).FirstOrDefault();
                        result = lastIp;
                    }
                }

                if (String.IsNullOrEmpty(result) && _httpContext.Request.UserHostAddress != null)
                {
                    result = _httpContext.Request.UserHostAddress;
                }

                //some validation
                if (result == "::1")
                    result = "127.0.0.1";
                //remove port
                if (!String.IsNullOrEmpty(result))
                {
                    int index = result.IndexOf(":", StringComparison.InvariantCultureIgnoreCase);
                    if (index > 0)
                        result = result.Substring(0, index);
                }
                return result;
            }
        }
    }
}
