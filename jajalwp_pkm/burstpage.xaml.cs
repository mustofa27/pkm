using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using System.IO;

namespace jajalwp_pkm
{
    public partial class burstpage : PhoneApplicationPage
    {
        public burstpage()
        {
            InitializeComponent();
            IsiSource();
        }
        private int i = 2;
        private string path = "/Assets/An Naba'/78ayat",ext = ".wav";
        private void IsiSource()
        {
            koreksi.Source = new Uri("/Assets/An Naba'/78ayat1.wav", UriKind.RelativeOrAbsolute);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            koreksi.Play();
            //koreksi.Source = new Uri(path + i++.ToString() + ext, UriKind.RelativeOrAbsolute);
        }
    }
}