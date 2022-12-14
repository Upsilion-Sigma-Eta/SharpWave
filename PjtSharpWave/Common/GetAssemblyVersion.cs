using System;

namespace PjtSharpWave.Common
{
    /// <summary>
    /// 현재 버전을 가져오는 Class 입니다.
    /// </summary>
    public class GetVersion
    {
        /// <summary>
        /// 현재 버전을 가져 옵니다.
        /// </summary>
        public string BuildDate()
        {
            System.Version assemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            /// 빌드 날짜를 구합니다.
            DateTime buildDate = new DateTime(2000, 1, 1).AddDays(assemblyVersion.Build).AddSeconds(assemblyVersion.Revision * 2);
            string fileVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion.ToString();
            string temp = string.Format("{0} ({1}))", fileVersion, buildDate.ToString("yyyyMMdd"));

            return temp;
        }
    }
}
