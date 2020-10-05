using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace KLADR_viewer_v4
{
    class CachinEgngine
    {
        private string folderNameDB;

        public CachinEgngine(string folderNameDB)
        {
            this.folderNameDB = folderNameDB;
            if (!Directory.Exists(folderNameDB + "cashing\\nodes\\"))
            {
                Directory.CreateDirectory(folderNameDB + "cashing\\nodes\\");
            }
        }

        public void addNode(string name, List<Dictionary<string, string>> source)
        {
            if (File.Exists(folderNameDB + "cashing\\nodes\\" + name + ".bin"))
                return;
            Stream TestFileStream = File.Create(folderNameDB + "cashing\\nodes\\" + name + ".bin");
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            serializer.Serialize(TestFileStream, source);
            TestFileStream.Close();
        }

        public void Dispose()
        {

        }

        public List<Dictionary<string, string>> getFromCashAsBin(string name)
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
