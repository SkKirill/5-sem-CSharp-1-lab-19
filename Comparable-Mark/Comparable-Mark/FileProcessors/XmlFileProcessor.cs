using System.Xml.Serialization;
using System.IO;
using Comparable_Mark.Models;

namespace Comparable_Mark.FileProcessors;

public class XmlFileProcessor : IFileProcessor
{
    public List<Student> Load(string filename)
    {
        if (!File.Exists(filename))
        {
            return new List<Student>();
        }

        XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
        using (FileStream stream = new FileStream(filename, FileMode.Open))
        {
            return (List<Student>)serializer.Deserialize(stream);
        }
    }

    public void Save(string filename, List<Student> students)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
        using (FileStream stream = new FileStream(filename, FileMode.Create))
        {
            serializer.Serialize(stream, students);
        }
    }
}