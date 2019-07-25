using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdGenerator
{
    public class GuidGenerator : IGenerator
    {
        /// <summary>
        /// 生成无符号GUID字符串 D 有符号 N 无符号
        /// </summary>
        /// <returns></returns>
        public string Generate(DbType dbType)
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
