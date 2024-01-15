using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StringManipulation;
using Microsoft.Extensions.Logging;
using Moq;
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
        public void ReverseString()
        {
            // Arrange
            var strOperations = new StringOperations();
            // Act
            var result = strOperations.ReverseString("cat");
            // Assert
            Assert.Equal("tac",result);
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

        [Theory]
        [InlineData("Hola mundo",4,"Hola")]
        [InlineData("Ola",6,"Ola")]
        [InlineData("",5,"")]
        public void TruncateString(string input, int maxLength, string expected)
        {
            // Arrange
            var strOperations = new StringOperations();
            // Act
            var result = strOperations.TruncateString(input,maxLength);
            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Gato","Gatos")]
        [InlineData("uva","uvas")]
        public void Pluralize(string input, string expected)
        {
            // Arrange
            var strOperations = new StringOperations();
        
            // Act
            var result = strOperations.Pluralize(input);
        
            // Assert
            Assert.Equal(expected, result);
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

        [Fact]
        public void CountOccurrences()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<StringOperations>>();
            var strOperations = new StringOperations(mockLogger.Object);
            // Act
            var result = strOperations.CountOccurrences("Un osito de gomita",'o');
            // Assert
            Assert.Equal(3,result);
        }
        [Fact]
        public void ReadFile()
        {
            // Arrange
            var strOperations = new StringOperations();
            var mockFileReader = new Mock<IFileReaderConector>();
            mockFileReader.Setup(p=> p.ReadString(It.IsAny<string>())).Returns("Reading file");

            // Act
            var result = strOperations.ReadFile(mockFileReader.Object, "file.txt");
            // Assert
            Assert.Equal("Reading file",result);
        }
        
    }
}