namespace MakeItSimple.QualityCheck
{
    public class FormatFileNameQualityCheck
    {

        [Fact]
        public void WithoutExtentionInputCheck()
        {
            (bool status, string message) = SimpleUtils.FormatFileName("Input File Name of Sampling");
            Assert.True(status);
            Assert.Equal("input_file_name_of_sampling", message);
        }

        [Fact]
        public void FormatFileName_NullFileName_ReturnsFalseAndInvalidFileNameMessage()
        {
            // Arrange
            string fileName = null;

            // Act
            var result = SimpleUtils.FormatFileName(fileName);

            // Assert
            Assert.False(result.status);
            Assert.Equal("Invalid file name", result.result);
        }

        [Fact]
        public void FormatFileName_EmptyFileName_ReturnsFalseAndInvalidFileNameMessage()
        {
            // Arrange
            string fileName = "";

            // Act
            var result = SimpleUtils.FormatFileName(fileName);

            // Assert
            Assert.False(result.status);
            Assert.Equal("Invalid file name", result.result);
        }

        [Fact]
        public void FormatFileName_WhiteSpaceFileName_ReturnsFalseAndInvalidFileNameMessage()
        {
            // Arrange
            string fileName = "   ";

            // Act
            var result = SimpleUtils.FormatFileName(fileName);

            // Assert
            Assert.False(result.status);
            Assert.Equal("Invalid file name", result.result);
        }

        [Fact]
        public void FormatFileName_ValidFileName_ReturnsTrueAndFormattedFileName()
        {
            // Arrange
            string fileName = "Test File Name";
            string expectedFormattedFileName = "test_file_name";

            // Act
            var result = SimpleUtils.FormatFileName(fileName);

            // Assert
            Assert.True(result.status);
            Assert.Equal(expectedFormattedFileName, result.result);
        }
    }
}
