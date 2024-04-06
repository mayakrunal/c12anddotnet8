using Packt.Shared; // To use Viper.
using System.IO.Compression; // To use BrotliStream, GZipStream.
using System.Xml; // To use XmlWriter, XmlReader.

public partial class Program
{
    private static void Compress(string algorithm = "gzip")
    {
        // Define a file path using the algorithm as file extension.
        string filePath = Combine(CurrentDirectory, $"streams.{algorithm}");
        FileStream file = File.Create(filePath);
        using (Stream compressor = algorithm == "gzip" ?
               new GZipStream(file, CompressionMode.Compress) :
               new BrotliStream(file, CompressionMode.Compress))
        using (XmlWriter xml = XmlWriter.Create(compressor))
        {
            xml.WriteStartDocument();
            xml.WriteStartElement("callsigns");
            foreach (string item in Viper.Callsigns)
            {
                xml.WriteElementString("callsign", item);
            }
        }
        OutputFileInfo(filePath);

        // Read the compressed file.
        WriteLine("Reading the compressed XML file:");
        file = File.Open(filePath, FileMode.Open);
        using (Stream dempressor = algorithm == "gzip" ?
              new GZipStream(file, CompressionMode.Decompress) :
              new BrotliStream(file, CompressionMode.Decompress))
        using (XmlReader reader = XmlReader.Create(dempressor))
        {
            while (reader.Read())
            {
                if (reader is { NodeType: XmlNodeType.Element, Name: "callsign" })
                {
                    reader.Read(); // Move to the text inside element.
                    WriteLine($"{reader.Value}"); // Read its value.
                }
            }
        }
    }
}
