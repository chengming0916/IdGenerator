using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdGenerator
{
    public class Int64GuidGenerator : IGenerator
    {
        /// <summary>
        /// 根据GUID获取唯一数字序列
        /// </summary>
        /// <returns></returns>
        public string Generate(DbType dbType)
        {
            byte[] bytes = Guid.NewGuid().ToByteArray();
            long id = BitConverter.ToInt64(bytes, 0);
            return id.ToString();
        }
    }
}
