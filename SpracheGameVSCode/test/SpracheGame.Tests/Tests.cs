using System;
using Xunit;
using Sprache;
using SpracheGame;

namespace Tests
{
    public class GameParserTests
    {
        [Theory]
        [InlineData("1")]
        [InlineData("10")]
        [InlineData("100")]
        public void CanParseNumbers(string value)
        {
            var number = GameParser.Number.Parse(value);

            Assert.Equal(number, value);
        }

        [Fact]
        public void CanParseGreaterCommand()
        {
            Command command = GameParser.Command.Parse(">");

            Assert.Equal(command, Command.Greater);
        }

        [Fact]
        public void CanParseLessCommand()
        {
            Command command = GameParser.Command.Parse("<");

            Assert.Equal(command, Command.Less);
        }

        [Fact]
        public void CanParseBetweenCommand()
        {
            Command command = GameParser.Command.Parse("<>");

            Assert.Equal(command, Command.Between);
        }

        [Fact]
        public void CanParseEqualCommand()
        {
            Command command = GameParser.Command.Parse("=");

            Assert.Equal(command, Command.Equal);
        }

        [Fact]
        public void CanParseCorrectPlay()
        {
            Play play = GameParser.Play.Parse("> 5");

            Assert.Equal(play.Command, Command.Greater);
            Assert.Equal(play.FirstNumber, 5);
        }

        [Fact]
        public void CanParseCorrectBetweenPlay()
        {
            Play play = GameParser.Play.Parse("1 <> 5");

            Assert.Equal(play.Command, Command.Between);
            Assert.Equal(play.FirstNumber, 1);
            Assert.Equal(play.SecondNumber, 5);
        }

        [Fact]
        public void FailParseWrongPlay()
        {            
            Assert.Throws<ParseException>(() => GameParser.Play.Parse("> Number"));
        }
    }
}
