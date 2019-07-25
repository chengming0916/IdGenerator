using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdGenerator
{
    public class TimestampGenerator : IGenerator
    {
        public string Generate(DbType dbType)
        {
            long timestamp = DateTime.UtcNow.Ticks / 10000L;
            return timestamp.ToString();
        }
    }
}
