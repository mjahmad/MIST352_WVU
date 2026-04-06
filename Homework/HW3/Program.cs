using System;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;

namespace HW3
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to the Weather App (Beginner Version)");
            Console.WriteLine("Enter a location (e.g., Morgantown, WV):");

            // Once done, change this to input from user.
            string location = "Morgantown, WV";

            if (location == "")
            {
                Console.WriteLine("Location cannot be empty.");
                return;
            }

            // STEP 1: Get coordinates
            // Pay attention to this. What does result contain?

            string result = await GetCoordinates(location);

            if (result == "")
            {
                Console.WriteLine("Could not find coordinates.");
                return;
            }
           

            string[] parts = result.Split(',');

            double latitude = Convert.ToDouble(parts[0]);
            double longitude = Convert.ToDouble(parts[1]);

            Console.WriteLine("Latitude: " + latitude);
            Console.WriteLine("Longitude: " + longitude);

            // STEP 2: Find nearest station
            string stationResult = await FindNearestStation(latitude, longitude);
            Console.WriteLine($"============================== {stationResult} ================================= ");

            if (stationResult == "")
            {
                Console.WriteLine("No station found.");
                return;
            }

            string[] stationParts = stationResult.Split('|');
            string stationId = stationParts[0];
            string stationName = stationParts[1];

            Console.WriteLine("Nearest Station: " + stationName);

            // STEP 3: Get temperature
            double tempC = await GetTemperature(stationId);

            if (tempC == -999)
            {
                Console.WriteLine("No temperature data available.");
                return;
            }

            double tempF = ConvertToFahrenheit(tempC);

            Console.WriteLine("Temperature: " + Math.Round(tempF, 1) + " F");
        }

        // ---------------------------------------------------------
        // ((( LEAVE AS IS ))) 
        // METHOD 1: GetCoordinates
        // Purpose: Convert location to latitude and longitude
        // Returns: "lat,lon"
        // ---------------------------------------------------------
        
        static async Task<string> GetCoordinates(string location)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "MIST352App");

            string url = "https://nominatim.openstreetmap.org/search?q=" + location + "&format=json&limit=1";
            Console.WriteLine($"URL accessed to get data: {url}");
            try
            {
                string response = await client.GetStringAsync(url);

                int latIndex = response.IndexOf("\"lat\":\"");
                int lonIndex = response.IndexOf("\"lon\":\"");

                if (latIndex != -1 && lonIndex != -1)
                {
                    string lat = response.Substring(latIndex + 7, 7);
                    string lon = response.Substring(lonIndex + 7, 8);

                    return lat + "," + lon;
                }
            }
            catch
            {
                return "";
            }

            return "";
        }

        // ---------------------------------------------------------
        //((( LEAVE AS IS ))) 
        // METHOD 2: CalculateDistance
        // Purpose: Calculate distance between two points
        // ---------------------------------------------------------
        static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            double r = 3958.8;

            double dLat = (lat2 - lat1) * Math.PI / 180;
            double dLon = (lon2 - lon1) * Math.PI / 180;

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2)
                     + Math.Cos(lat1 * Math.PI / 180)
                     * Math.Cos(lat2 * Math.PI / 180)
                     * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return r * c;
        }

        // ---------------------------------------------------------
        // ((( LEAVE AS IS ))) 
        // METHOD 3: FindNearestStation
        // Purpose: Find closest station
        // Returns: "stationId|stationName"
        // ---------------------------------------------------------
        static async Task<string> FindNearestStation(double userLat, double userLon)
        {
            HttpClient client = new HttpClient();
            string url = "https://noaa-ghcn-pds.s3.amazonaws.com/ghcnd-stations.txt";

            try
            {
                Stream stream = await client.GetStreamAsync(url);
                StreamReader reader = new StreamReader(stream);

                string line;
                double closestDistance = 999999;

                string bestId = "";
                string bestName = "";

                int count = 0;

                while ((line = reader.ReadLine()) != null && count < 1000)
                {
                    if (line.Length > 70)
                    {
                        try
                        {
                            string id = line.Substring(0, 11).Trim();
                            double lat = Convert.ToDouble(line.Substring(12, 8).Trim());
                            double lon = Convert.ToDouble(line.Substring(21, 9).Trim());
                            string name = line.Substring(41, 30).Trim();

                            double distance = CalculateDistance(userLat, userLon, lat, lon);

                            if (distance < closestDistance)
                            {
                                closestDistance = distance;
                                bestId = id;
                                bestName = name;
                            }

                            count++;
                        }
                        catch
                        {
                            // skip bad lines
                        }
                    }
                }

                return bestId + "|" + bestName;
            }
            catch
            {
                return "";
            }
        }

        // ---------------------------------------------------------
        // ((( LEAVE AS IS HOWEVER, EXPLORE THIS FULLY, ESPECIALLY THE WHILE LOOP))) 

        // METHOD 4: GetTemperature
        // Purpose: Get latest temperature in Celsius
        // Returns: double temperature
        // ---------------------------------------------------------
        static async Task<double> GetTemperature(string stationId)
        {
            HttpClient client = new HttpClient();

            string url = "https://noaa-ghcn-pds.s3.amazonaws.com/csv/by_station/" + stationId + ".csv";

            try
            {
                Stream stream = await client.GetStreamAsync(url);
                StreamReader reader = new StreamReader(stream);

                string line;
                double latestTemp = -999;

                while ((line = reader.ReadLine()) != null)
                {
                    //Explore what line really is. Print maybe?
                    string[] parts = line.Split(',');
                    
                    if (parts.Length > 3)
                    {
                        if (parts[2] == "TMAX")
                        {

                            latestTemp = Convert.ToDouble(parts[3]) / 10.0;
                        }
                    }
                }

                return latestTemp;
            }
            catch
            {
                return -999;
            }
        }

        // ---------------------------------------------------------
        // YOU CODE THIS
        // METHOD 5: ConvertToFahrenheit
        // Purpose: Convert Celsius to Fahrenheit
        // ---------------------------------------------------------
        static double ConvertToFahrenheit(double celsius)
        {
            return celsius;
        }

        // ADD THE REST OF METHODS HERE
    }
}