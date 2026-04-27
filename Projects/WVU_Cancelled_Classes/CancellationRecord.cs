namespace Project_1
{
    internal class CancellationRecord
    {
        public string    _date;
        public bool      _wasCancelled;
        public WeatherDay _weather;

        public CancellationRecord(string date, bool cancelled, WeatherDay weather)
        {
            _date         = date;
            _wasCancelled = cancelled;
            _weather      = weather;
        }
    }
}
