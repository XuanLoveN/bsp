using BSP.Core.Extension;
using Newtonsoft.Json;
using System;

namespace BSP.Model
{
    /// <summary>
    /// 用户票证
    /// </summary>
    [Serializable]
    public class UserTicket
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }

        /// <summary>
        /// 将当前用户票证转义为字符串并加密
        /// </summary>
        /// <returns></returns>
        public string ParseToString()
        {
            string json = JsonConvert.SerializeObject(this);
            return json.EncryptToAES();
        }

        /// <summary>
        /// 将字符串转义为用户票证对象
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static UserTicket ParseFromString(string json)
        {
            return JsonConvert.DeserializeObject<UserTicket>(json.DecryptToAES());
        }
    }
}
