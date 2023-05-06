using System.ComponentModel;
using System.Collections.ObjectModel;
using PjtSharpWave.Model;
using System.Windows.Input;
using Microsoft.Win32;
using PjtSharpWave.Common;
using System;
namespace PjtSharpWave.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region Command

        public ICommand SelectFileCommand { get; private set; }

        #endregion Command


        #region Constructor
        public MainViewModel()
        {
            SelectFileCommand = new RelayCommand(SelectMp3File);
        }
        #endregion Constructor

        #region Business Logic
        /// <summary>
        /// Play 버튼 눌렀을 때 동작하는 음악 실행 프로세스
        /// </summary>
        private void Process()
        {
            try
            {
                if (MusicList == null)
                {
                    /// 곡 선택하라고 메시지박스 띄워줌.
                    return;
                }

                

                //TODO: 곡 리스트 가져와서 큐에 넣고 돌림 => 중간에 셔플 등 Property가 바뀔경우 처리 
                

            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
        #endregion Business Logic

        #region Custom Method
        private void SelectMp3File(object parameter)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                AlbumTitleExtension albumTitleExtension = new AlbumTitleExtension();
                dialog.Filter = "MP3 Files (*.mp3)|*.mp3";

                if (dialog.ShowDialog() == true)
                {
                    string albumName = albumTitleExtension.GetAlbumTitleFromMP3(dialog.FileName);

                    Music music = new Music();

                    // MP3 파일의 앨범 ID3 Tag를 가져오는데, ID3 태그가 없는 정식 앨범이 아닌 경우
                    // 파일명을 그대로 가져옴.
                    // 정식 앨범일 경우 앨범 곡 제목을 가져오도록 처리.
                    if (albumName == string.Empty)
                    {
                        // 확장자 제거 ( sample.mp3 => sample )
                        music.Title = System.IO.Path.GetFileNameWithoutExtension(dialog.SafeFileName);
                    }
                    else
                    {
                        music.Title = albumName;
                    }

                    MusicList.Add(music);
                }
            }
            catch(Exception ex)
            {
                Log.Error(ex);
            }
            
        }
        #endregion Custom Method
    }
}
