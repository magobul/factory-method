using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method
{
    public class EducationSystem
    {
        private List<Student> students = new List<Student>();
        private List<Teacher> teachers = new List<Teacher>();
        private List<Course> courses = new List<Course>();

        public void LoadData(string filePath)
        {
            foreach (var line in File.ReadAllLines(filePath))
            {
                var parameters = line.Split(',');
                switch (parameters[0])
                {
                    case "student":
                        var studentFactory = new StudentFactory();
                        students.Add((Student)studentFactory.Create(parameters));
                        break;
                    case "teacher":
                        var teacherFactory = new TeacherFactory();
                        teachers.Add((Teacher)teacherFactory.Create(parameters));
                        break;
                    case "course":
                        var courseFactory = new CourseFactory();
                        var course = (Course)courseFactory.Create(parameters);
                        courses.Add(course);
                        break;
                }
            }

            // Установим связи после загрузки данных
            foreach (var course in courses)
            {
                var teacher = teachers.Find(t => t.Id == course.TeacherId);
                if (teacher != null)
                    teacher.Courses.Add(course.Id);

                foreach (var studentId in course.Students)
                {
                    var student = students.Find(s => s.Id == studentId);
                    if (student != null)
                        student.Courses.Add(course.Id);
                }
            }
        }

        public void SaveData(string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var student in students)
                {
                    writer.WriteLine($"student,{student.Id},{student.Name}");
                }

                foreach (var teacher in teachers)
                {
                    writer.WriteLine($"teacher,{teacher.Id},{teacher.Experience},{teacher.Name}");
                }

                foreach (var course in courses)
                {
                    writer.WriteLine($"course,{course.Id},{course.Name},{course.TeacherId}");
                }
            }
        }
    }
}
