using IdGenerator.Common;
using System;
using System.Security.Cryptography;

namespace IdGenerator
{
    /// <summary>
    /// SQLServer   uniqueidentifier     SequentialAtEnd
    /// MySQL       char(36)             SequentialAsString
    /// Oracle      raw(16)              SequentialAsBinary
    /// PostgreSQL  uuid                 SequentialAsString
    /// SQLite      varies               varies
    /// </summary>
    public class CombGuidGenerator : IGenerator
    {
        public string Generate(DbType dbType)
        {
            Guid guid;
            switch (dbType)
            {
                case DbType.SQLServer:
                    guid = SequentialGuidGenerator.NewSequentialGuid(SequentialGuidType.SequentialAtEnd);
                    break;
                default:
                case DbType.SQLite:
                case DbType.MySQL:
                case DbType.PostgreSQL:
                    guid = SequentialGuidGenerator.NewSequentialGuid(SequentialGuidType.SequentialAsString);
                    break;
                case DbType.Oracle:
                    guid = SequentialGuidGenerator.NewSequentialGuid(SequentialGuidType.SequentialAsBinary);
                    break;
            }

            return guid.ToString("N");
        }
    }


}