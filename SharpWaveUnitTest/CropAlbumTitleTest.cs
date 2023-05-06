using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PjtSharpWave;
using PjtSharpWave.Model;
using PjtSharpWave.Common;
namespace SharpWaveUnitTest
{
    [TestClass]
    public class DataGridBindingTest
    {
        [TestMethod]
        public void AlbumTitleExtension_TEST()
        {
            AlbumTitleExtension albumTitleExtension = new AlbumTitleExtension();
            string strAlbumTitle = albumTitleExtension.GetAlbumTitleFromMP3("Z:\\PjtSharpWave\\PjtSharpWave\\SampleMP3File\\sample.mp3");
            Console.WriteLine(strAlbumTitle);   
        }
    }
}
