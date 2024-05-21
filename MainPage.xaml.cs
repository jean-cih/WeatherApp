using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeatherApp
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>


    public partial class MainPage : Page
    {
        const string API = "fd81ebcddb1558c034dc367cb4a467e2";
        bool flagMoreInf = true;
        int cause = 0;

        public MainPage()
        {
            InitializeComponent();

            GetWeatherNsk();
        }

        private async void GetWeatherNsk()
        {
            HttpClient client = new HttpClient();
            string url = $"https://api.openweathermap.org/data/2.5/weather?q=Novosibirsk&appid={API}&units=metric";

            string response = await client.GetStringAsync(url);
            var json = JObject.Parse(response);

            string temp = json["main"]["temp"].ToString();
            double weatherTemp = Convert.ToDouble(temp);
            string feels = json["main"]["feels_like"].ToString();
            double weatherFeels = Convert.ToDouble(feels);

            city.Content = "Novosibirsk";
            temperature.Content = Math.Round(weatherTemp) + "°";
            feelsTemp.Content = "feels like   " + Math.Round(weatherFeels).ToString() + "°";

            GetInformation(cause);
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SearchPage());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private async void Settings_Click(object sender, RoutedEventArgs e)
        {
            if (flagMoreInf)
            {
                TranslateTransform trans1 = new TranslateTransform();
                settingsInf.RenderTransform = trans1;
                DoubleAnimation animY1 = new DoubleAnimation(0, 220, TimeSpan.FromSeconds(1.5));
                trans1.BeginAnimation(TranslateTransform.YProperty, animY1);
                flagMoreInf = false;
            }
            else
            {
                TranslateTransform trans2 = new TranslateTransform();
                settingsInf.RenderTransform = trans2;
                DoubleAnimation animY2 = new DoubleAnimation(220, 0, TimeSpan.FromSeconds(1.5));
                trans2.BeginAnimation(TranslateTransform.YProperty, animY2);
                flagMoreInf = true;
            }
        }

        private async void GetInformation(int form)
        {
            HttpClient client2 = new HttpClient();
            string url2 = $"https://api.openweathermap.org/data/2.5/forecast?q=Novosibirsk&appid={API}&units=metric";
            string response2 = await client2.GetStringAsync(url2);
            var json2 = JObject.Parse(response2);

            string icon1 = json2["list"][form]["weather"][0]["icon"].ToString();
            string icon2 = json2["list"][form + 1]["weather"][0]["icon"].ToString();
            string icon3 = json2["list"][form + 2]["weather"][0]["icon"].ToString();
            string icon4 = json2["list"][form + 3]["weather"][0]["icon"].ToString();
            string icon5 = json2["list"][form + 4]["weather"][0]["icon"].ToString();
            string icon6 = json2["list"][form + 5]["weather"][0]["icon"].ToString();
            string icon7 = json2["list"][form + 6]["weather"][0]["icon"].ToString();

            day1.Source = BitmapFrame.Create(new Uri($@"D:\LearningCSharp\WPF\WeatherApp\{icon1}.png"));
            day2.Source = BitmapFrame.Create(new Uri($@"D:\LearningCSharp\WPF\WeatherApp\{icon2}.png"));
            day3.Source = BitmapFrame.Create(new Uri($@"D:\LearningCSharp\WPF\WeatherApp\{icon3}.png"));
            day4.Source = BitmapFrame.Create(new Uri($@"D:\LearningCSharp\WPF\WeatherApp\{icon4}.png"));
            day5.Source = BitmapFrame.Create(new Uri($@"D:\LearningCSharp\WPF\WeatherApp\{icon5}.png"));
            day6.Source = BitmapFrame.Create(new Uri($@"D:\LearningCSharp\WPF\WeatherApp\{icon6}.png"));
            day7.Source = BitmapFrame.Create(new Uri($@"D:\LearningCSharp\WPF\WeatherApp\{icon7}.png"));

            string temp11 = json2["list"][form + 1]["main"]["temp"].ToString();
            string temp22 = json2["list"][form + 2]["main"]["temp"].ToString();
            string temp33 = json2["list"][form + 3]["main"]["temp"].ToString();
            string temp44 = json2["list"][form + 4]["main"]["temp"].ToString();
            string temp55 = json2["list"][form + 5]["main"]["temp"].ToString();
            string temp66 = json2["list"][form + 6]["main"]["temp"].ToString();
            string temp77 = json2["list"][form + 7]["main"]["temp"].ToString();

            temp1.Text = Math.Round(Convert.ToDouble(temp11)) + "°";
            temp2.Text = Math.Round(Convert.ToDouble(temp22)) + "°";
            temp3.Text = Math.Round(Convert.ToDouble(temp33)) + "°";
            temp4.Text = Math.Round(Convert.ToDouble(temp44)) + "°";
            temp5.Text = Math.Round(Convert.ToDouble(temp55)) + "°";
            temp6.Text = Math.Round(Convert.ToDouble(temp66)) + "°";
            temp7.Text = Math.Round(Convert.ToDouble(temp77)) + "°";

            string time11 = json2["list"][form]["dt_txt"].ToString();
            string time22 = json2["list"][form + 1]["dt_txt"].ToString();
            string time33 = json2["list"][form + 2]["dt_txt"].ToString();
            string time44 = json2["list"][form + 3]["dt_txt"].ToString();
            string time55 = json2["list"][form + 4]["dt_txt"].ToString();
            string time66 = json2["list"][form + 5]["dt_txt"].ToString();
            string time77 = json2["list"][form + 6]["dt_txt"].ToString();

            hum1.Text = json2["list"][form]["main"]["humidity"].ToString() + "%";
            hum2.Text = json2["list"][form + 1]["main"]["humidity"].ToString() + "%";
            hum3.Text = json2["list"][form + 2]["main"]["humidity"].ToString() + "%";
            hum4.Text = json2["list"][form + 3]["main"]["humidity"].ToString() + "%";
            hum5.Text = json2["list"][form + 4]["main"]["humidity"].ToString() + "%";
            hum6.Text = json2["list"][form + 5]["main"]["humidity"].ToString() + "%";
            hum7.Text = json2["list"][form + 6]["main"]["humidity"].ToString() + "%";

            time1.Text = time2.Text = time3.Text = time4.Text = time5.Text = time6.Text = time7.Text = "";

            for (int i = 10; i < 16; i++)
            {
                time1.Text += time11[i];
                time2.Text += time22[i];
                time3.Text += time33[i];
                time4.Text += time44[i];
                time5.Text += time55[i];
                time6.Text += time66[i];
                time7.Text += time77[i];
            }
        }

        private void Day1_Click(object sender, RoutedEventArgs e)
        {
            cause = 0;  
            GetInformation(cause);
        }

        private void Day2_Click(object sender, RoutedEventArgs e)
        {
            cause = 8;
            GetInformation(cause);
        }

        private void Day3_Click(object sender, RoutedEventArgs e)
        {
            cause = 16;
            GetInformation(cause);
        }

        private void Day4_Click(object sender, RoutedEventArgs e)
        {
            cause = 24;
            GetInformation(cause);
        }

        private void Day5_Click(object sender, RoutedEventArgs e)
        {
            cause = 32;
            GetInformation(cause);
        }
    }
}
