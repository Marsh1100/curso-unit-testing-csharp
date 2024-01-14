using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StringManipulation;


namespace StringManipulationTest
{
    public class StringOperationTest
    {
        [Fact]
        public void ConcatenateStrings()
        {
            var strOperations = new StringOperations();
            var result = strOperations.ConcatenateStrings("holi","amorcito");
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("holi amorcito", result);
        }
        [Fact]
        public void IsPalindrome_True()
        {
            // Arrange
            var strOperations = new StringOperations();
            // Act
            var result = strOperations.IsPalindrome("ana");
            // Assert
            Assert.True(result);
        }

        public void IsPalindrome_False()
        {
            // Arrange
            var strOperations = new StringOperations();
            // Act
            var result = strOperations.IsPalindrome("cat");
            // Assert
            Assert.False(result);
        }
    }
}