namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            if (line == null)
            {
                return null;
            }

            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                return null;
            }

            double lattitude, longitude;
            double.TryParse(cells[0], out lattitude);
            double.TryParse(cells[1], out longitude);
            string name = cells[2];
            Tacobell TBell = new Tacobell();
            TBell.Name = name;
            TBell.Location = new Point() { Latitude = lattitude, Longitude = longitude };

            return TBell;
        }
    }
}