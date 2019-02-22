using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Tutorial
{
    class FileLibrary
    {
        internal string GetRootPath()
        {
            return Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)))).Substring(6);
        }

        private string GetOutPath()
        {
            return new StringBuilder().Append(GetRootPath()).Append("\\").Append("Output").Append("\\").ToString();
        }

        public void WordsWritetoFils(string filename, List<string> words)
        {
            string outPath = GetOutPath();

            using (TextWriter textWriter = new StreamWriter(new StringBuilder().Append(outPath).Append(filename).Append(@".txt").ToString()))
            {
                words.ForEach(x => textWriter.WriteLine(x));
            }
        }

        private List<FileInfo> GetFilesInfo(string dataPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(dataPath);
            List<FileInfo> filesInfo = directoryInfo.GetFiles("*.*").ToList();
            return filesInfo;
        }
    }
}