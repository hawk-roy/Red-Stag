using System;

namespace SouthGate
{
    internal static class FactoryProvider
    {
        public static IFactory Create(string sysInfo)
        {
            if (string.Equals(sysInfo, "Wins", StringComparison.OrdinalIgnoreCase))
            {
                return new WindowsFactory();
            }

            if (string.Equals(sysInfo, "Ios", StringComparison.OrdinalIgnoreCase))
            {
                return new IosFactory();
            }

            throw new NotSupportedException($"Unsupported system: {sysInfo}");
        }
    }
}
