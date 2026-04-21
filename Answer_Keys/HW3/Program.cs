using System.Net;
using System.Text.Json;

namespace WeatherApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double maxTempC = 0, minTempC = 0, agvTempC = 0, per = 0, snow = 0;
            double minTempF = 0, avgTempF = 0;
            Console.WriteLine("Weather Finder");

            Console.Write("Enter location: ");
            string location = Console.ReadLine();

            if (location == null || location.Trim() == "")
            {
                Console.WriteLine("Invalid location.");
                return;
            }

            double latitude = GetLatitude(location);
            double longitude = GetLongitude(location);

            if (latitude == 0 && longitude == 0)
            {
                Console.WriteLine("Could not find location.");
                return;
            }

            Console.WriteLine("Latitude: " + latitude + " Longitude: " + longitude);

            string[] stationIds = GetNearestStationIds(latitude, longitude);
            string[] stationNames = GetNearestStationNames(latitude, longitude);

            string finalStation = "";
            double maxTempF = 0;

            bool found = false;

            for (int i = 0; i < stationIds.Length; i++)
            {
                Console.WriteLine("Checking station: " + stationNames[i]);

                // EXISTING METHOD (YOU WILL STUDY THIS)
                maxTempC = GetMaxTemperature(stationIds[i], 2026);
                minTempC = GetMinTemperature(stationIds[i], 2026);
                agvTempC = GetAverageTemperature(stationIds[i], 2026);
                per = GetPrecipitation(stationIds[i], 2026);
                snow = GetSnowfall(stationIds[i], 2026);

                if (maxTempC != -999)
                {
                    finalStation = stationNames[i];

                    // ================================
                    // ADD YOUR METHOD CALLS HERE
                    // Example:
                    // double minTemp = GetMinTemperature(stationIds[i], 2026);
                    // Then convert temp to Fahrenheit 
                    // ================================

                    //maxTempF = ConvertToFahrenheit(maxTempC);
                    maxTempF = ConvertToFahrenheit(maxTempC);
                    minTempF = ConvertToFahrenheit(minTempC);
                    avgTempF = ConvertToFahrenheit(agvTempC);

                    found = true;
                    break;
                }
            }

            if (found)
            {
                Console.WriteLine("\nWeather at " + finalStation + ":");

                //Console.WriteLine("Max Temperature: " + maxTempC + " C");
                Console.WriteLine("\nWeather at " + finalStation + ":");

                Console.WriteLine("Max Temperature: " + maxTempF + " F");
                Console.WriteLine("Min Temperature: " + minTempF + " F");
                Console.WriteLine("Average Temperature: " + avgTempF + " F");
                Console.WriteLine("Precipitation: " + per);
                Console.WriteLine("Snowfall: " + snow);



                // ================================
                // DISPLAY YOUR RESULTS HERE
                // Example:
                // Console.WriteLine("Min Temperature: " + ... );
                // ================================
            }
            else
            {
                Console.WriteLine("No 2026 data found.");
            }
        }

        // --------------------------
        // GEOCODING METHODS
        // --------------------------

        static double GetLatitude(string location)
        {
            string json = CallGeocodeAPI(location);
            return ExtractLatitude(json);
        }

        static double GetLongitude(string location)
        {
            string json = CallGeocodeAPI(location);
            return ExtractLongitude(json);
        }

        static string CallGeocodeAPI(string location)
        {
            string encoded = Uri.EscapeDataString(location);
            string url = "https://nominatim.openstreetmap.org/search?q=" + encoded + "&format=json&limit=1";

            WebClient client = new WebClient();
            client.Headers.Add("User-Agent", "MIST352App");

            try
            {
                return client.DownloadString(url);
            }
            catch
            {
                return "";
            }
        }

        static double ExtractLatitude(string json)
        {
            try
            {
                JsonDocument doc = JsonDocument.Parse(json);

                if (doc.RootElement.GetArrayLength() > 0)
                {
                    JsonElement first = doc.RootElement[0];
                    return Convert.ToDouble(first.GetProperty("lat").GetString());
                }
            }
            catch { }

            return 0;
        }

        static double ExtractLongitude(string json)
        {
            try
            {
                JsonDocument doc = JsonDocument.Parse(json);

                if (doc.RootElement.GetArrayLength() > 0)
                {
                    JsonElement first = doc.RootElement[0];
                    return Convert.ToDouble(first.GetProperty("lon").GetString());
                }
            }
            catch { }

            return 0;
        }

        // --------------------------
        // STATION METHODS
        // --------------------------

        static string[] GetNearestStationIds(double userLat, double userLon)
        {
            string[] ids = new string[10];
            double[] distances = new double[10];

            for (int i = 0; i < 10; i++)
            {
                distances[i] = 999999;
                ids[i] = "";
            }

            string url = "https://noaa-ghcn-pds.s3.amazonaws.com/ghcnd-stations.txt";
            WebClient client = new WebClient();
            string data = client.DownloadString(url);

            string[] lines = data.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                if (line.Length < 72) continue;

                try
                {
                    string id = line.Substring(0, 11).Trim();
                    double lat = Convert.ToDouble(line.Substring(12, 8).Trim());
                    double lon = Convert.ToDouble(line.Substring(21, 9).Trim());

                    double distance = CalculateDistance(userLat, userLon, lat, lon);

                    InsertStation(ids, distances, id, distance);
                }
                catch { }
            }

            return ids;
        }

        static string[] GetNearestStationNames(double userLat, double userLon)
        {
            string[] names = new string[10];
            double[] distances = new double[10];

            for (int i = 0; i < 10; i++)
            {
                distances[i] = 999999;
                names[i] = "";
            }

            string url = "https://noaa-ghcn-pds.s3.amazonaws.com/ghcnd-stations.txt";
            WebClient client = new WebClient();
            string data = client.DownloadString(url);

            string[] lines = data.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                if (line.Length < 72) continue;

                try
                {
                    string name = line.Substring(41, 30).Trim();
                    double lat = Convert.ToDouble(line.Substring(12, 8).Trim());
                    double lon = Convert.ToDouble(line.Substring(21, 9).Trim());

                    double distance = CalculateDistance(userLat, userLon, lat, lon);

                    InsertStation(names, distances, name, distance);
                }
                catch { }
            }

            return names;
        }

        static void InsertStation(string[] array, double[] distances, string value, double distance)
        {
            for (int i = 0; i < 10; i++)
            {
                if (distance < distances[i])
                {
                    for (int j = 9; j > i; j--)
                    {
                        distances[j] = distances[j - 1];
                        array[j] = array[j - 1];
                    }

                    distances[i] = distance;
                    array[i] = value;
                    break;
                }
            }
        }

        // --------------------------
        // WEATHER METHOD (TEMPLATE)
        // --------------------------

        /// STUDY THIS METHOD — YOU WILL COPY THIS LOGIC
        static double GetMaxTemperature(string stationId, int targetYear)
        {
            string[] lines = ReadStationFile(stationId);

            double temp = -999;

            for (int i = 0; i < lines.Length; i++)
            {
                //Console.WriteLine(lines[i]);
                string[] parts = lines[i].Split(',');

                if (parts.Length >= 4 && parts[2] == "TMAX")
                {
                    string date = parts[1];
                    int year = Convert.ToInt32(date.Substring(0, 4));

                    if (year == targetYear)
                    {
                        temp = Convert.ToDouble(parts[3]) / 10.0;
                    }
                }
            }

            return temp;
        }

        static string[] ReadStationFile(string stationId)
        {
            string url = "https://noaa-ghcn-pds.s3.amazonaws.com/csv/by_station/" + stationId + ".csv";

            WebClient client = new WebClient();

            try
            {
                string data = client.DownloadString(url);
                return data.Split('\n');
            }
            catch
            {
                return new string[0];
            }
        }

        static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            double r = 3958.8;

            double dLat = (lat2 - lat1) * Math.PI / 180.0;
            double dLon = (lon2 - lon1) * Math.PI / 180.0;

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(lat1 * Math.PI / 180.0) *
                       Math.Cos(lat2 * Math.PI / 180.0) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return r * c;
        }

        static double GetMinTemperature(string stationId, int targetYear)
        {
            string[] lines = ReadStationFile(stationId);

            double temp = -999;

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');

                if (parts.Length >= 4 && parts[2] == "TMIN")
                {
                    string date = parts[1];
                    int year = Convert.ToInt32(date.Substring(0, 4));

                    if (year == targetYear)
                    {
                        temp = Convert.ToDouble(parts[3]) / 10.0;
                    }
                }
            }

            return temp;
        }

        static double GetPrecipitation(string stationId, int targetYear)
        {
            string[] lines = ReadStationFile(stationId);

            double value = -999;

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');

                if (parts.Length >= 4 && parts[2] == "PRCP")
                {
                    string date = parts[1];
                    int year = Convert.ToInt32(date.Substring(0, 4));

                    if (year == targetYear)
                    {
                        value = Convert.ToDouble(parts[3]) / 10.0;
                    }
                }
            }

            return value;
        }

        static double GetSnowfall(string stationId, int targetYear)
        {
            string[] lines = ReadStationFile(stationId);

            double value = -999;

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');

                if (parts.Length >= 4 && parts[2] == "SNOW")
                {
                    string date = parts[1];
                    int year = Convert.ToInt32(date.Substring(0, 4));

                    if (year == targetYear)
                    {
                        value = Convert.ToDouble(parts[3]) / 10.0;
                    }
                }
            }

            return value;
        }

        static double GetAverageTemperature(string stationId, int targetYear)
        {
            double max = GetMaxTemperature(stationId, targetYear);
            double min = GetMinTemperature(stationId, targetYear);

            if (max == -999 || min == -999)
                return -999;

            return (max + min) / 2;
        }

        static double ConvertToFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }
    }
}