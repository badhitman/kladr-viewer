using System.Collections.Generic;
using System.IO;

namespace KLADR_viewer_v4
{
    class CachingEngine
    {
        private readonly string folderNameDB;

        public CachingEngine(string folderNameDB)
        {
            this.folderNameDB = folderNameDB;
            if (!Directory.Exists(folderNameDB + "cashing\\nodes\\"))
            {
                Directory.CreateDirectory(folderNameDB + "cashing\\nodes\\");
            }
        }

        public void AddNode(string name, List<Dictionary<string, string>> source)
        {
            if (File.Exists(folderNameDB + "cashing\\nodes\\" + name + ".bin"))
                return;
            Stream TestFileStream = File.Create(folderNameDB + "cashing\\nodes\\" + name + ".bin");
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            serializer.Serialize(TestFileStream, source);
            TestFileStream.Close();
        }

        public List<Dictionary<string, string>> GetFromCashAsBin(string name)
        {
            if (!File.Exists(folderNameDB + "cashing\\nodes\\" + name + ".bin"))
                return null;
            List<Dictionary<string, string>> returned;
            Stream TestFileStream = File.OpenRead(folderNameDB + "cashing\\nodes\\" + name + ".bin");
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter deserializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            returned = (List<Dictionary<string, string>>)deserializer.Deserialize(TestFileStream);
            TestFileStream.Close();
            return returned;
        }
    }
}