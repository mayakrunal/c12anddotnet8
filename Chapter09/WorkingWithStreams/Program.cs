using Packt.Shared; // To use Viper.
using System.Xml; // To use XmlWriter and so on.
using System.IO.Compression; // To use BrotliStream, GZipStream.

SectionTitle("Writing to text streams");

// Define a file to write to.
string textFile = Combine(CurrentDirectory, "streams.txt");

// Create a text file and return a helper writer.
using (StreamWriter text = File.CreateText(textFile))
{
    // Enumerate the strings, writing each one to the stream
    // on a separate line.
    foreach (string item in Viper.Callsigns)
    {
        text.WriteLine(item);
    }
}

OutputFileInfo(textFile);

SectionTitle("Writing to XML streams");
// Define a file path to write to.
string xmlFile = Combine(CurrentDirectory, "streams.xml");
try
{
    using FileStream xmlFileStream = File.Create(xmlFile);
    using XmlWriter xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true });

    // Write the XML declaration.
    xml.WriteStartDocument();

    // Write a root element.
    xml.WriteStartElement("callsigns");
    // Enumerate the strings, writing each one to the stream.
    foreach (string item in Viper.Callsigns)
    {
        xml.WriteElementString("callsign", item);
    }
    // Write the close root element.
    xml.WriteEndElement();
}
catch (Exception ex)
{

    // If the path doesn't exist the exception will be caught.
    WriteLine($"{ex.GetType()} says {ex.Message}");
}

OutputFileInfo(xmlFile);

SectionTitle("Compressing streams");
Compress(algorithm: "gzip");
Compress(algorithm: "brotli");