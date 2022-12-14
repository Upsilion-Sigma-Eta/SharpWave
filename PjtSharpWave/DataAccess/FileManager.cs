using PjtSharpWave.Common;
using System;
using System.IO;
using System.Xml.Serialization;

namespace PjtSharpWave.DataAccess
{
    public class FileManager
    {
        /// <summary>
        /// Singleton 으로 선언 합니다.
        /// </summary>
        private static readonly FileManager _instance = new FileManager();
        public static FileManager Instance
        {
            get
            {
                return _instance;
            }
        }

        private FileManager()
        {

        }

        /// <summary>
        /// XML 파일을 읽고 역직렬화 하여 개체로 반환 합니다.
        /// </summary>
        /// <param name="type">역직렬화할 개체 타입</param>
        /// <param name="path">XML 파일 경로</param>
        /// <returns>개체</returns>
        public object ReadFromXml(Type type, string path)
        {
            object obj = null;

            try
            {
                if (File.Exists(path) == true)
                {
                    XmlSerializer serializer = new XmlSerializer(type);
                    using (FileStream fs = new FileStream(path, FileMode.Open))
                    {
                        obj = serializer.Deserialize(fs);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

            return obj;
        }

        /// <summary>
        /// 개체를 직렬화하여 XML 파일로 저장 합니다.
        /// </summary>
        /// <param name="type">직렬화할 개체 타입</param>
        /// <param name="target">직렬화할 객체</param>
        /// <param name="path">저장할 XML 파일 경로</param>
        /// <returns>XML 파일 저장 여부(true: XML 파일 저장 성공, false: XML 파일 저장 실패)</returns>
        public bool SaveToXml(Type type, object target, string path)
        {
            bool result = false;

            try
            {
                XmlSerializer serializer = new XmlSerializer(type);
                using (TextWriter writer = new StreamWriter(path))
                {
                    serializer.Serialize(writer, target);
                }
                result = true;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

            return result;
        }

        /// <summary>
        /// 폴더 검색후 없으면 생성하는 로직 추가
        /// </summary>
        /// <param name="strPath"></param>
        /// <returns></returns>
        public bool CreateDir(string strPath)
        {
            try
            {
                // Determine whether the directory exists.
                if (!Directory.Exists(strPath))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(strPath);
                    Log.Info(string.Format("Create directory : {0}", di.FullName));

                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return false;
            }
            finally { }
            return true;
        }
    }
}
