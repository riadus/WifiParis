using System;
using System.IO;
using WifiParisComplete.Domain;

namespace WifiParisMVCComplete.iOS
{
    public class FilePathProviderIOS : IFilePathProvider
    {
        public string DatabasePath {
            get {
                var personalFolder = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
                var sqliteFilename = "WifiParisComplete";
                return Path.Combine (personalFolder, sqliteFilename);
            }
        }
    }
}
