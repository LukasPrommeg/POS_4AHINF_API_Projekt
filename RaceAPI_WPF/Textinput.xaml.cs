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
using System.Windows.Shapes;

namespace RaceAPI
{
    /// <summary>
    /// Interaktionslogik für Textinput.xaml
    /// </summary>
    public partial class Textinput : Window
    {
        public Textinput()
        {
            InitializeComponent();
        }
        public Textinput(string title, string content)
        {
            InitializeComponent();
            Title = title;
            contentText.Text = content;
        }
        public void OKButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public string getInput()
        {
            return ResponseTextBox.Text;
        }
    }
}
