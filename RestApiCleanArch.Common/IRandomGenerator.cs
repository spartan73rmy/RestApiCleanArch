namespace RestApiCleanArch.Common
{
    public interface IRandomGenerator
    {
        int Next();
        int Next(int maxValue);
        int Next(int minValue, int maxValue);
        /// <summary>
        /// Retorna un doble entre 0 y 1.0
        /// </summary>
        /// <returns></returns>
        double NextDouble();

        string Guid();
        string SecureRandomString(int len);
    }
}
