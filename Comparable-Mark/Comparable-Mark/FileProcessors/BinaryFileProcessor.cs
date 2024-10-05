using System.Runtime.Serialization.Formatters.Binary;
using Comparable_Mark.Models;

namespace Comparable_Mark.FileProcessors;

public class BinaryFileProcessor : IFileProcessor
{
    [Obsolete("Obsolete")] 
    public List<Student> Load(string filename)
    {
        // Проверка на существование файла
        if (!File.Exists(filename))
            return []; // Возвращаем пустой список

        var formatter = new BinaryFormatter();
        using var fs = new FileStream(filename, FileMode.Open);
        return (List<Student>)formatter.Deserialize(fs);
    }

    [Obsolete("Obsolete")]
    public void Save(string filename, List<Student> students)
    {
        var formatter = new BinaryFormatter();
        using var fs = new FileStream(filename, FileMode.Create);
        formatter.Serialize(fs, students);
    }
}