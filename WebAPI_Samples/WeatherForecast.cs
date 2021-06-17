using System;

namespace WebAPI_Samples
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

    //1.) Ergebnis einer WebAPI-Methode markieren und kopieren. 
    //2.) In VS-> Edit->Paste Special->JSON as Class

    //public class Rootobject
    //{
    //    public Class1[] Property1 { get; set; }
    //}

    //public class Class1
    //{
    //    public DateTime date { get; set; }
    //    public int temperatureC { get; set; }
    //    public int temperatureF { get; set; }
    //    public string summary { get; set; }
    //}

}
