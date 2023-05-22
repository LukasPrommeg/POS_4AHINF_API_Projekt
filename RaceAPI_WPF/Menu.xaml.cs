using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RaceAPI
{
    /// <summary>
    /// Interaktionslogik für Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        string addName = null;
        List<int> addPunkteSystem = null;
        string apiURL = "";

        public Menu(string url = "http://localhost:6969")
        {
            apiURL = url;
            InitializeComponent();
            popup.Visibility = Visibility.Hidden;
            debug.Text = "";

            debug.Text = "Connecting to " + apiURL + "! Please wait!";
            selectSeries.IsEnabled = false;
            add.IsEnabled = false;
            load.IsEnabled = false;
            delete.IsEnabled = false;
            refresh.IsEnabled = false;
            connectToAPI(apiURL + "/getSeriesNames");

            Switcher.changeTitle("Hauptmenü");
        }
        private async Task connectToAPI(string url)
        {
            try
            {
                HttpClient client = new HttpClient();

                string result = await client.GetStringAsync(url);
                result = result.Replace("[", "");
                result = result.Replace("]", "");
                result = result.Replace("\"", "");
                string[] names = result.Split(",");

                selectSeries.ItemsSource = names;
                string[] displayURL = url.Split("/");
                debug.Text = "Verbunden mit " + displayURL[displayURL.Length - 2];
                selectSeries.IsEnabled = true;
                add.IsEnabled = true;
                load.IsEnabled = true;
                delete.IsEnabled = true;
                refresh.IsEnabled = true;

            }
            catch (Exception e)
            {
                debug.Text = "Bitte Adresse einer laufenden Instanz der RaceAPI eingeben! (http://[IP-ADDRESSE]:6969)";

                selectSeries.IsEnabled = false;
                add.IsEnabled = false;
                load.IsEnabled = false;
				delete.IsEnabled = false;
				refresh.IsEnabled = true;


                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(e.Message, "Fehler beim Verbindungsaufbau", button, icon);
            }
        }
        public void addSeries(object sender, RoutedEventArgs e)
        {
            handleAddSeries();
        }
        public void deleteSeries(object sender, RoutedEventArgs e)
        {
            try
            {
                Task<string> response = new HttpClient().DeleteAsync(apiURL + "/" + selectSeries.Text + "/delete").Result.Content.ReadAsStringAsync();

                MessageBox.Show(response.Result, "Antwort der API!", MessageBoxButton.OK, MessageBoxImage.Information);
                serverURL.Text = apiURL;
                refresh.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler beim Löschen", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void handleAddSeries()
        {
            if (addName == null)
            {
                popup.Visibility = Visibility.Visible;
                popupinstructions.Text = "Name der Serie:";
                addName = "";
            }
            else if (addName != null && addPunkteSystem == null)
            {
                addName = popupinput.Text.Replace(" ", "");
                popupinstructions.Text = "Geben sie das Punktesystem ein: (Format: [Punkte 1.Platz],[Punkte 2.Platz], ...";
                popupinput.Text = "";
                addPunkteSystem = new List<int>();
            }
            else
            {
                try
                {
                    string[] punkteSystem = popupinput.Text.Split(",");
                    foreach (string platz in punkteSystem)
                    {
                        addPunkteSystem.Add(int.Parse(platz));
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Fehler in der Liste! Try again!", MessageBoxButton.OK, MessageBoxImage.Error);

                    return;
                }

                JArray punkteSys = new JArray();

                foreach(int platz in addPunkteSystem)
                {
                    punkteSys.Add(platz);
                }

                JObject json = new JObject
                {
                    { "name", addName },
                    { "punkteSystem", punkteSys }
                };

                HttpContent content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

                Task<string> response = new HttpClient().PostAsync(apiURL + "/addSeries", content).Result.Content.ReadAsStringAsync();

                MessageBox.Show(response.Result, "Antwort der API!", MessageBoxButton.OK, MessageBoxImage.Information);

                popupinput.Text = "";
                addName = null;
                addPunkteSystem = null;
                popup.Visibility = Visibility.Hidden;
                serverURL.Text = apiURL;
                refresh.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        }
        public void loadSeries(object sender, RoutedEventArgs e)
        {
            if(selectSeries.Text != "")
            {
                HttpClient client = new HttpClient();
                string json = client.GetStringAsync(apiURL + "/" + selectSeries.Text).Result;
                try
                {
                    Series serie = JsonConvert.DeserializeObject<Series>(json);
                    serie.initialize();
                    serie.url= apiURL;
                    Switcher.switchPage(serie);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception while converting JsonObject");
                }
            }
        }
        public void refreshURL(object sender, RoutedEventArgs e)
        {
            Switcher.switchPage(new Menu(serverURL.Text));
        }
        private void serverURL_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public void onPopUPSubmit(object sender, RoutedEventArgs e)
        {
            handleAddSeries();
        }
        public void onPopUPCancel(object sender, RoutedEventArgs e)
        {
            addName = null;
            addPunkteSystem = null;
            popupinstructions.Text = "Instructions";
            popupinput.Text = "";
            popup.Visibility = Visibility.Hidden;
        }
    }
}
