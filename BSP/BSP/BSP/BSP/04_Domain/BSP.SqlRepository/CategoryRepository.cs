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
    }
}
