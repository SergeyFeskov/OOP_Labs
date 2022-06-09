using Lab5_6;
using System.IO.Compression;
using System.Text;

namespace Lab4_Plugins
{
    public class DeflateArchivator : IPlugin
    {
        public string Name
        {
            get { return "Deflate archivator"; }
        }
        public string Description
        {
            get { return "compresses/decompresses strings using DeflateStream"; }
        }
        public string ParseIn(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var df = new DeflateStream(mso, CompressionMode.Compress))
                {
                    msi.CopyTo(df);
                }
                return Convert.ToBase64String(mso.ToArray());
            }
        }
        public string ParseOut(string input)
        {
            using (var msi = new MemoryStream(Convert.FromBase64String(input)))
            using (var mso = new MemoryStream())
            {
                using (var df = new DeflateStream(msi, CompressionMode.Decompress))
                {
                    df.CopyTo(mso);
                }
                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }
    }
}
