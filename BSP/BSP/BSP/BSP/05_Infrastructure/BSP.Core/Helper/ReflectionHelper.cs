using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BSP.Helper
{
    public sealed class ReflectionHelper
    {
        #region 根据指定参数获取类类型
        /// <summary>
        /// 获取类类型
        /// </summary>
        /// <param name="obj">任意对象</param>
        /// <returns>类型完整名称所指向的类型对象</returns>
        public static Type GetType(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            return GetType(obj.ToString());
        }
        /// <summary>
        /// 获取类类型
        /// </summary>
        /// <param name="typeNameAndAssemblyName">类型名称，程序集名称</param>
        /// <returns>类型完整名称所指向的类型对象</returns>
        public static Type GetType(string typeNameAndAssemblyName)
        {
            if (string.IsNullOrEmpty(typeNameAndAssemblyName))
            {
                return null;
            }
            string[] nameArr = typeNameAndAssemblyName.Split(',');
            if (nameArr.Length < 2)
            {
                return GetType(nameArr[0], null);
            }
            return GetType(nameArr[0], nameArr[1]);
        }
        /// <summary>
        /// 获取类类型
        /// </summary>
        /// <param name="typeFullName">类型完整名称</param>
        /// <param name="assemblyName">程序集名称</param>
        /// <returns>类型完整名称所指向的类型对象</returns>
        public static Type GetType(string typeFullName, string assemblyName)
        {
            //如果程序集名称为空，则返回类型完整名称所指向的类型对象
            if (string.IsNullOrEmpty(assemblyName)) return Type.GetType(typeFullName);

            //获取当前应用程序域所加载的程序集对象
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly assembly in assemblies)
            {
                //如果当前应用程序域中包含指定程序集名称
                //则加载当前程序集中指定完整类型名称的类型对象
                if (assembly.FullName.Split(',')[0].Trim() == assemblyName.Trim())
                {
                    return assembly.GetType(typeFullName);
                }
            }

            //加载外部程序集对象
            Assembly extAssembly = Assembly.Load(assemblyName);
            //如果程序集对象不为空，则根据加载到的程序集对象获取指定类型完整名的类型对象
            if (extAssembly != null) return extAssembly.GetType(typeFullName);

            return null;
        } 
        #endregion
        /// <summary>
        /// 根据成员对象获取成员名称字符串表达方式
        /// </summary>
        /// <param name="exp">表达式树，例：GetVerName(()=>obj.Str1)，返回："Str1"</param>
        /// <returns>成员名称字符串</returns>
        public static string GetVerName(Expression<Func<string>> exp)
        {
            return ((MemberExpression)exp.Body).Member.Name;
        }
    }
}
