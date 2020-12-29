using Xunit;

namespace RestApiCleanArch.Infraestructure.UnitTests
{
    public class RandomGeneratorTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(10)]
        [InlineData(15)]
        [InlineData(20)]
        [InlineData(30)]
        [InlineData(100)]
        [InlineData(128)]
        public void SecureRandomString_RetornaCantidadCorrectaCaracteres(int len)
        {
            RandomGenerator randomGen = new RandomGenerator();
            string val = randomGen.SecureRandomString(len);
            Assert.Equal(len, val.Length);
        }
    }
}
