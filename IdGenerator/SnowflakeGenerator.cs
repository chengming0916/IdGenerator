using IdGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdGenerator
{
    public class SnowflakeGenerator : IGenerator
    {
        private static Snowflake snowflake = Snowflake.Instance();

        public string Generate(DbType dbType)
        {
            return snowflake.GetId().ToString();
        }
    }
}
