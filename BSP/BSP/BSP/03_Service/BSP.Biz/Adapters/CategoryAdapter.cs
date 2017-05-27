using BSP.Model;
using System.Collections.Generic;
using BSP.Caching;
using System.Linq;

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
        /// <summary>
        /// 根据编号获取图书分类对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Category GetCategoryById(int id)
        {
            var categories = GetAllCategories();
            return categories.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// 创建新的图书分类
        /// </summary>
        /// <param name="categoryName">分类名称</param>
        /// <returns></returns>
        public bool CreateNewCategory(string categoryName)
        {
            bool flag = base.CategoryRepository.CreateNewCategory(new Category { Name = categoryName });

            if (flag)
            {
                base.CacheManager.Memory.Remove(CATEGORIESLISTCACHEKEY);
            }

            return flag;
        }

        /// <summary>
        /// 根据编号删除一组图书分类
        /// </summary>
        /// <param name="ids"></param>
        public void DeleteAll(string ids)
        {
            base.CacheManager.Memory.Remove(CATEGORIESLISTCACHEKEY);
            base.CategoryRepository.DeleteAll(ids);
        }
    }
}
