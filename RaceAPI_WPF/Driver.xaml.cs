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

namespace RaceAPI
{
    /// <summary>
    /// Interaktionslogik für Driver.xaml
    /// </summary>
    public partial class Driver : UserControl
    {
        public int number { get; set; }
        public string _name { get; set; }
        public string _team { get; set; }
        private Series series;

        public Driver(int number, string name, string team)
        {
            this.number = number;
            _name = name;
            _team = team;
        }
        public void initialize(Series series)
        {
            InitializeComponent();

            nummer.Text = "Nummer: " + number.ToString();
            name.Text = "Name: " + _name;
            team.Text = "Team: " + _team;
            recentResults.Items.Clear();

            this.series = series;
            List<KeyValuePair<string, int>> results = series.getResultsOfDriver(number);
            results.Reverse();
            int index = 0;
            foreach (KeyValuePair<string, int> result in results)
            {
                recentResults.Items.Add(new KeyValuePair<string, string>(result.Key, "| " + result.Value.ToString("D2") + " Punkte"));
                if (index == 9)
                {
                    break;
                }
                index++;
            }
        }
        public void backToSeries(object sender, RoutedEventArgs e)
        {
            series.initialize();
            Switcher.switchPage(series);
        }
        public void editDriver(object sender, RoutedEventArgs e)
        {
            series.initialize();
            series.editDriver(this);
            Switcher.switchPage(series);
        }
        public void deleteDriver(object sender, RoutedEventArgs e)
        {
            series.initialize();
            series.deleteDriver(this);
            Switcher.switchPage(series);  
        }
    }
}
