using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelLib
{
    public class SensorData
    {
        public int Id { get; set; }
        public string SensorName { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public int Pressure { get; set; }
        public DateTime Time { get; set; }
        

        public SensorData()
        {
            
        }

        public SensorData(int id, string name, double temperature, double humidity, int pressure)
        {
            Id = id;
            SensorName = name;
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
            Time = DateTime.Now;
        }
        public SensorData(int id, string name, double temperature, double humidity, int pressure, DateTime dateTime)
        {
            Id = id;
            SensorName = name;
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
            Time = dateTime;
        }

        public override string ToString()
        {
            return $"{SensorName} - Data {Id} - Measured at {Time}\nTemp: {Temperature}°C\nHumidity: {Humidity}%\nPressure: {Pressure} ";
        }

        public override bool Equals(object obj)
        {
            return obj is SensorData data &&
                   Id == data.Id &&
                   SensorName == data.SensorName &&
                   Temperature == data.Temperature &&
                   Humidity == data.Humidity &&
                   Pressure == data.Pressure;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, SensorName, Temperature, Humidity, Pressure);
        }
    }
}
