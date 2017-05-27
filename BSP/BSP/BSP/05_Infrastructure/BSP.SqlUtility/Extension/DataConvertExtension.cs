namespace BSP.SqlUtility
{
    using BSP.SqlUtility.Helper;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// 数据转换器扩展类型
    /// </summary>
    public static class DataConvertExtension
    {
        /// <summary>
        /// 将数据表转换为指定类型的对象集合
        /// </summary>
        /// <typeparam name="T">指定类型</typeparam>
        /// <param name="table">数据表</param>
        /// <param name="excludeProperties">需要排除的属性名称列表</param>
        /// <returns></returns>
        public static IList<T> ParseToList<T>(this DataTable table, params string[] excludeProperties)
        {
            return DataConvertHelper.ToList<T>(table, excludeProperties);
        }

        /// <summary>
        /// 将数据行转换为指定类型的对象
        /// </summary>
        /// <typeparam name="T">指定类型</typeparam>
        /// <param name="row">数据行</param>
        /// <param name="excludeProperties">需要排除的属性名称列表</param>
        /// <returns></returns>
        public static T ParseToObject<T>(this DataRow row, params string[] excludeProperties)
        {
            return DataConvertHelper.ToObject<T>(row, excludeProperties);
        }
    }
}
