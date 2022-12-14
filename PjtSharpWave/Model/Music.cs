using PjtSharpWave.Common;

namespace PjtSharpWave.Model
{
    public class Music : ObservableObjectBase<Music>
    {
        private static readonly Music _instance = new Music();
        public static Music Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// 곡 이름
        /// </summary>
        private string _musicName = string.Empty;
        public string MusicName
        {
            get
            {
                return this._musicName;
            }
            set
            {
                this._musicName = value;
                OnPropertyChanged(p => p.MusicName);
            }
        }
    }

}
