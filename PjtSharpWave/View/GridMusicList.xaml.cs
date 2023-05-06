using PjtSharpWave.Common;
using System.Windows;
using System.Windows.Controls;
namespace PjtSharpWave.View
{
    /// <summary>
    /// GridMusicList.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class GridMusicList : UserControl
    {
        #region Constructor
        public GridMusicList()
        {
            InitializeComponent();
            Log.Info("************ MUSIC LIST LOADED ************");
        }
        #endregion
    }
}
