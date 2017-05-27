using BSP.Model;
using System.Collections.Generic;
using BSP.Caching;

namespace BSP.Biz.Adapters
{
    /// <summary>
    /// 图书分类数据适配器
    /// </summary>
    public class CategoryAdapter : _BaseAdapter
    {
        /// <summary>
        /// 图书分类缓存键
        /// </summary>
        private const string CATEGORIESLISTCACHEKEY = "BSP.Categories";

        /// <summary>
        /// 获取全部图书分类
        /// </summary>
        /// <returns></returns>
        public IList<Category> GetAllCategories()
        {
            //追加缓存处理，提升页面响应速度
            return base.CacheManager.Memory.Get<IList<Category>>(CATEGORIESLISTCACHEKEY, () =>
                base.CategoryRepository.GetAllCategories()
            );
        }
    }
}
