using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdGenerator
{
    /// <summary>
    /// 生成器类型
    /// </summary>
    public enum GeneratorType
    {
        GUID, //GUID
        CombGUID, //为了解决UUID无序的问题，NHibernate在其主键生成方式中提供了Comb算法（combined guid/timestamp）。保留GUID的10个字节，用另6个字节表示GUID生成的时间（DateTime）。
        Int64GUID,//Int64 GUID 解决GUID不可读问题
        Timestamp,
        Snowflake //
    }
}
