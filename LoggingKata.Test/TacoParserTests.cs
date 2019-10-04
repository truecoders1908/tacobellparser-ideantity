using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Theory]
        [InlineData("Example")]
        [InlineData("0, 0, Taco Bell Warrior", 0, 0, "Taco Bell Warrior")]
        [InlineData("32, -85, Taco Bell Auburn", 32, -85, "Taco Bell Auburn")]
        [InlineData("33,-86.,Taco Bell Birmingham", 33, -86, "Taco Bell Birmingham")]
        [InlineData("32,-85,Taco Bell Alexander City", 32, -85, "Taco Bell Alexander City")]
        public void ShouldParse(string str, double expectedLat, double expectedLon,  string expectName)
        {
            //Arrange
            TacoParser tacoparser = new TacoParser();

            //Act
            ITrackable actual = tacoparser.Parse(str);

            //Assert
            Assert.Equal(expectedLat, actual.Location.Latitude);
            Assert.Equal(expectedLon, actual.Location.Longitude);
            Assert.Equal(expectName, actual.Name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("Me")]
        [InlineData("Taco, Bell")]
        [InlineData("33, -85, Taco Rita Auburn")]
        [InlineData("-32, 85, Taco Mama Auburn")]
        [InlineData("Nope no nota NOPE TACO BELL")]

        public void ShouldFailParse(string str)
        { 
            //Arrange
            TacoParser tacoParser = new TacoParser();

            //Act
            ITrackable actual = tacoParser.Parse(str);

            //Assert
            Assert.Equal(actual, expected);
        }
    }
}
