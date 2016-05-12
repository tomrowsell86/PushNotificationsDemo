using System.Collections.Generic;
using NUnit.Framework;
using PushNotificationsHandler.Models;

namespace PushNotificationsHandler.UnitTests.Models.ColourFormatParserTests
{
    [TestFixture]
    public class ColourFormatParserSingleFormattedBlockMessageTests
    {
        private IList<ColourFormattedPart> _result;

        [OneTimeSetUp]
        public void GivenAMessageWithOneColourFormattingBlockForEntireMessage_WhenParsed()
        {

            var colourFormatParser = new PushNotificationsHandler.Models.Services.ColourFormatParser();
            string messageText = "{colour:#FF0000}Hello World{colour}";

            _result = colourFormatParser.GetFormattedParts(messageText);
        }

        [Test]
        public void ThenOneMessagePartReturned()
        {
            Assert.That(_result.Count, Is.EqualTo(1));
        }

        [Test]
        public void ThenExpectedRgbColourValueSetInMessagePart()
        {
            var colourFormattedPart = _result[0];
            Assert.That(colourFormattedPart.ColourRgb, Is.EqualTo("#FF0000"));
        }

        [Test]
        public void ThenExpectedPartContentValueSetInMessagePart()
        {
            var colourFormattedPart = _result[0];
            Assert.That(colourFormattedPart.PartContent, Is.EqualTo("Hello World"));
        }

    }

    [TestFixture]
    public class ColourFormatParserSingleFormattedBlockWordInterpolatedWithPlainMessageTextTests
    {
        private IList<ColourFormattedPart> _result;

        [SetUp]
        public void GivenAMessageWithFormattedBlockWordInterpolatedWithPlainText_WhenParsed()
        {
            var colourFormatParser = new PushNotificationsHandler.Models.Services.ColourFormatParser();
            string messageText = "Hello {colour:#FF0000}World{colour}";

            _result = colourFormatParser.GetFormattedParts(messageText);
        }

        [Test]
        public void ThenOneMessagePartReturned()
        {
            Assert.That(_result.Count, Is.EqualTo(1));
        }

        [Test]
        public void ThenExpectedRgbColourValueSetInMessagePart()
        {
            var colourFormattedPart = _result[0];
            Assert.That(colourFormattedPart.ColourRgb, Is.EqualTo("#FF0000"));
        }

        [Test]
        public void ThenExpectedPartContentValueSetInMessagePart()
        {
            var colourFormattedPart = _result[0];
            Assert.That(colourFormattedPart.PartContent, Is.EqualTo("World"));
        }
    }

    [TestFixture]
    public class ColourFormatParserSingleFormattedBlockLetterInterpolatedWithPlainMessageTextTests
    {
        private IList<ColourFormattedPart> _result;

        [SetUp]
        public void GivenAMessageWithFormattedBlockWordInterpolatedWithPlainText_WhenParsed()
        {
            var colourFormatParser = new PushNotificationsHandler.Models.Services.ColourFormatParser();
            string messageText = "Hello Wo{colour:#00FF00}rld{colour}";

            _result = colourFormatParser.GetFormattedParts(messageText);
        }

        [Test]
        public void ThenOneMessagePartReturned()
        {
            Assert.That(_result.Count, Is.EqualTo(1));
        }

        [Test]
        public void ThenExpectedRgbColourValueSetInMessagePart()
        {
            var colourFormattedPart = _result[0];
            Assert.That(colourFormattedPart.ColourRgb, Is.EqualTo("#00FF00"));
        }

        [Test]
        public void ThenExpectedPartContentValueSetInMessagePart()
        {
            var colourFormattedPart = _result[0];
            Assert.That(colourFormattedPart.PartContent, Is.EqualTo("rld"));
        }
    }

    [TestFixture]
    public class ColourFormatParserSingleFormattedBlockOutOfRangeRgbColourTests
    {
        [Test]
        public void GivenAMessageWithSingleFormattedPartWithOutOfRangeColourRgbValue_WhenParsed_ThenIgnoredByParser()
        {
            var colourFormatParser = new PushNotificationsHandler.Models.Services.ColourFormatParser();
            string messageText = "Hello Wo{colour:#00ZZ00}rld{colour}";

            var result = colourFormatParser.GetFormattedParts(messageText);

            Assert.That(result, Is.Empty);
        }
    }
    
  
}