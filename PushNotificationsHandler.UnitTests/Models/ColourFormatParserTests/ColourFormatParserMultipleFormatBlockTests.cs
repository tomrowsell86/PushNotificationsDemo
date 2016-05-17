using System.Collections.Generic;
using NUnit.Framework;
using PushNotificationsHandler.Models;
using PushNotificationsHandler.Models.Services;

namespace PushNotificationsHandler.UnitTests.Models.ColourFormatParserTests
{
    [TestFixture]
    public class ColourFormatParserMultipleFormatBlockTests
    {
        private FormatParseResult _result;

        [SetUp]
        public void GivenMultipleFormattedPartsInMessage_WhenParsed()
        {
            string messageText = "{colour:#00FF00}Part 1{colour} and then {colour:#00FF00}Part 2{colour} and then {colour:#00FF00}Part 3{colour}";
            var colourFormatParser = new FormatParser();

            _result = colourFormatParser.FormatMessage(messageText);
        }

        [Test]
        public void ThenExpectedNumberOfPartsReturned()
        {
            Assert.That(_result.FormattedParts.Count, Is.EqualTo(3));
        }
    }
}