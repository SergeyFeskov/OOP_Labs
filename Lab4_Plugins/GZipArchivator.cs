using Lab4;
using System.IO.Compression;
using System.Text;

namespace Lab4_Plugins
{
    public class GZipArchivator : IPlugin
    {
        public string Name
        {
            get { return "GZip archivator"; }
        }
        public string Description
        {
            get { return "compresses/decompresses strings using GZipStream"; }
        }
        public string ParseIn(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    msi.CopyTo(gs);                    
                }
                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }
        public string ParseOut(string input)
        {
            using (var msi = new MemoryStream(Encoding.UTF8.GetBytes(input)))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    gs.CopyTo(mso);                    
                }
                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }
    }
}