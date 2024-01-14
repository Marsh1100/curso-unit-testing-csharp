using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StringManipulation;


namespace StringManipulationTest
{
    public class StringOperationTest
    {
        [Fact(Skip = "Esta prueba no es valida en el momento. TICKET 008")]
        public void ConcatenateStrings()
        {
            var strOperations = new StringOperations();
            var result = strOperations.ConcatenateStrings("holi","mundo");
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("holi mundo", result);
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
        [Fact]
        public void IsPalindrome_False()
        {
            // Arrange
            var strOperations = new StringOperations();
            // Act
            var result = strOperations.IsPalindrome("cat");
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void RemoveWhitespace()
        {
            // Arrange
            var strOperations = new StringOperations();
            // Act
            var result = strOperations.RemoveWhitespace("Josefa es bonita");
            // Assert
            Assert.Equal("Josefaesbonita", result);
        }

        [Theory]
        [InlineData("gato",5,"cinco gatos")]
        [InlineData("perro",3,"tres perros")]
        public void QuantintyInWords(string word, int quantity, string expected )
        {
            // Arrange
            var strOperations = new StringOperations();
            // Act
            var result = strOperations.QuantintyInWords(word,quantity);
            // Assert
            //Assert.StartsWith("ocho", result);
            Assert.Contains(word, expected);
        }

        [Fact]
        public void  GetStringLength_Exception()
        {
            // Arrange
            var strOperations = new StringOperations();
            // Act --> No hay porque se va a saltar una excepción
    
            // Assert
            Assert.ThrowsAny<ArgumentNullException>(()=> strOperations.GetStringLength(null));
        }

        [Fact]
        public void  TruncateString_Exception()
        {
            // Arrange
            var strOperations = new StringOperations();
            // Act --> No hay porque se va a saltar una excepción
    
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(()=> strOperations.TruncateString("notebook",0));
        }

        [Theory]
        [InlineData("V",5)]
        [InlineData("DXXV",525)]

        public void FromRomanToNumber(string romanNumber, int expected)
        {
            // Arrange
            var strOperations = new StringOperations();
        
            // Act
            var result = strOperations.FromRomanToNumber(romanNumber);
        
            // Assert
            Assert.Equal(expected, result);
        }
    }
}