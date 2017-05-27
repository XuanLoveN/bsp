using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSP.Model.PagedModel
{
    /// <summary>
    /// 分页集合接口类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPagedList<T> : IPagedBase<T> { }
}
