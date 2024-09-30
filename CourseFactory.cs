using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method
{
    public class CourseFactory : EntityFactory
    {
        public override object Create(string[] parameters)
        {
            return new Course
            {
                Id = int.Parse(parameters[1]),
                Name = parameters[2],
                TeacherId = int.Parse(parameters[3]),
                Students = new List<int>()
            };
        }
    }
}
