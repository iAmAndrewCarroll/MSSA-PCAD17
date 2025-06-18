using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double GPA { get; set; }
}

class Program
{
    static void Main()
    {
        var student = new Student { Id = 1, Name = "Alice", GPA = 3.9 };

        // === JSON Serialization ===
        string jsonPath = "student.json";
        string jsonString = JsonSerializer.Serialize(student);
        File.WriteAllText(jsonPath, jsonString);

        // JSON Deserialization
        string jsonRead = File.ReadAllText(jsonPath);
        var studentFromJson = JsonSerializer.Deserialize<Student>(jsonRead);
        Console.WriteLine($"[JSON] {studentFromJson.Id} - {studentFromJson.Name} - {studentFromJson.GPA}");

        // === XML Serialization ===
        string xmlPath = "student.xml";
        var xmlSerializer = new XmlSerializer(typeof(Student));
        using (var xmlStream = new FileStream(xmlPath, FileMode.Create))
        {
            xmlSerializer.Serialize(xmlStream, student);
        }

        // XML Deserialization
        using (var xmlReadStream = new FileStream(xmlPath, FileMode.Open))
        {
            var studentFromXml = (Student)xmlSerializer.Deserialize(xmlReadStream);
            Console.WriteLine($"[XML] {studentFromXml.Id} - {studentFromXml.Name} - {studentFromXml.GPA}");
        }

        Console.ReadKey();
    }
}
