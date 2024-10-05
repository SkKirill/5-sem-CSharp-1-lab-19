using System.IO;
using System.Collections.Generic;
using System.Linq;
using Comparable_Mark.Models;

namespace Comparable_Mark.FileProcessors;

public class TextFileProcessor : IFileProcessor
{
    public List<Student> Load(string filename)
    {
        // Проверка на существование файла
        if (!File.Exists(filename))
            return new List<Student>(); // Возвращаем пустой список

        List<Student> students = new List<Student>();
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(';');
                // Парсим строку и создаем объект Student
                // ...
            }
        }
        return students;
    }

    public void Save(string filename, List<Student> students)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Student student in students)
            {
                // Формируем строку для записи в файл
                string line = $"{student.FullName};{student.CourseNumber};{student.GroupNumber};{student.StudyForm};";
                // Добавляем данные об экзаменах
                // ...
                writer.WriteLine(line);
            }
        }
    }
}