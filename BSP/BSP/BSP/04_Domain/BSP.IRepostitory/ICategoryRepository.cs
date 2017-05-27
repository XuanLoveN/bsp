using BSP.Model;
using System.Collections.Generic;

namespace BSP.IRepository
{
    /// <summary>
    /// 图书分类数据仓库接口
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// 获取全部图书分类
        /// </summary>
        /// <returns></returns>
        IList<Category> GetAllCategories();
        /// <summary>
        /// 添加图书分类
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        bool CreateNewCategory(Category category);

        /// <summary>
        /// 根据标号删除多个图书分类
        /// </summary>
        /// <param name="ids"></param>
        void DeleteAll(string ids);
    }
}
