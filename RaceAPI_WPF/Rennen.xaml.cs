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
    /// Interaktionslogik für Rennen.xaml
    /// </summary>
    public partial class Rennen : UserControl
    {
        public string id { get; set; }
        public string name { get; set; }
        public string ort { get; set; }
        //public DateTime termin { get; set; }
        public List<int> ergebnis { get; set; }
        Series series;

        public Rennen(string id, string name, string ort, List<int> ergebnis)
        {
            this.id = id;
            this.name = name;
            this.ort = ort;
            this.ergebnis = ergebnis;
        }
        public void initialize(Series series)
        {
            this.series = series;
            InitializeComponent();
            rennname.Text = name;
            rennort.Text = ort;

            for (int i = 0; i < ergebnis.Count; i++)
            {
                result.Items.Add(new KeyValuePair<string, string>((i + 1).ToString("D2") + ". Platz", "| Fahrer [" + ergebnis[i].ToString("D2") + "]"));

            }
        }
        public void backToSeries(object sender, RoutedEventArgs e)
        {
            series.initialize(Series.DisplayMode.Results);
            Switcher.switchPage(series);
        }
        public void editResult(object sender, RoutedEventArgs e)
        {
            series.initialize(Series.DisplayMode.Results);
            series.editResult(this);
            Switcher.switchPage(series);
        }
        public void deleteResult(object sender, RoutedEventArgs e)
        {
            series.initialize(Series.DisplayMode.Results);
            series.deleteResult(this);
            Switcher.switchPage(series);
        }

    }
}
