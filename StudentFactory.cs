using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method
{
    public class StudentFactory : EntityFactory
    {
        public override object Create(string[] parameters)
        {
            return new Student
            {
                Id = int.Parse(parameters[1]),
                Name = parameters[2],
                Courses = new List<int>()
            };
        }
    }
}
