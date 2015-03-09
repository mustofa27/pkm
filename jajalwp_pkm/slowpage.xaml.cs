using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Coding4Fun.Toolkit.Audio;
using Coding4Fun.Toolkit.Audio.Helpers;
using System.IO;
using System.IO.IsolatedStorage;

namespace jajalwp_pkm
{
    public partial class slowpage : PhoneApplicationPage
    {
        private MicrophoneRecorder _recorder = new MicrophoneRecorder();
        public slowpage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }


        private void nextclick_Click(object sender, RoutedEventArgs e)
        {
            _recorder.Stop();
            SaveTempAudio(_recorder.Buffer);
        }

        private void recordbutton_Click(object sender, RoutedEventArgs e)
        {
            _recorder.Start();
        }
        private void SaveTempAudio(MemoryStream buffer)
        {
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                var bytes = buffer.GetWavAsByteArray(_recorder.SampleRate);
                var tempFileName = "tempWav.wav";
                IsolatedStorageFileStream audioStream = isoStore.CreateFile(tempFileName);
                audioStream.Write(bytes, 0, bytes.Length);
            }
        }

    }
}