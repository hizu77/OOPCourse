using System.Security.Cryptography;

namespace Itmo.ObjectOrientedProgramming.Lab2.Generator;

public class GeneratorId
{
    public static long Generate()
    {
        int firstValue = RandomNumberGenerator.GetInt32(0, int.MaxValue);
        int secondValue = RandomNumberGenerator.GetInt32(0, int.MaxValue);

        long result = firstValue * secondValue;

        return result;
    }
}