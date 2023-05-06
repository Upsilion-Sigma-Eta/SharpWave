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
        private string _title = string.Empty;
        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
                OnPropertyChanged(p => p.Title);
            }
        }
    }

}
