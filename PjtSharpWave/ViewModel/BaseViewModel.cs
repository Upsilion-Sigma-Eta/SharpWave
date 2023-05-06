using System.ComponentModel;
using System.Collections.ObjectModel;
using PjtSharpWave.Model;
using System.Windows.Input;
using Microsoft.Win32;
using PjtSharpWave.Common;

namespace PjtSharpWave.ViewModel
{
    /// <summary>
    /// 모든 ViewModel은 BaseViewModel을 상속받는다.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Properties

        private ObservableCollection<Music> _musicList;
        public ObservableCollection<Music> MusicList
        {
            get { return _musicList; }
            set
            {
                _musicList = value;
                OnPropertyChanged(nameof(MusicList));
            }
        }
        #endregion Properties

        #region Constructor
        public BaseViewModel()
        {
            MusicList = new ObservableCollection<Music>();
        }
        #endregion Constructor

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion Events
    }
}
