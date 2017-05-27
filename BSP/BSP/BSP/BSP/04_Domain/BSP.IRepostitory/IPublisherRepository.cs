using BSP.Model;
using System.Collections.Generic;

namespace BSP.IRepository
{
    /// <summary>
    /// 出版社数据仓库接口
    /// </summary>
    public interface IPublisherRepository
    {
        /// <summary>
        /// 获取全部出版社
        /// </summary>
        /// <returns></returns>
        IList<Publisher> GetAllPublishers();
    }
}
