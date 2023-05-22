using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RaceAPI
{
    internal static class Switcher
    {
        public static MainWindow target;

        public static void switchPage(UserControl page)
        {
            target.switchPage(page);
        }
        public static void changeTitle(string newTitle)
        {
            if(newTitle == null)
            {
                newTitle = "RaceAPI";
                Console.WriteLine("TITLE WAS NULL!");
            }
            target.Title = "RaceAPI - " + newTitle;
        }
    }
}
