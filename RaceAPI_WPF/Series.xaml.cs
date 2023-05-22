using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaktionslogik für Series.xaml
    /// </summary>
    public partial class Series : UserControl
    {
        public enum DisplayMode
        {
            Standings,
            Results
        }
        public string url = "";
        public string name { get; set; }
        public List<Rennen> rennenList { get; set; }
        public List<int> punkteSystem { get; set; }
        public List<Driver> fahrerfeld { get; set; }
        public Dictionary<int, int> gesamtWertung { get; set; }
        private DisplayMode currentDisplayMode = DisplayMode.Standings;
        private string raceIDtoUpdate = "";

        public Series()
        {
            name = "RENNSERIE";
            punkteSystem = new List<int>();
            gesamtWertung = new Dictionary<int, int>();
            fahrerfeld = new List<Driver>();
            rennenList = new List<Rennen>();
        }
        public void initialize(DisplayMode target = DisplayMode.Standings)
        {
            currentDisplayMode = DisplayMode.Standings;

            InitializeComponent();
            Switcher.changeTitle(name);

            popUP.Visibility = Visibility.Hidden;
            popUPBackground.Visibility = Visibility.Hidden;
            standingsPanel.Visibility = Visibility.Visible;

            standings.Items.Clear();

            if (target == DisplayMode.Results)
            {
                showRaceResults(null, null);
            }
            else
            {
                title.Text = "Standings";
                backToMenuBTN.Content = "Back";
                showRaceResultsBTN.Content = "Results";
                displayStandings();
            }
        }
        private void displayStandings()
        {
            standings.Items.Clear();

            if (url != "")
            {
                try
                {
                    HttpClient client = new HttpClient();
                    string jsonDrivers = client.GetStringAsync(url + "/" + name + "/getStandings").Result;

                    gesamtWertung = new Dictionary<int, int>(JsonConvert.DeserializeObject<Dictionary<int,int>>(jsonDrivers));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Fehler beim Anzeigen der Standings!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            int maxPoints = 0;

            foreach(var points in gesamtWertung)
            {
                if(points.Value > maxPoints)
                {
                    maxPoints = points.Value;
                }
            }

            int index = 1;
            foreach (var item in gesamtWertung.OrderByDescending(key => key.Value))
            {
                List<Driver> matches = fahrerfeld.Where(p => p.number == item.Key).ToList();
                KeyValuePair<string, string> standing;
                if (matches.Count == 1)
                {
                    standing = new KeyValuePair<string, string>(index + ". [" + item.Key.ToString() + "] " + matches[0]._name, " | " + item.Value.ToString("D" + maxPoints.ToString().Length) + " Punkte");
                }
                else
                {
                    standing = new KeyValuePair<string, string>(index + ". [" + item.Key.ToString() + "] ", " | " + item.Value.ToString("D" + maxPoints.ToString().Length) + " Punkte");
                }
                standings.Items.Add(standing);

                ItemCollection itemCollection = standings.Items;
                index++;
            }
        }
        private void displayResults()
        {
            standings.Items.Clear();

            try
            {
                HttpClient client = new HttpClient();
                string jsonRennen = client.GetStringAsync(url + "/" + name + "/getResults").Result;

                rennenList = new List<Rennen>(JsonConvert.DeserializeObject<Rennen[]>(jsonRennen));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler beim Anzeigen der Resultate!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            foreach (Rennen rennen in rennenList)
            {
                standings.Items.Add(new KeyValuePair<string, string>(rennen.name, rennen.ort));
            }
        }
        public void clickDriver(object sender, RoutedEventArgs e)
        {
            if(currentDisplayMode == DisplayMode.Standings)
            {
                object a = standings.SelectedItem;
                KeyValuePair<string, string> pair = (KeyValuePair<string, string>)a;
                string nrStr = pair.Key.Split("[")[1].Split("]")[0];
                int nr = int.Parse(nrStr);

                if (a != null)
                {
                    List<Driver> matches = fahrerfeld.Where(p => p.number == nr).ToList();
                    if (matches.Count == 1)
                    {
                        matches[0].initialize(this);
                        Switcher.switchPage(matches[0]);
                    }
                    else
                    {
                        input1field.Text = nr.ToString();
                        input1field.IsEnabled = false;
                        input2field.Text = "";
                        input3field.Text = "";

                        popUP.Visibility = Visibility.Visible;
                        popUPBackground.Visibility = Visibility.Visible;

                        popUPTitle.Text = "Fahrer Hinzufügen:";
                        input1.Text = "Fahrernummer:";
                        input2.Text = "Fahrername:";
                        input3.Text = "Fahrerteam:";
                    }
                }
            }
            else if(currentDisplayMode == DisplayMode.Results)
            {
                Rennen rennen = rennenList[standings.SelectedIndex];
                rennen.initialize(this);
                Switcher.changeTitle(rennen.name + " | " + rennen.ort);
                Switcher.switchPage(rennen);
            }
        }
        public List<KeyValuePair<string,int>> getResultsOfDriver(int driverNR)
        {
            List<KeyValuePair<string,int>> results = new List<KeyValuePair<string, int>>();
            foreach (Rennen rennen in rennenList)
            {
                if (rennen.ergebnis.Contains(driverNR))
                {
                    for (int i = 0; i < rennen.ergebnis.Count; i++)
                    {
                        if (rennen.ergebnis[i] == driverNR)
                        {
                            if(i < punkteSystem.Count)
                            {
                                results.Add(new KeyValuePair<string, int>(rennen.name, punkteSystem[i]));
                            }
                            else
                            {
                                results.Add(new KeyValuePair<string, int>(rennen.name, 0));
                            }
                        }
                    }
                }
            }
            return results;
        }
        private void backToMenu(object sender, RoutedEventArgs e)
        {
            if (currentDisplayMode == DisplayMode.Standings)
            {
                Switcher.switchPage(new Menu(url));
            }
            else if (currentDisplayMode == DisplayMode.Results) {
                showRaceResultsBTN.Content = "Results";
                backToMenuBTN.Content = "Back";
                title.Text = "Standings";
                standings.Items.Clear();
                displayStandings();
                currentDisplayMode  = DisplayMode.Standings;
            }
        }
        private void showRaceResults(object sender, RoutedEventArgs e)
        {
            if (currentDisplayMode == DisplayMode.Standings)
            {
                showRaceResultsBTN.Content = "Add Result";
                backToMenuBTN.Content = "Standings";
                title.Text = "Results";
                standings.Items.Clear();
                displayResults();
                currentDisplayMode = DisplayMode.Results;
            }
            else if (currentDisplayMode == DisplayMode.Results)
            {
                input1field.Text = "";
                input1field.IsEnabled = true;
                input2field.Text = "";
                input3field.Text = "";

                popUP.Visibility = Visibility.Visible;
                popUPBackground.Visibility = Visibility.Visible;

                popUPTitle.Text = "Rennen Hinzufügen:";
                input1.Text = "Name des Rennen:";
                input2.Text = "Austragungsort:";
                input3.Text = "Endstand (Format: [1.Platz],[2.Platz],...)";
            }
        }
        public void deleteDriver(Driver driver)
        {
            try
            {
                Task<string> response = new HttpClient().DeleteAsync(url + "/" + name + "/deleteDriver/" + driver.number).Result.Content.ReadAsStringAsync();

                MessageBox.Show(response.Result, "Antwort der API!", MessageBoxButton.OK, MessageBoxImage.Information);

                string jsonDrivers = new HttpClient().GetStringAsync(url + "/" + name + "/getDrivers").Result;

                fahrerfeld = new List<Driver>(JsonConvert.DeserializeObject<List<Driver>>(jsonDrivers));

                displayStandings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler beim Löschen", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void editDriver(Driver driver)
        {
            input1field.Text = driver.number.ToString();
            input1field.IsEnabled = false;
            input2field.Text = driver._name;
            input3field.Text = driver._team;

            popUP.Visibility = Visibility.Visible;
            popUPBackground.Visibility = Visibility.Visible;

            popUPTitle.Text = "Fahrer ändern:";
            input1.Text = "Fahrernummer:";
            input2.Text = "Fahrername:";
            input3.Text = "Fahrerteam:";
        }
        public void deleteResult(Rennen rennen)
        {
            try
            {
                Task<string> response = new HttpClient().DeleteAsync(url + "/" + name + "/deleteResult/" + rennen.id).Result.Content.ReadAsStringAsync();

                MessageBox.Show(response.Result, "Antwort der API!", MessageBoxButton.OK, MessageBoxImage.Information);

                displayResults();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler beim Löschen", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void editResult(Rennen rennen)
        {
            raceIDtoUpdate = rennen.id;

            input1field.Text = rennen.name;
            input1field.IsEnabled = true;
            input2field.Text = rennen.ort;

            foreach(int platz in rennen.ergebnis) 
            {
                input3field.Text += platz.ToString() + ",";
            }

            popUP.Visibility = Visibility.Visible;
            popUPBackground.Visibility = Visibility.Visible;

            popUPTitle.Text = "Rennen Ändern";
            input1.Text = "Name des Rennen:";
            input2.Text = "Austragungsort:";
            input3.Text = "Endstand (Format: [1.Platz],[2.Platz],...)";

        }
        public void popUPSubmit(object sender, RoutedEventArgs e)
        {
            if (currentDisplayMode == DisplayMode.Standings)
            {
                try
                {
                    int nummer = int.Parse(input1field.Text);
                    string fahrername = input2field.Text;
                    string team = input3field.Text;
                    Driver driver = new Driver(nummer, name, team);

                    JObject json = new JObject{
                        { "number", nummer },
                        { "name", fahrername },
                        { "team", team }
                    };

                    HttpContent content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

                    Task<string> response = null;

                    if(fahrerfeld.Where(p => p.number == nummer).ToArray().Length > 0)
                    {
                        response = new HttpClient().PutAsync(url + "/" + name + "/updateDriver", content).Result.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        response = new HttpClient().PostAsync(url + "/" + name + "/addDriver", content).Result.Content.ReadAsStringAsync();
                    }


                    MessageBox.Show(response.Result, "Antwort der API!", MessageBoxButton.OK, MessageBoxImage.Information);

                    popUPCancel(null, null);

                    string jsonDrivers = new HttpClient().GetStringAsync(url + "/" + name + "/getDrivers").Result;

                    fahrerfeld = new List<Driver>(JsonConvert.DeserializeObject<List<Driver>>(jsonDrivers));

                    displayStandings();
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message, "Fehler! Try again!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (currentDisplayMode == DisplayMode.Results)
            {
                addOrUpdateResult();
            }
        }
        public void addOrUpdateResult()
        {
            string rennname = input1field.Text;
            string austragungsort = input2field.Text;
            string[] resultStr = input3field.Text.Split(",");

            JArray result = new JArray();

            try
            {
                foreach (string platz in resultStr)
                {
                    if(platz != "")
                    {
                        result.Add(int.Parse(platz));
                    }
                }


                Task<string> response = null;

                if (popUPTitle.Text == "Rennen Ändern")
                {
                    JObject json = new JObject
                    {
                        { "id",  raceIDtoUpdate},
                        { "name", rennname },
                        { "ort", austragungsort },
                        { "ergebnis", result }
                    };

                    HttpContent content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

                    response = new HttpClient().PutAsync(url + "/" + name + "/updateResult", content).Result.Content.ReadAsStringAsync();
                }
                else
                {
                    JObject json = new JObject
                    {
                        { "name", rennname },
                        { "ort", austragungsort },
                        { "ergebnis", result }
                    };

                    HttpContent content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

                    response = new HttpClient().PostAsync(url + "/" + name + "/addResult", content).Result.Content.ReadAsStringAsync();
                }

                MessageBox.Show(response.Result, "Antwort der API!", MessageBoxButton.OK, MessageBoxImage.Information);


                popUPCancel(null, null);
                displayResults();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler! Try again!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void popUPCancel(object sender, RoutedEventArgs e)
        {
            input1field.Text = "";
            input2field.Text = "";
            input3field.Text = "";
            
            popUP.Visibility = Visibility.Hidden;
            popUPBackground.Visibility = Visibility.Hidden;
        }
    }
} 
