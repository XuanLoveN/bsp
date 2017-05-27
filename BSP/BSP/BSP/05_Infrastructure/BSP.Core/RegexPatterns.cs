using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BSP.Core;
using System.Xml.Serialization;
using BSP.Exceptions;

namespace BSP
{
    public class RegexPatterns
    {
        private Dictionary<string, string> _patterns = new Dictionary<string, string>();
        public RegexPatterns()
        {
            this._patterns.Add(AppKeys.RegexPatternKeys.IPV4AddressPartten, @"^\d{1,3}[\.]\d{1,3}[\.]\d{1,3}[\.]\d{1,3}$");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patternFilePaths"></param>
        /// params 定义参数数组 主要用于在对数组长度未知（可变）的情况下
        /// 进行函数声明 调用时可以传入个数不同的实参 具备很好的灵活性
        public RegexPatterns(params string[] patternFilePaths)
            : this()
        {
            try
            {
                foreach (var patternFile in patternFilePaths)
                {
                    if (string.IsNullOrEmpty(patternFile))
                    {
                        continue;
                    }
                    LoadExtendsPattern(patternFile);
                }
            }
            catch 
            {
                
                throw;
            }
            SavePatternsToMemory();
        }
        /// <summary>
        /// 将正则表达式内容存储到缓存空间上
        /// </summary>
        private void SavePatternsToMemory()
        {

        }
        private void LoadExtendsPattern(string patternFilePath) 
        {
            if (!File.Exists(patternFilePath))
            {
                return;
            }
            using (FileStream stream = new FileStream(patternFilePath,FileMode.Open))
            {
                try
                {
                    if (stream.Length == 0)
                    {
                        stream.Close();
                        return;
                    }

                    XmlSerializer serializer = new XmlSerializer(typeof(List<KeyValuePair<string, string>>));
                    List<KeyValuePair<string, string>> loadedPatterns = (List<KeyValuePair<string, string>>)serializer.Deserialize(stream);
                    foreach (var pattern in loadedPatterns)
                    {
                        if (this._patterns.ContainsKey(pattern.Key))
                        {
                            this._patterns.Remove(pattern.Key);
                        }
                        this._patterns.Add(pattern.Key, pattern.Value);
                    }
                }
                catch (System.Exception ex)
                {
                    throw new LoadExtendsPatternException("加载外部正则表达式文件时异常", ex, patternFilePath);
                }
                finally { stream.Close(); }
            }
        }
        /// <summary>
        /// 获取正则表达式规则
        /// </summary>
        /// <param name="key">正则表达式键</param>
        /// <returns></returns>
        public string this[string key]
        {
            get { return this._patterns[key]; }
        }
    }
}
