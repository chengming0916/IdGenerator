using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdGenerator
{
    public static class IdGeneratorFactory
    {
        private static readonly Dictionary<GeneratorType, IGenerator> generators = new Dictionary<GeneratorType, IGenerator>();

        private static IGenerator generator;

        public static IGenerator CreateGenerator(GeneratorType generatorType)
        {
            if (generators.Keys.Contains(generatorType))
            {
                return generators[generatorType];
            }

            switch (generatorType)
            {
                case GeneratorType.GUID:
                    generator = new GuidGenerator();
                    break;

                case GeneratorType.CombGUID:
                    generator = new CombGuidGenerator();
                    break;

                case GeneratorType.Int64GUID:
                    generator = new Int64GuidGenerator();
                    break;

                case GeneratorType.Timestamp:
                    generator = new TimestampGenerator();
                    break;

                case GeneratorType.Snowflake:
                    generator = new SnowflakeGenerator();
                    break;
            }

            generators.Add(generatorType, generator);
            return generator;
        }
    }
}
