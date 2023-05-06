using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;
namespace PjtSharpWave.Common
{
    public class AlbumTitleExtension
    {
        public string GetAlbumTitleFromMP3(string filePath)
        {
            try
            {
                using (File file = File.Create(filePath))
                {
                    if (file.Tag != null && !string.IsNullOrEmpty(file.Tag.Album))
                    {
                        return file.Tag.Album;
                    }
                }
            }
            catch (CorruptFileException ex)
            {
                /// MP3 파일이 손상되었거나 ID3 태그를 지원하지 않는 경우에 대한 예외 처리
                Log.Error("Failed to read ID3 tag: " + ex.Message);
            }
            catch (Exception ex)
            {
                /// 그 외의 예외 처리
                Log.Error("Error reading ID3 tag: " + ex.Message);
            }

            return string.Empty;
        }
    }
}
