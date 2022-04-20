using ModelLib;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace MockSensor
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new();
            var temperature = 20;
            var humidity = 50;

            var url = "https://localhost:44367/api/Sensor";


            HttpClientHandler clientHandler = new();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new(clientHandler);

            while (true)
            {

                var targetTemp = random.Next(-15, 35);
                var targetHum = random.Next(10, 100);

                Console.WriteLine("new targets: T: " + targetTemp + " & H: " + targetHum);

                while (targetTemp != temperature || targetHum != humidity)
                {
                    if (targetTemp > temperature)
                    {
                        temperature += random.Next(4, 8);
                        if (targetTemp < temperature)
                        {
                            temperature = targetTemp;
                        }
                    }
                    else
                    {
                        temperature -= random.Next(4, 8);
                        if (targetTemp > temperature)
                        {
                            temperature = targetTemp;
                        }
                    }


                    if (targetHum > humidity)
                    {
                        humidity += random.Next(4, 16);
                        if (targetHum < humidity)
                        {
                            humidity = targetHum;
                        }
                    }
                    else
                    {
                        humidity -= random.Next(4, 16);
                        if (targetHum > humidity)
                        {
                            humidity = targetHum;
                        }
                    }


                    Console.WriteLine("T: " + temperature + " H: " + humidity);
                    var data = new SensorData(0, "Mock Sensor", temperature, humidity, 0);
                    var myJson = JsonSerializer.Serialize(data);

                    var response = client.PostAsync(url, new StringContent(myJson, Encoding.UTF8, "application/json"));
                    Console.WriteLine(response.Result.StatusCode);

                    Thread.Sleep(2000);
                }
            }
        }
    }
}
