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
        private IsolatedStorageFileStream audioStream;
        private string tempFileName = "tempWav.wav";
        public slowpage()
        {
            InitializeComponent();
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
            if (buffer == null)
                throw new ArgumentNullException("bacaan tidak jelas!");
            if(audioStream != null)
            {
                AudioPlayer.Stop();
                AudioPlayer.Source = null;
                audioStream.Dispose();
            }
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                var bytes = buffer.GetWavAsByteArray(_recorder.SampleRate);
                if(isoStore.FileExists(tempFileName))
                {
                    isoStore.DeleteFile(tempFileName);
                }
                audioStream = isoStore.CreateFile(tempFileName);
                audioStream.Write(bytes, 0, bytes.Length);
                AudioPlayer.SetSource(audioStream);
            }
        }

    }
}