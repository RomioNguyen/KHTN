using System.Configuration;
using System.IO;
using System.Reflection;

namespace BT1_1981223_20880263.Sevices.File
{
    public class FileServices : IFileServices
    {
        private readonly string EXTENSION = "ExtensionFile";
        private readonly string PREFIX = "PrefixFolder";
        private readonly string SPECIAL_CHARACTER = "|";

        public string[] GetArrayUrl(string key)
        {
            string arrayName = ConfigurationManager.AppSettings.Get(key);
            if (arrayName.Contains(SPECIAL_CHARACTER))
            {
                return arrayName.Split(SPECIAL_CHARACTER);
            }
            return new string[1] { arrayName };
        }

        public string GetUrlFile(string fileName)
        {

            string fullNameFile = string.Format(@"{0}\{1}.{2}", ConfigurationManager.AppSettings.Get(PREFIX), fileName, ConfigurationManager.AppSettings.Get(EXTENSION));
            string baseDirectory = Directory.GetParent(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)).ToString().Replace("\\bin\\Debug", "");
            return Path.Combine(baseDirectory, fullNameFile);
        }
    }
}
