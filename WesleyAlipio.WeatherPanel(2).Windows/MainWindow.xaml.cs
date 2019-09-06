using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RestSharp;
using Newtonsoft.Json;
using System.IO;
namespace WesleyAlipio.WeatherPanel_2_.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnGetWeather_Click(object sender, RoutedEventArgs e)
        {
            var client = new RestClient("http://api.openweathermap.org/data/2.5/weather?q=Orani&APPID=171a8ba9371cefa50663a40a1ca93eed");
            var request = new RestRequest("", Method.GET);
            IRestResponse response = client.Execute(request);

            var content = response.Content;
            var area = JsonConvert.DeserializeObject<WeatherArea>(content);

            lblSummary.Content = area.Weather[0].description;
            lblHumidity.Content = "Humidity: " + area.Main.humidity;
            lblTemperature.Content = "Temperature: " + area.Main.Temp;
            lblPressure.Content = "Pressure: " + area.Main.Pressure;
            lblWindSpeed.Content = "WindSpeed" + area.Wind.speed;



        }
             public class WeatherArea
        {
            public wSpeed Wind { get; set; }
            
            public CurrentWeather Main { get; set; }

            public wSummary[] Weather { get; set; }
        }
        public class CurrentWeather
        {
            public string humidity { get; set; }

            public string Temp { get; set; }

            public string Pressure { get; set; }


        }
        public class wSummary 
        {
            public string description { get; set; }

            public string icon { get; set; }
        }
        public class wSpeed
        {
            public string speed { get; set; }
        }

    }
    
}
