using Comparable_Mark.Models;

namespace Comparable_Mark.FileProcessors;

public interface IFileProcessor
{
    List<Student> Load(string filename);
    void Save(string filename, List<Student> students);
}