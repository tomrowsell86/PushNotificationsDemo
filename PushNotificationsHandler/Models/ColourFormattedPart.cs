namespace PushNotificationsHandler.Models
{
    public class ColourFormattedPart
    {
        private readonly string _colourRgb;
        private readonly string _partContent;

        public ColourFormattedPart(string colourRgb, string partContent)
        {
            _colourRgb = colourRgb;
            _partContent = partContent;
        }

        public string ColourRgb
        {
            get { return _colourRgb; }
        }

        public string PartContent
        {
            get { return _partContent; }
        }
    }
}