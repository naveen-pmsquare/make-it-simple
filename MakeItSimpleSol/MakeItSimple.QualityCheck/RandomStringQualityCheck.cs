namespace MakeItSimple.QualityCheck
{
    public class RandomStringQualityCheck
    {
        [Fact]
        public void GenerateRandomString_DefaultLength_ReturnsRandomString()
        {
            // Arrange
            int defaultLength = 8;

            // Act
            string result = SimpleUtils.GenerateRandomString(defaultLength);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(defaultLength, result.Length);
        }

        [Fact]
        public void GenerateRandomString_SpecificLength_ReturnsRandomString()
        {
            // Arrange
            int specificLength = 16;

            // Act
            string result = SimpleUtils.GenerateRandomString(specificLength);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(specificLength, result.Length);
        }

        [Fact]
        public void GenerateRandomString_ZeroLength_ReturnsRandomStringWithDefaultLength()
        {
            // Arrange
            int zeroLength = 0;

            // Act
            string result = SimpleUtils.GenerateRandomString(zeroLength);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(8, result.Length);
        }

        [Fact]
        public void GenerateRandomString_NegativeLength_ReturnsRandomStringWithDefaultLength()
        {
            // Arrange
            int negativeLength = -5;

            // Act
            string result = SimpleUtils.GenerateRandomString(negativeLength);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(8, result.Length);
        }

        [Fact]
        public void GenerateRandomString_LargeLength_ReturnsRandomString()
        {
            // Arrange
            int largeLength = 100;

            // Act
            string result = SimpleUtils.GenerateRandomString(largeLength);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(largeLength, result.Length);
        }
    }
}
