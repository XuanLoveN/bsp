using BSP.IRepository;
using BSP.Model;
using BSP.SqlUtility;
using System.Collections.Generic;

namespace BSP.SqlRepository
{
    public class CategoryRepository : _BaseRespotiroy, ICategoryRepository
    {
        public IList<Category> GetAllCategories()
        {
            return base.Database.GetSimpleList<Category>();
        }
        public bool CreateNewCategory(Category category)
        {
            return base.Database.Create(category, Category._Id, Category._PId, Category._SortNum);
        }


        public void DeleteAll(string ids)
        {
            string sql = string.Format("DELETE FROM {0} WHERE ID IN ({1})", Category.Tablename, ids);
            base.Database.ExecuteNonQuery(System.Data.CommandType.Text, sql);
        }
    }
}
