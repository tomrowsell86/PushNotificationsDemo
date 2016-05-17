namespace PushNotificationsHandler.Models
{
    public class ColourFormattableContent : IFormattableContent
    {
        private readonly string _colourRgb;
        private readonly string _partContent;

        public ColourFormattableContent(string colourRgb, string partContent)
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

        public string FormatContent()
        {
            return string.Format("<span style='color:{0}'>{1}</span>", ColourRgb, PartContent);
        }
    }
}