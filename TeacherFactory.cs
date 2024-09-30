using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method
{
    public class TeacherFactory : EntityFactory
    {
        public override object Create(string[] parameters)
        {
            return new Teacher
            {
                Id = int.Parse(parameters[1]),
                Experience = int.Parse(parameters[2]),
                Name = parameters[3],
                Courses = new List<int>()
            };
        }
    }
}
