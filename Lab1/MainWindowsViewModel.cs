using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Media;

using WinForms = System.Windows.Forms;

namespace Lab1
{
    public class MainWindowsViewModel : ViewModelBase
    {
        private string _path;
        private MediaPlayer _mediaPlayer;
        private bool _isPlaying;
        private double _volumeState;

        System.Timers.Timer _timer;
        private double _value;

        private RelayCommand _browseFromWavCommand;
        private RelayCommand _soundProcessCommand;
        private RelayCommand _runSineVolumeCommand;

        public bool IsPlaying
        {
            get => _isPlaying;
            set
            {
                _isPlaying = value;
                OnPropertyChanged(nameof(IsPlaying));
            }
        }

        public double VolumeState
        {
            get => _volumeState;
            set
            {
                _volumeState = value;
                SliderVolume = (int)(_volumeState * 100);
                OnPropertyChanged(nameof(SliderVolume));
                OnPropertyChanged(nameof(VolumeState));
            }
        }

        public int SliderVolume { get;set; }

        public RelayCommand BrowseFromWavCommand
        {
            get
            {
                if (_browseFromWavCommand == null)
                    _browseFromWavCommand = new RelayCommand((param) => BrowseFromWavAction());

                return _browseFromWavCommand;
            }
        }

        public RelayCommand SoundProcessCommand
        {
            get
            {
                if (_soundProcessCommand == null)
                    _soundProcessCommand = new RelayCommand(SoundProcessAction);

                return _soundProcessCommand;
            }
        }

        public RelayCommand RunSineVolumeCommand
        {
            get
            {
                if (_runSineVolumeCommand == null)
                    _runSineVolumeCommand = new RelayCommand((param) => RunSineVolumeAction());

                return _runSineVolumeCommand;
            }
        }

        public MainWindowsViewModel()
        {

        }

        private void BrowseFromWavAction()
        {
            if (_timer != null)
                _timer.Stop();

            WinForms.FileDialog fld = new WinForms.OpenFileDialog();
            fld.Filter = "Audio files (*.wav)|*.wav";
            fld.RestoreDirectory = true;
            
            if(fld.ShowDialog() == WinForms.DialogResult.OK)
            {
                _path = fld.FileName;

                ProcessFile();
            }
        }

        private void ProcessFile()
        {
            if (!File.Exists(_path))
            {
                MessageBox.Show("File doesn't exist");
                return;
            }

            _mediaPlayer = new MediaPlayer();
            _mediaPlayer.Open(new Uri(_path));
            SoundProcessAction("play");
        }

        private void SoundProcessAction(object param)
        {
            if (_mediaPlayer == null)
                return;

            if(param.ToString() == "play")
            {
                _mediaPlayer.Play();
                IsPlaying = true;
            }
            else
            {
                // stop
                _mediaPlayer.Stop();
                IsPlaying = false;

                if (_timer != null)
                    _timer.Stop();
            }
        }

        private void RunSineVolumeAction()
        {
            _value = 0;
            _timer = new System.Timers.Timer();
            _timer.Elapsed += UpdateVolume;
            _timer.Interval = 10;

            _timer.Enabled = true;

            //_timer.Start();
        }

        public void UpdateVolume(object source, ElapsedEventArgs e)
        {
            // Media player required invoke from Main Thread
            Application.Current.Dispatcher.Invoke(new Action(() => 
            {
                _value += 0.01;
                // math sin -> from 1 to -1
                // so + 1 -> from 2 to 0
                // and divide by two -> from 1 to 0
                VolumeState = _mediaPlayer.Volume = (Math.Sin(_value) + 1) / 2;
                Console.WriteLine(VolumeState);
            }));
        }
    }
}
