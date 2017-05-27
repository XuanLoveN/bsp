using BSP.Model;
using System.Collections.Generic;
using BSP.SqlUtility;
using BSP.IRepository;

namespace BSP.SqlRepository
{
    public class PublisherRepository : _BaseRespotiroy, IPublisherRepository
    {
        public IList<Publisher> GetAllPublishers()
        {
            return base.Database.GetSimpleList<Publisher>();
        }
    }
}
