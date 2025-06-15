namespace ProgAdvII.MB10_01.Linq.QueryExpression.Exercise {
    internal class Program {
        static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<Student> students = new List<Student> {
                new Student { Id = 2009001, Name = "John Doe", Subject = "Computing" },
                new Student { Id = 2009002, Name = "Linda Miller", Subject = "Chemistry" },
                new Student { Id = 2009003, Name = "Ann Foster", Subject = "Mathematics" },
                new Student { Id = 2009004, Name = "Sam Dough", Subject = "Computing" }
            };

            List<Marking> markings = new List<Marking> {
                new Marking { StudentId = 2009001, Course = "Programming", Mark = 4 },
                new Marking { StudentId = 2009002, Course = "Databases", Mark = 5 },
                new Marking { StudentId = 2009003, Course = "Graphics", Mark = 6 },
                new Marking { StudentId = 2009004, Course = "Chemistry", Mark = 6 },
                new Marking { StudentId = 2009001, Course = "Math", Mark = 5 }
            };

            var result = GetComputingStudentStats(students, markings);

            bool success = true;

            var expected = new[] {
                new { Name = "John Doe", CourseCount = 2, AverageMark = 2.5 },
                new { Name = "Sam Dough", CourseCount = 1, AverageMark = 1.0 }
            };

            var actual = result.ToList();

            if (actual.Count != expected.Length) {
                Console.WriteLine("❌ Anzahl Resultate stimmt nicht.");
                success = false;
            }

            for (int i = 0; i < expected.Length; i++) {
                if (actual[i].Name != expected[i].Name ||
                    actual[i].CourseCount != expected[i].CourseCount ||
                    Math.Abs(actual[i].AverageMark - expected[i].AverageMark) > 0.01) {
                    Console.WriteLine($"❌ Fehler bei Eintrag {i + 1}:");
                    Console.WriteLine($"   Erwartet: {expected[i].Name}, {expected[i].CourseCount} Kurse, Ø {expected[i].AverageMark}");
                    Console.WriteLine($"   Tatsächlich: {actual[i].Name}, {actual[i].CourseCount} Kurse, Ø {actual[i].AverageMark}");
                    success = false;
                }
            }

            if (success) {
                Console.WriteLine("✅ Alle Tests erfolgreich bestanden!");
            }
        }

        public static IEnumerable<StudentResult> GetComputingStudentStats(List<Student> students, List<Marking> markings) {
            // TODO: Query gemäss Aufgabenstellung implementieren
            throw new NotImplementedException();
        }
    }

    public class Student {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
    }

    public class Marking {
        public int StudentId { get; set; }
        public string Course { get; set; }
        public int Mark { get; set; }
    }

    public class StudentResult {
        public string Name { get; set; }
        public int CourseCount { get; set; }
        public double AverageMark { get; set; }
    }
}
