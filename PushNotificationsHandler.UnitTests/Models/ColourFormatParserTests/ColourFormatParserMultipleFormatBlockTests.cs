using System.Collections.Generic;
using NUnit.Framework;
using PushNotificationsHandler.Models;
using PushNotificationsHandler.Models.Services;

namespace PushNotificationsHandler.UnitTests.Models.ColourFormatParserTests
{
    [TestFixture]
    public class ColourFormatParserMultipleFormatBlockTests
    {
        private IList<ColourFormattedPart> _result;

        [SetUp]
        public void GivenMultipleFormattedPartsInMessage_WhenParsed()
        {
            string messageText = "{colour:#00FF00}Part 1{colour} and then {colour:#00FF00}Part 2{colour} and then {colour:#00FF00}Part 3{colour}";
            var colourFormatParser = new ColourFormatParser();

            _result = colourFormatParser.GetFormattedParts(messageText);
        }

        [Test]
        public void ThenExpectedNumberOfPartsReturned()
        {
            Assert.That(_result.Count, Is.EqualTo(3));
        }

        [Test]
        public void ThenCorrectOrdinalsSetInResult()
        {
            Assert.That(_result[0].PartContent, Is.EqualTo("Part 1"));
            Assert.That(_result[0].Ordinal, Is.EqualTo(1));

            Assert.That(_result[1].PartContent, Is.EqualTo("Part 2"));
            Assert.That(_result[1].Ordinal, Is.EqualTo(2));

            Assert.That(_result[2].PartContent, Is.EqualTo("Part 3"));
            Assert.That(_result[2].Ordinal, Is.EqualTo(3));


        }
    }
}