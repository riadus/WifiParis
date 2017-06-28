using System;
using System.IO;
using WifiParisComplete.Domain;
using WifiParisComplete.Domain.Attributes;

namespace WifiParisComplete.XF.Droid
{
    [RegisterInterfaceAsDynamic]
    public class FilePathProviderDroid : IFilePathProvider
    {
        public string DatabasePath {
            get {
                var personalFolder = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
                var sqliteFilename = "WifiParisComplete.db3";
                return Path.Combine (personalFolder, sqliteFilename);
            }
        }
    }
}
