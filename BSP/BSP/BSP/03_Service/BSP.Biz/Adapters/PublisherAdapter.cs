using BSP.Model;
using System.Collections.Generic;
using BSP.Caching;

namespace BSP.Biz.Adapters
{
    public class PublisherAdapter:_BaseAdapter
    {
        private const string PUBLISHERCACHEKEY = "BSP.Publishers";

        /// <summary>
        /// 获取全部出版社
        /// </summary>
        /// <returns></returns>
        public IList<Publisher> GetAllPublishers()
        {
            return base.CacheManager.Memory.Get<IList<Publisher>>(PUBLISHERCACHEKEY, () =>
                base.PublisherRepository.GetAllPublishers()
            );
        }
    }
}
