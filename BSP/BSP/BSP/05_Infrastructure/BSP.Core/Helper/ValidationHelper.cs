using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;

namespace BSP.Core.Helper
{
    public sealed class ValidationHelper
    {
        /// <summary>
        /// 验证数据集是否包含数据
        /// </summary>
        /// <param name="dataSet">数据集</param>
        /// <returns></returns>
        public static bool IsNotEmptyDataSet(DataSet dataSet)
        {
            return (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count != 0 && dataSet.Tables[0] != null && dataSet.Tables[0].Rows.Count != 0);
        }

        /// <summary>
        /// 验证集合是否包含数据
        /// </summary>
        /// <param name="list">集合对象</param>
        /// <returns></returns>
        public static bool IsNotEmptyList(IList list)
        {
            return list != null && list.Count > 0;
        }

        /// <summary>
        /// 验证集合是否包含数据
        /// </summary>
        /// <param name="list">集合对象</param>
        /// <returns></returns>
        public static bool IsNotEmptyList<T>(IList<T> list)
        {
            return list != null && list.Count > 0;
        }

        /// <summary>
        /// 判断是否是IP地址格式 0.0.0.0
        /// </summary>
        /// <param name="str">待判断的IP地址</param>
        /// <returns>true or false</returns>
        public static bool IsIPV4Address(string str)
        {
            if (string.IsNullOrEmpty(str) || str.Length < 7 || str.Length > 15) return false;

            RegexPatterns patterns = new RegexPatterns();
            string regformat = patterns[AppKeys.RegexPatternKeys.IPV4AddressPartten];

            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);
            return regex.IsMatch(str);
        }
    }
}
