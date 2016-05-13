namespace PushNotificationsHandler.Models
{
    public class ColourFormattedPart
    {
        private readonly string _colourRgb;
        private readonly string _partContent;
        private readonly int _ordinal;

        public ColourFormattedPart(string colourRgb, string partContent, int ordinal)
        {
            _colourRgb = colourRgb;
            _partContent = partContent;
            _ordinal = ordinal;
        }

        public string ColourRgb
        {
            get { return _colourRgb; }
        }

        public string PartContent
        {
            get { return _partContent; }
        }

        public int Ordinal
        {
            get { return _ordinal; }
        }
    }
}